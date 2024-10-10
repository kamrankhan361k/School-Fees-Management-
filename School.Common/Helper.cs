using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace School.Common
{
    public static class Helper
    {
        public static string GetEnumDescription(Enum p_Value)
        {
            FieldInfo _FieldInfo = p_Value.GetType().GetField(p_Value.ToString());

            DescriptionAttribute[] _Attributes =
                (DescriptionAttribute[])_FieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (_Attributes != null &&
                _Attributes.Length > 0)
                return _Attributes[0].Description;
            else
                return p_Value.ToString();
        }

        public static bool CheckRequired(string p_Input, ref string p_Message, string p_FieldName)
        {
            if (string.IsNullOrEmpty(p_Input))
            {
                p_Message += "\n ---> Enter " + p_FieldName + "!";
                return false;
            }

            return true;
        }

        public static string GetMonthNameByNumber(int p_Number)
        {
            string _Month = string.Empty;

            switch (p_Number)
            {
                case 8:
                    _Month = "જાન્યુઆરી";
                    break;
                case 9:
                    _Month = "ફેબ્રુઆરી";
                    break;
                case 10:
                    _Month = "માર્ચ";
                    break;
                case 11:
                    _Month = "એપ્રિલ";
                    break;
                case 12:
                    _Month = "મે";
                    break;
                case 1:
                    _Month = "જુન";
                    break;
                case 2:
                    _Month = "જુલાઈ";
                    break;
                case 3:
                    _Month = "ઓગસ્ટ";
                    break;
                case 4:
                    _Month = "સપ્ટેમ્બર";
                    break;
                case 5:
                    _Month = "ઓક્ટોબર";
                    break;
                case 6:
                    _Month = "નવેમ્બર";
                    break;
                case 7:
                    _Month = "ડીસેમ્બર";
                    break;
            }

            return _Month;
        }

        public static bool IsEditDeletePower(string p_UserName)
        {
            bool _IsPower = true;

            if (p_UserName.ToLower() == ConfigurationManager.AppSettings["NoPower"].ToString().ToLower())
            {
                _IsPower = false;
            }

            return _IsPower;
        }
    }
}
