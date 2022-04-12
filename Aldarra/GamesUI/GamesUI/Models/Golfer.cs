using GamesUI.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesUI.Models
{
    public class Golfer
    {
        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "firstName", Required = Required.Always)]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [JsonProperty(PropertyName = "gender", Required = Required.Always)]
        public Gender Gender { get; set; }
        [JsonProperty(PropertyName = "handicapIndex", Required = Required.Always)]
        public double HandicapIndex { get; set; }
    }
}
