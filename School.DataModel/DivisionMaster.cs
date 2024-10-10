using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class DivisionMaster
    {
        public int? DivisionID { get; set; }
        public string Division { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
