using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class JournalVoucher
    {
        public int? JournalVoucherId { get; set; }

        public string VoucherNo { get; set; }

        public int DrDepartmentID { get; set; }

        public int CrDepartmentID { get; set; }

        public int DrLedgerID { get; set; }

        public int CrLedgerID { get; set; }

        public int DrAmount { get; set; }

        public int CrAmount { get; set; }

        public string Narration { get; set; }
    }
}
