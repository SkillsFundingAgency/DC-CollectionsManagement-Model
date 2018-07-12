using System;
using System.Reflection;

namespace ESFA.DC.CollectionsManagement.Models
{
    public class Organisation
    {
        public string OrgId { get; set; }
        public long Ukrpn { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
