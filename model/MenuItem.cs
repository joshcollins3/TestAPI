using System;
using System.Collections.Generic;
namespace testAPI.model
{
    public class MenuItem
    {
        public int Id {get; set; }
        public int ExternalId {get; set; }
        public int? ParentMenuId {get; set; }
        public string Name {get; set; }
        public string MenuKey {get; set; }
        public string Url {get; set; }
        public int CreatedBy {get; set; }
        public DateTime CreatedDate {get; set; }
        public int? UpdatedBy {get; set; }
        public DateTime? UpdatedDate {get; set; }
        public bool Deleted {get; set; }
        public int DisplayOrder {get; set;}
        public IEnumerable<MenuItem> Children;
    
    }
}