using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

    public class Software
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; } 

        public string Version { get; set; } 

        public bool Installed { get; set; }

        public List<string> Tags { get; set; } = new();

        [JsonIgnore]
        public string DisplayName => $"{Name} ({Version})";

        [JsonInclude]
        public string Category = string.Empty;
    }

