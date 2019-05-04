﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace RegularApi.Domain.Views.Jenkins
{
    public class AnsibleSetup
    {
        [JsonProperty(PropertyName = "Groups")]
        public IList<AnsibleGroup> AnsibleGroups { get; set; }
    }
}