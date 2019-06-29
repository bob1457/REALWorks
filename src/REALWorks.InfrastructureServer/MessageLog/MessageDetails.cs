using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.InfrastructureServer.MessageLog
{
    public class MessageDetails
    {
        public int PrincicipalId { get; set; } 
        public string PrincipalType { get; set; }
        public string PrincipalNameDesc { get; set; }
        public string OperationType { get; set; }        

    }
}
