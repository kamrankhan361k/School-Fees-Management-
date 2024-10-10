using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class ContraVouncher
    {
        public int? ContraVoucherID { get; set; }

        public int DepartmentID { get; set; }

        public string VoucherNo { get; set; }

        public int DebitorID { get; set; }

        public int CreditorID { get; set; }

        public int DrAmount { get; set; }

        public int CrAmount { get; set; }

        public string PaymentBy { get; set; }

        public string Narration { get; set; }
    }
}
