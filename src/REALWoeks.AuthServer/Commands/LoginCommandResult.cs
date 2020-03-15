using REALWorks.AuthServer.Models;

namespace REALWorks.AuthServer.Commands
{
    public class LoginCommandResult
    {
        public string token { get; set; }
        public string errorMessage { get; set; }
        public ApplicationUser user { get; set; }
    }
}