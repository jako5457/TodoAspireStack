using System.Text.Json.Serialization;

namespace Todo.WebApp.Models.Login
{
    public class LoginInformation
    {
        public string tokenType { get; set; }

        public string accessToken { get; set; }

        public ulong expiresIn { get; set; }

        public string refreshToken { get; set; }

        [JsonIgnore]
        public DateTime Recieved { get; set; } = DateTime.Now;

        public bool TokenHasExpired()
        {
            DateTime expiredDate = Recieved.AddMilliseconds(expiresIn);

            return DateTime.Now < expiredDate;
        }
    }
}
