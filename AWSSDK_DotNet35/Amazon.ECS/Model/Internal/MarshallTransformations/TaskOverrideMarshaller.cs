/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the ecs-2014-11-13.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.ECS.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.ECS.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// TaskOverride Marshaller
    /// </summary>       
    public class TaskOverrideMarshaller : IRequestMarshaller<TaskOverride, JsonMarshallerContext> 
    {
        public void Marshall(TaskOverride requestObject, JsonMarshallerContext context)
        {
            if(requestObject.IsSetContainerOverrides())
            {
                context.Writer.WritePropertyName("containerOverrides");
                context.Writer.WriteArrayStart();
                foreach(var requestObjectContainerOverridesListValue in requestObject.ContainerOverrides)
                {
                    context.Writer.WriteObjectStart();

                    var marshaller = ContainerOverrideMarshaller.Instance;
                    marshaller.Marshall(requestObjectContainerOverridesListValue, context);

                    context.Writer.WriteObjectEnd();
                }
                context.Writer.WriteArrayEnd();
            }

        }

        public readonly static TaskOverrideMarshaller Instance = new TaskOverrideMarshaller();

    }
}