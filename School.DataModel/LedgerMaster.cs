using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class LedgerMaster
    {

       
        public int? LedgerID { get; set; }
        public int LedgerHeaderID { get; set; }
        public string LedgerType { get; set; }
        public string Ledger { get; set; }
        public decimal OpeningBalance { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

    }
}
