using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeAuthService.Models.DTO
{
    public class AuthDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
        public string CustomerId => Id;
    }
}
