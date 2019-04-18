using System;
using Newtonsoft.Json;

namespace DreamR.Features.Authentication
{
  public class TokenViewModel
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("access_token_expiration")]
    public DateTime AccessTokenExpiration { get; set; }
    public string UserName { get; set; }
    
  }
}