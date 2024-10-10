using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class FeesMaster
    {
        public int? FeesID { get; set; }
        public int StandardId { get; set; }
        public string Standard { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string FeesName { get; set; }
        public string DisplayFeesName { get; set; }
        public decimal Fees { get; set; }
        public bool IsOneTime { get; set; }
        public string FeesType { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsOtherFees { get; set; }
        public int MonthNumber { get; set; }
    }
}
