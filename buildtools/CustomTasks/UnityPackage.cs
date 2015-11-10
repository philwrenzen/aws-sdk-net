﻿using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace CustomTasks
{
    public class UnityPackage : Task
    {
        public string UnityExe { get; set; }
        public string DeploymentPath { get; set; }
        public string ToolsPath { get; set; }


        public string ServiceName { get; set; }
        private string UnityTempProjectPath { get; set; }
        private string SdkVersionFile { get; set; }
        private static List<String> StandardAssemblies = new List<string>() { @"CognitoIdentity", @"SecurityToken", @"Core" };

        public override bool Execute()
        {

            if (string.IsNullOrEmpty(UnityExe))
                throw new ArgumentNullException("UnityExe");

            if (string.IsNullOrEmpty(DeploymentPath))
                throw new ArgumentNullException("DeploymentPath");

            Log.LogMessage(@"Deployment path = {0}", DeploymentPath);

            string unityAssemblies = Path.Combine(DeploymentPath, "assemblies", "unity");
            if (!Directory.Exists(unityAssemblies))
                throw new DirectoryNotFoundException("Cannot find Unity Assemblies");

            SdkVersionFile = Path.Combine(DeploymentPath, @"_sdk-versions.json");

            string unityFiles = Path.Combine(DeploymentPath, "unity");

            UnityTempProjectPath = Path.Combine(unityFiles, "temp");

            if (Directory.Exists(unityFiles))
                DeleteDirectory(unityFiles);

            foreach (var service in Directory.GetFiles(unityAssemblies, @"*.dll", SearchOption.TopDirectoryOnly))
            {

                ServiceName = Path.GetFileNameWithoutExtension(service).Replace(@"AWSSDK.", @"");
                if (StandardAssemblies.Contains(ServiceName))
                    continue;

                Log.LogMessage(@"Creating unity package for service {0}", ServiceName);

                if (Directory.Exists(UnityTempProjectPath))
                    DeleteDirectory(UnityTempProjectPath);

                //create unity project
                CreateTempUnityProject();

                //copy plugins folder
                var pluginsFolder = Path.Combine(DeploymentPath, @"..", @"buildtools", @"UnityTools", @"Plugins");
                if (!Directory.Exists(pluginsFolder))
                    throw new DirectoryNotFoundException("Cannot find Plugins Directory");

                CopyDirectory(pluginsFolder, Path.Combine(UnityTempProjectPath, @"Assets", @"Plugins"));

                //create SDK Directory
                var assetsFolder = Path.Combine(UnityTempProjectPath, @"Assets");
                var awssdkDirectory = Path.Combine(assetsFolder, @"AWSSDK");

                Directory.CreateDirectory(awssdkDirectory);

                //copy assembly files
                CopyAssemblies(unityAssemblies, awssdkDirectory);

                //create unitypackage
                CreateUnityPackage(unityFiles);

                //delete the temp file
                DeleteDirectory(UnityTempProjectPath);
            }
            return true;
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, true);
        }


        private void CreateUnityPackage(string path)
        {
            var outputFile = Path.Combine(path, string.Format(@"AWSSDK.{0}.{1}.unitypackage", ServiceName, ServiceVersion));
            var command = string.Format(@"-quit -batchmode -projectPath {0} -exportPackage Assets ..\{1}", Path.GetFullPath(UnityTempProjectPath), string.Format(@"AWSSDK.{0}.{1}.unitypackage", ServiceName, ServiceVersion));
            ExecuteUnityCommand(UnityExe, command);
        }

        private void CopyAssemblies(string unityFiles, string destination)
        {
            var dependencies = new List<string>(DependantServices);
            dependencies.AddRange(StandardAssemblies);

            foreach (var d in dependencies)
            {
                var searchString = string.Format(@"*.{0}.*", d);
                foreach (string newPath in Directory.EnumerateFiles(unityFiles, searchString, SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".dll") || s.EndsWith(".pdb")))
                    File.Copy(newPath, newPath.Replace(unityFiles, destination), true);
            }
        }

        private static void CopyDirectory(string sourcePath, string destinationPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
        }

        private string ServiceVersion
        {
            get
            {
                string file = File.ReadAllText(SdkVersionFile).Trim();
                var sdkversions = JsonConvert.DeserializeObject<Versions>(file);
                return sdkversions.ServiceVersions[ServiceName].Version;
            }
        }

        private IEnumerable<string> DependantServices
        {
            get
            {
                string file = File.ReadAllText(SdkVersionFile).Trim();
                var sdkversions = JsonConvert.DeserializeObject<Versions>(file);
                return sdkversions.ServiceVersions[ServiceName].Dependencies.Keys;
            }
        }

        private void CreateTempUnityProject()
        {
            var command = string.Format(@"-quit -batchmode -createProject {0}", UnityTempProjectPath);
            ExecuteUnityCommand(UnityExe, command);
        }

        internal static void ExecuteUnityCommand(string unityExe, string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = unityExe;

            process.StartInfo.Arguments = command;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;
            StringBuilder buffer = new StringBuilder();
            process.OutputDataReceived += new DataReceivedEventHandler
            (
                delegate(object sender, DataReceivedEventArgs e)
                {
                    Console.WriteLine(e.Data);
                    buffer.AppendLine(e.Data);
                }
            );
            process.ErrorDataReceived += new DataReceivedEventHandler
            (
                delegate(object sender, DataReceivedEventArgs e)
                {
                    Console.WriteLine(e.Data);
                    buffer.AppendLine(e.Data);
                }
            );
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception(string.Format(@"error executing unity command {0}", command));
            }
        }

        internal class Versions
        {
            public string ProductVersion { get; set; }
            public string CoreVersion { get; set; }
            public Dictionary<string, Service> ServiceVersions { get; set; }

            internal class Service
            {
                public string Version { get; set; }
                public Dictionary<string, string> Dependencies { get; set; }
            }

        }



    }
}