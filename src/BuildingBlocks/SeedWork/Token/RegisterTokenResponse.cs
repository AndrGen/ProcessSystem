﻿using System.Text.Json.Serialization;

namespace SeedWork.Token
{

    public class RegisterTokenResponse
    {
        [JsonPropertyName("Token")]
        public string Token { get; }

        public RegisterTokenResponse(string token)
        {
            Token = token;
        }
    }
}
