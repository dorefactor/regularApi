using System.Collections.Generic;
using Newtonsoft.Json;

namespace RegularApi.Domain.Views.Docker
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DockerApplicationSetupView : ApplicationSetupView
    {
        [JsonProperty(PropertyName = "registry")]
        public RegistryView RegistryView { get; set; }

        [JsonProperty(PropertyName = "image")]
        public ImageView ImageView { get; set; }

        public IDictionary<string, string> Ports { get; set; }

        public IDictionary<string, string> EnvironmentVariables { get; set; }

        public IDictionary<string, string> ExtraHosts { get; set; }

        public IDictionary<string, string> Volumes { get; set; }
    }
}