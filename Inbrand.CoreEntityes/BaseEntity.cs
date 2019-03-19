using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.CoreEntityes
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedById { get; set; }
        //public ApplicationUser CreatedBy { get; set; }
        public string ModifiedById { get; set; }
        //public AppUser ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
