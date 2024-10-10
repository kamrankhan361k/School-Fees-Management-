using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class History
    {
        public int HistoryID { get; set; }
        public string Description { get; set; }
        public int TableId { get; set; }
        public int TableTypeId { get; set; }
        public int OperationTypeId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string XmlContent { get; set; }
    }
}
