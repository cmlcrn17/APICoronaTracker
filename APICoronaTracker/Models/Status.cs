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
        [DataMember(Name = "success")]//Success
        public string Success { get; set; }

        [DataMember(Name = "result")]//Result
        public List<CoronaCountry> Result { get; set; }
        
    }
}