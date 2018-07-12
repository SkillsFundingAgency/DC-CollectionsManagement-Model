using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.CollectionsManagement.Models
{
    public class Collection
    {
        public string Name { get; set; }
        public CollectionTypes Type { get; set; }
        public bool IsOpen { get; set; }
    }
}
