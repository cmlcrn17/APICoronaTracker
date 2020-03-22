using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APICoronaTracker.Models
{
    [DataContract]
    public class CoronaCountry
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "totalcases")]
        public string TotalCases { get; set; }

        [DataMember(Name = "newCases")]
        public string NewCases { get; set; }

        [DataMember(Name = "totaldeaths")]
        public string TotalDeaths { get; set; }

        [DataMember(Name = "newDeaths")]
        public string NewDeaths { get; set; }

        [DataMember(Name = "totalRecovered")]
        public string TotalRecovered { get; set; }

        [DataMember(Name = "activeCases")]
        public string ActiveCases { get; set; }
        
    }
}