using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "ln")]
        [Description("Location name")]
        public string name { get; set; }

        [DataMember(Name = "coord")]
        [Description("Location Coordinates")]
        public string coordinates { get; set; }

        [DataMember(Name = "address")]
        [Description("Address")]
        public string address { get; set; }
    }
}
