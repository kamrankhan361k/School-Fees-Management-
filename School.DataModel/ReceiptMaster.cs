using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class ReceiptMaster
    {
        public int? ReceiptID { get; set; }
        public int FeesId { get; set; }
        public int StudentId { get; set; }
        public decimal PayFees { get; set; }
        public string ReceivedBy { get; set; }
        public string ReceivedDate { get; set; }
        public string GivenBy { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int YearId { get; set; }
        public int ReceiptNo { get; set; }
       
    }
}
