using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MobileAppDevFinalProject
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class NotBoringActivity
    {
        [JsonProperty(PropertyName = "activity")]
        public string Activity { get; set; }

        [JsonProperty(PropertyName = "accessibility")]
        public string Accessibility { get; set; }
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "participants")]
        public string Participants { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

    }
}
