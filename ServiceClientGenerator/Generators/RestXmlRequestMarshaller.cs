﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ServiceClientGenerator.Generators
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class RestXmlRequestMarshaller : BaseRequestMarshaller
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

	AddLicenseHeader();
	
	AddCommonUsingStatements();

            
            #line default
            #line hidden
            this.Write("using System.Xml;\r\n\r\nnamespace ");
            
            #line 13 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Config.Namespace));
            
            #line default
            #line hidden
            this.Write(".Model.Internal.MarshallTransformations\r\n{\r\n\t/// <summary>\r\n\t/// ");
            
            #line 16 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.Name));
            
            #line default
            #line hidden
            this.Write(" Request Marshaller\r\n\t/// </summary>       \r\n\tpublic class ");
            
            #line 18 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.Name));
            
            #line default
            #line hidden
            this.Write("RequestMarshaller : IMarshaller<IRequest, ");
            
            #line 18 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.Name));
            
            #line default
            #line hidden
            this.Write("Request> , IMarshaller<IRequest,AmazonWebServiceRequest>\r\n\t{\r\n\t\tpublic IRequest M" +
                    "arshall(AmazonWebServiceRequest input)\r\n        {\r\n            return this.Marsh" +
                    "all((");
            
            #line 22 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.Name));
            
            #line default
            #line hidden
            this.Write("Request)input);\r\n        }\r\n\r\n\t\tpublic IRequest Marshall(");
            
            #line 25 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.Name));
            
            #line default
            #line hidden
            this.Write("Request publicRequest)\r\n\t\t{\r\n\t\t\tvar request = new DefaultRequest(publicRequest, \"" +
                    "");
            
            #line 27 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Config.Namespace));
            
            #line default
            #line hidden
            this.Write("\");\r\n");
            
            #line 28 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

	// Assign HttpMethod if present or default to POST
	if(!string.IsNullOrWhiteSpace(this.Operation.HttpMethod)){		

            
            #line default
            #line hidden
            this.Write("\t\t\trequest.HttpMethod = \"");
            
            #line 32 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Operation.HttpMethod));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 33 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

	}
	var requestStructure = this.Operation.RequestStructure;

    // This block adds members of the request object to the actual request
	ProcessRequestUri(this.Operation);
	ProcessHeaderMembers("publicRequest", this.Operation.RequestHeaderMembers);		
	ProcessUriMembers("publicRequest", this.Operation);
	ProcessQueryStringMembers("publicRequest", this.Operation);
	ProcessStreamingMember("publicRequest",this.Operation.RequestStreamingMember);

            
            #line default
            #line hidden
            this.Write("\t\t\trequest.ResourcePath = uriResourcePath;\r\n\r\n");
            
            #line 46 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
   
	// Process any members which are marshalled as part of the request body
	if(this.Operation.RequestHasBodyMembers)
	{
		ProcessRequestBodyMembers("publicRequest", this.Operation);		
	}

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 54 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

	// If there aren't any members that are marshalled as part of the body or streamed	
	if(this.Operation.UseQueryString)
	{

            
            #line default
            #line hidden
            this.Write("\t\t\trequest.UseQueryString = true;\r\n");
            
            #line 60 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
	}	

            
            #line default
            #line hidden
            this.Write("\t\t\treturn request;\r\n\t\t}\r\n\r\n\t\t\r\n\t}\t\r\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 69 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"


	void ProcessRequestBodyMembers(string variableName, Operation operation)
	{

        
        #line default
        #line hidden
        
        #line 73 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\tvar stringWriter = new StringWriter(CultureInfo.InvariantCulture);\r\n\t\t\tusing (" +
        "var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings() { Encodin" +
        "g = System.Text.Encoding.UTF8, OmitXmlDeclaration = true }))\r\n\t\t\t{   \r\n");

        
        #line default
        #line hidden
        
        #line 77 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

		if(operation.RequestPayloadMember==null)
		{

        
        #line default
        #line hidden
        
        #line 80 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\txmlWriter.WriteStartElement(\"");

        
        #line default
        #line hidden
        
        #line 81 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(operation.Input.LocationName));

        
        #line default
        #line hidden
        
        #line 81 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 81 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(operation.XmlNamespace));

        
        #line default
        #line hidden
        
        #line 81 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\");\t\r\n");

        
        #line default
        #line hidden
        
        #line 82 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

		}
		else
		{

        
        #line default
        #line hidden
        
        #line 86 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\txmlWriter.WriteStartElement(\"");

        
        #line default
        #line hidden
        
        #line 87 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(operation.RequestPayloadMember.MarshallName));

        
        #line default
        #line hidden
        
        #line 87 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 87 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(operation.XmlNamespace));

        
        #line default
        #line hidden
        
        #line 87 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\");\t\t\t\t\t\t\t\t\r\n");

        
        #line default
        #line hidden
        
        #line 88 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

		}
		var childmembers = operation.RequestPayloadMember == null ? operation.RequestBodyMembers : operation.RequestPayloadMember.Shape.Members;
		variableName = operation.RequestPayloadMember == null ? variableName : variableName + "." + operation.RequestPayloadMember.PropertyName;
		foreach(var member in childmembers)
		{
			if(member.IsStructure)
			{
				ProcessStructure(variableName, member, operation.XmlNamespace);				
			}
			else if(member.IsList)
			{
				ProcessList(variableName, member, operation.XmlNamespace);
			}
			else if(member.IsMap)
			{
				throw new NotImplementedException();
			}
			else
			{

        
        #line default
        #line hidden
        
        #line 108 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\tif(");

        
        #line default
        #line hidden
        
        #line 109 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 109 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".IsSet");

        
        #line default
        #line hidden
        
        #line 109 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));

        
        #line default
        #line hidden
        
        #line 109 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("())\r\n\t\t\t\t\txmlWriter.WriteElementString(\"");

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.MarshallName));

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(operation.XmlNamespace));

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", StringUtils.From");

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.GetPrimitiveType()));

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("(");

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));

        
        #line default
        #line hidden
        
        #line 110 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("));\t\t\t\t\t\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 112 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

			}
			
		}  

        
        #line default
        #line hidden
        
        #line 116 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(@"
				xmlWriter.WriteEndElement();
			}
			try 
			{
				string content = stringWriter.ToString();
				request.Content = System.Text.Encoding.UTF8.GetBytes(content);
				request.Headers[""Content-Type""] = ""application/xml"";
			} 
			catch (EncoderFallbackException e) 
			{
				throw new AmazonServiceException(""Unable to marshall request to XML"", e);
			}
