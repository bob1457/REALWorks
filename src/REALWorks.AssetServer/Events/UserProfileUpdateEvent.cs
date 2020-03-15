using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class UserProfileUpdateEvent : Event
    {
        public UserProfileUpdateEvent(Guid messageId, string userName, 
            string firstName, string lastName, string email, 
            int customId, string telephone1, 
            string telephone2, string socialMediaContact1, 
            string socialMediaContact2, string addressStreet, 
            string addressCity, string addressProvState, string addressPostZipCode, string addressCountry) : base(messageId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CustomId = customId;            
            Telephone1 = telephone1;
            Telephone2 = telephone2;
            SocialMediaContact1 = socialMediaContact1;
            SocialMediaContact2 = socialMediaContact2;
            AddressStreet = addressStreet;
            AddressCity = addressCity;
            AddressProvState = addressProvState;
            AddressPostZipCode = addressPostZipCode;
            AddressCountry = addressCountry;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomId { get; set; }
        //public string AvatarImgUrl { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string SocialMediaContact1 { get; set; }
        public string SocialMediaContact2 { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvState { get; set; }
        public string AddressPostZipCode { get; set; }
        public string AddressCountry { get; set; }
    }
}
