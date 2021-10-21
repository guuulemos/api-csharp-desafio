using System.Text.Json.Serialization;

namespace Desafio.Domain.Entidades
{
    public class UserAuth
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
    }
}
