using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class PaymentVoucher
    {
        public int? PaymentVoucherId { get; set; }

        public int DepartmentId { get; set; }

        public string VoucherNo { get; set; }

        public int DebitorID { get; set; }

        public int CreditorID { get; set; }

        public int DrAmount { get; set; }

        public int CrAmount { get; set; }

        public string PaymentTo { get; set; }

        public string Narration { get; set; }
    }
}
