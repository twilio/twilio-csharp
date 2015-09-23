using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Twilio.TaskRouter
{
    [DataContract]
    public class WorkflowConfiguration
    {
        public static WorkflowConfiguration Create(string configuration)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(configuration);
            sw.Flush();

            ms.Position = 0;
            var serializer = new DataContractJsonSerializer(typeof(WorkflowConfiguration));
            var wc = (WorkflowConfiguration)serializer.ReadObject(ms);
            return wc;
        }

        public WorkflowConfiguration()
        {
            this.Filters = new List<Filter>();
        }

        [DataMember(EmitDefaultValue = false, Name="filters")]
        public List<Filter> Filters {get;set;}

        [DataMember(EmitDefaultValue = false, Name="default_filter")]
        public Target DefaultFilter { get; set; }

        public override string ToString()
        {
            var ms = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(WorkflowConfiguration));
            serializer.WriteObject(ms, this);

            ms.Position = 0;
            var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }
    }
}
