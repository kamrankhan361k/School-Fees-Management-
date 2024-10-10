using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class PrintSettingMaster
    {
        public int? PrintSettingID { get; set; }
        public string OutPutFormat { get; set; }
        public decimal PageHeight { get; set; }
        public decimal PageWidth { get; set; }
        public decimal MarginTop { get; set; }
        public decimal MarginLeft { get; set; }
        public decimal MarginRight { get; set; }
        public decimal MarginBottom { get; set; }
       
    }
}
