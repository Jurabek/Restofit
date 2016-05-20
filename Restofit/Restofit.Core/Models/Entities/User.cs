namespace Restofit.Core.Models.Entities
{
    public class User
    {
        public User(string authenticationToken)
        {
            AuthenticationToken = authenticationToken;
        }
        public string AuthenticationToken { get; set; }

        public string UserId { get; set; }
    }
}
