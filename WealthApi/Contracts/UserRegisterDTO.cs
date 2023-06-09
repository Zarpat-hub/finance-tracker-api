﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WealthApi.Contracts
{
    public class UserRegisterDTO
    {
        [JsonProperty("username")]
        [Required]
        public string Username { get; set; }

        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }
        
        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
