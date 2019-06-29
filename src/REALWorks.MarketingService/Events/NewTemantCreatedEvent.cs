using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Events
{
    public class NewTemantCreatedEvent: Event
    {
        public NewTemantCreatedEvent( Guid messageId, string userName, string firstName, string lastName, 
            string contactEmail, string contactTelephone1, string contactTelephone2, string contactOthers) : base(messageId)
        {           
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            ContactOthers = contactOthers;
        }

        public string UserName { get; }
        public string FirstName { get;  }
        public string LastName { get;  }
        public string ContactEmail { get; }
        public string ContactTelephone1 { get; }
        public string ContactTelephone2 { get; }
        public string ContactOthers { get; }

    }
}
