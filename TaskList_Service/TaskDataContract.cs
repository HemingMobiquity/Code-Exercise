using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TaskList_Service
{
    [DataContract]
    public class TaskDataContract
    {
        [DataMember]
        public string TaskID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}