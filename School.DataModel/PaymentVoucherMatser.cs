using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNMehta_School.DataModel
{
    public class PaymentVoucherMatser
    {
        public int? PaymentVoucherId { get; set; }

        public int DepartmentID { get; set; }

        public string Department { get; set; }
     
        public int LedgerID { get; set; }

        public string Ledger { get; set; }

        public decimal VoucherNo { get; set; }

        public int VoucherType { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Dr { get; set; }

        public string Cr { get; set; }

        public decimal DrAmount { get; set; }

        public decimal CrAmount { get; set; }

        public decimal DrTotalAmount { get; set; }

        public decimal CrTotalAmount { get; set; }

        public string PaymentTo { get; set; }

        public string Narration { get; set; }                              
    }
}

