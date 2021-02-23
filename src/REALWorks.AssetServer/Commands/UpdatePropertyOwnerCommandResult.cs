using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class UpdatePropertyOwnerCommandResult
    {
        public int Id { get; set; }
        //public int PropertyId { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        //public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool IsActive { get; set; }
        //public int RoleId { get; set; }
        public string Notes { get; set; }
        //public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostCode { get; set; }
        public string Country { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Updated { get; set; }

        public UpdatedOwnerAddress Address { get; set; }

        public IList<OwnerProperty> OwnerProperty { get; set; }

        //public Address Address { get; set; }
    }

    //public class Address {

    //    public string StreetNUmber { get; set; }
    //    public string City { get; set; }
    //    public string StateProvince { get; set; }
    //    public string ZipPostCode { get; set; }
    //    public string Country { get; set; }


    //}
}
