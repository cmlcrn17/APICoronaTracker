using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APICoronaTracker.Models
{
    [DataContract]
    public class CoronaCountryDataset
    {
        [DataMember(Name = "success")]
        public string Success { get; set; }

        [DataMember(Name = "result")]
        public List<CoronaCountry> Result { get; set; }
        
    }
}