using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common
{
    public enum UserType
    {
        SuperAdmin = 1,
        User = 2
    };

    public enum OperationType
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Active = 4,
        Complete=5,
        UpProcess = 5
    };

    public enum VoucherType
    {
        PaymentVoucher=1,
        ContraVoucher=2,
        JournalVoucher=3,
        OtherReceiptVoucher=4,
    };

    public enum TableType
    {
        UserMaster = 1,
        StandardMaster = 2,
        DivisionMaster=3,
        YearMaster=4,
        DepartmentMaster=5,
        FeesMaster=6,
        StudentMaster = 7,
        CollectFeesMaster = 8,
        PrintSettingMaster=9,
        ReceiptMaster=10,
        PaymentVoucherMaster=11,
        LedgerMatser=12,
        ReceiptDetail =13,
        LedgerDetail = 14,
        LeagerHeaderMaster=15,
        PaymentVoucher = 16,
        JournalVoucher = 17,
        ContraVoucher = 18,
        OtherReceiptVoucher = 19,
    };

    public enum PaymentType
    {
        [Description("1")]
        Cash = 1,
        [Description("2")]
        Bank = 2,
        [Description("3")]
        Waiver = 3,
    };

    public enum VoucherPrefix
    {
        PV = 1,
        CV = 2,
        JV = 3,
        OR = 4,
    };

    public enum VoucherID
    {
        PaymentVoucherId = 1,
        ContraVoucherId = 2,
        JournalVoucherId = 3,
        OtherReceiptId = 4,
    };    
}