");

        
        #line default
        #line hidden
        
        #line 130 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
				       
	}

	void ProcessMembers(string variableName, IEnumerable<Member> members, string xmlNamespace)
	{
		foreach(var member in members)
		{
			if(member.IsStructure)
			{
				ProcessStructure(variableName, member, xmlNamespace);				
			}
			else if(member.IsList)
			{
				ProcessList(variableName, member, xmlNamespace);	
			}
			else if(member.IsMap)
			{
				throw new NotImplementedException();
			}
			else
			{

        
        #line default
        #line hidden
        
        #line 151 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\tif(");

        
        #line default
        #line hidden
        
        #line 152 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 152 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".IsSet");

        
        #line default
        #line hidden
        
        #line 152 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));

        
        #line default
        #line hidden
        
        #line 152 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("())\r\n\t\t\t\t\txmlWriter.WriteElementString(\"");

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.MarshallName));

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlNamespace));

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", StringUtils.From");

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.GetPrimitiveType()));

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("(");

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));

        
        #line default
        #line hidden
        
        #line 153 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("));\t\t\t\t \r\n\r\n");

        
        #line default
        #line hidden
        
        #line 155 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

			}
		}
	}

	void ProcessStructure(string variableName, Member member, string xmlNamespace)
	{
			var shape = member.Shape.IsList ?  member.Shape.ListShape : member.Shape ;
			variableName = member.Shape.IsList ? variableName : variableName + "." + member.PropertyName;

			// Use shape's ListMarshallName if the structure is a list.
			var marshallName = member.Shape.IsList ? member.Shape.ListMarshallName : member.MarshallName;

        
        #line default
        #line hidden
        
        #line 167 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\t\r\n\t\t\t\tif (");

        
        #line default
        #line hidden
        
        #line 168 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 168 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(" != null) \r\n\t\t\t\t{\r\n\t\t\t\t\txmlWriter.WriteStartElement(\"");

        
        #line default
        #line hidden
        
        #line 170 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(marshallName));

        
        #line default
        #line hidden
        
        #line 170 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 170 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlNamespace));

        
        #line default
        #line hidden
        
        #line 170 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\");\t\t\t\r\n");

        
        #line default
        #line hidden
        
        #line 171 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

			PushIndent("	");
			ProcessMembers(variableName, shape.Members, xmlNamespace);
			PopIndent();

        
        #line default
        #line hidden
        
        #line 175 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\t\txmlWriter.WriteEndElement();\r\n\t\t\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 178 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
		
	}

	void ProcessList(string variableName, Member member, string xmlNamespace)
	{
				var listVariable = (variableName + member.PropertyName).Replace(".",string.Empty);
				var listItemVariable = (variableName + member.PropertyName).Replace(".",string.Empty) + "Value";

        
        #line default
        #line hidden
        
        #line 185 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\tvar ");

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listVariable));

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(" = ");

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(variableName));

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));

        
        #line default
        #line hidden
        
        #line 186 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(";\r\n\t\t\t\tif (");

        
        #line default
        #line hidden
        
        #line 187 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listVariable));

        
        #line default
        #line hidden
        
        #line 187 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(" != null && ");

        
        #line default
        #line hidden
        
        #line 187 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listVariable));

        
        #line default
        #line hidden
        
        #line 187 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(".Count > 0) \r\n\t\t\t\t{\t\t\t\t\t\t\r\n\t\t\t\t\txmlWriter.WriteStartElement(\"");

        
        #line default
        #line hidden
        
        #line 189 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.MarshallName));

        
        #line default
        #line hidden
        
        #line 189 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 189 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlNamespace));

        
        #line default
        #line hidden
        
        #line 189 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\");\r\n\t\t\t\t\tforeach (var ");

        
        #line default
        #line hidden
        
        #line 190 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listItemVariable));

        
        #line default
        #line hidden
        
        #line 190 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(" in ");

        
        #line default
        #line hidden
        
        #line 190 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listVariable));

        
        #line default
        #line hidden
        
        #line 190 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(") \r\n\t\t\t\t\t{\r\n");

        
        #line default
        #line hidden
        
        #line 192 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"

			PushIndent("	");			
			if(member.Shape.ListShape.IsStructure)
			{
					ProcessStructure(listItemVariable, member, xmlNamespace);	
			}
			else
			{
					// Use shape's ListMarshallName as it's a list structure.

        
        #line default
        #line hidden
        
        #line 201 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\t\txmlWriter.WriteStartElement(\"");

        
        #line default
        #line hidden
        
        #line 202 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(member.Shape.ListMarshallName));

        
        #line default
        #line hidden
        
        #line 202 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\", \"");

        
        #line default
        #line hidden
        
        #line 202 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlNamespace));

        
        #line default
        #line hidden
        
        #line 202 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\");\r\n                    xmlWriter.WriteValue(");

        
        #line default
        #line hidden
        
        #line 203 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(listItemVariable));

        
        #line default
        #line hidden
        
        #line 203 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write(");\r\n                    xmlWriter.WriteEndElement();\r\n");

        
        #line default
        #line hidden
        
        #line 205 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
				
			}
			PopIndent();			

        
        #line default
        #line hidden
        
        #line 208 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
this.Write("\t\t\t\t\t}\t\t\t\r\n\t\t\t\t\txmlWriter.WriteEndElement();\t\t\t\r\n\t\t\t\t}\r\n");

        
        #line default
        #line hidden
        
        #line 212 "C:\code\dotnet\code-ranger-bug\sdk\src\ServiceClientGenerator\Generators\RestXmlRequestMarshaller.tt"
				
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
