using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class EnableOnlineAccessEvent: Event
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public bool Enable { get; set; }

        public EnableOnlineAccessEvent(Guid messageId, string email, string password, 
            string firstName, string lastName, string userName, string userRole, bool enable) : base(messageId)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            UserRole = userRole;
        }
    }
}
