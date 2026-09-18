using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSONчики
{
    public class Software
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public bool Installed { get; set; }

        public List<string> Tags { get; set; } = new();

        [JsonIgnore]
        public string DisplayName => $"{Name} ({Version})";

        [JsonInclude]
        public string Category = string.Empty;
    }
}
