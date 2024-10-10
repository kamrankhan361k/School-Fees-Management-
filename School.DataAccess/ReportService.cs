
using School.Common;
using School.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class ReportService : ConnectionAccess
    {
        public Result<DataTable> GetAllFeesReceiptByDateWise(DateTime p_FromDate, DateTime p_ToDate, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,dv.Division,r.ReceiptNo,First(r.ReceivedDate) as ReceivedDate,sum(r.PayFees) as Fees" +
                    @" from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join ReceiptMaster r on r.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=r.FeesId) 
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and r.IsActive=true and fm.IsActive=true and fm.IsOtherFees=" + p_IsOtherFees + " and Format(r.ReceivedDate,'yyyy-MM-dd')>=@FromDate and Format(r.ReceivedDate,'yyyy-MM-dd')<=@ToDate" +
                    " group by st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,d.Department,dv.Division,r.ReceiptNo";

                    // Create the command and set its properties
                    OleDbCommand dbCommand = new OleDbCommand();
                    dataAdapter.SelectCommand = dbCommand;
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    dbCommand.Parameters.AddWithValue("@FromDate", p_FromDate.ToString("yyyy-MM-dd"));
                    dbCommand.Parameters.AddWithValue("@ToDate", p_ToDate.ToString("yyyy-MM-dd"));
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetAllPendingFeesStudent(string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select * from (select st.StudentID,st.StandardId,st.DivisionId,st.DepartmentId,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,IIf(st.Gender, 'Male', 'FeMale') as Gender,s.Standard,d.Department,dv.Division, sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees,Max(cf.ModifiedDate) as ReceivedDate from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=cf.FeesId) where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and cf.IsActive=true and fm.IsActive=true group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,st.Gender,s.Standard,d.Department,dv.Division,st.StandardId,st.DivisionId,st.DepartmentId) fmm where fmm.PendingFees>0 order by fmm.StandardId, fmm.PendingFees desc";

                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetAllFeesDetailByStandardWise(string p_Standard, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select * from (select st.StudentID,st.StandardId,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,dv.Division, sum(cf.Fees) as TotalFees, sum(cf.PayFees) as Fees,sum(cf.PendingFees) as PendingFees,Max(cf.ModifiedDate) as ReceivedDate from ((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=cf.FeesId) where st.IsActive=true and s.IsActive=true and dv.IsActive=true and cf.IsActive=true and fm.IsActive=true and s.Standard in(" + p_Standard + ") and fm.IsOtherFees=" + p_IsOtherFees + " group by st.StudentID,st.StandardId,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,dv.Division) fmm order by fmm.PendingFees desc";

                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetAllFeesReceiptByReceiptWise(DateTime p_FromDate, DateTime p_ToDate, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.StudentID,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,dv.Division,r.ReceiptNo,First(r.ReceivedDate) as ReceivedDate,sum(r.PayFees) as Fees,IIf(fm.IsOtherFees, 'Other', 'Regular') as FeesType" +
                   @" from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join ReceiptMaster r on r.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=r.FeesId) 
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and r.IsActive=true and fm.IsActive=true and fm.IsOtherFees=" + p_IsOtherFees + " and Format(r.ReceivedDate,'yyyy-MM-dd')>=@FromDate and Format(r.ReceivedDate,'yyyy-MM-dd')<=@ToDate" +
                   " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,d.Department,dv.Division,r.ReceiptNo,fm.IsOtherFees order by r.ReceiptNo desc";

                    // Create the command and set its properties
                    OleDbCommand dbCommand = new OleDbCommand();
                    dataAdapter.SelectCommand = dbCommand;
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    dbCommand.Parameters.AddWithValue("@FromDate", p_FromDate.ToString("yyyy-MM-dd"));
                    dbCommand.Parameters.AddWithValue("@ToDate", p_ToDate.ToString("yyyy-MM-dd"));
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetBalanceSheetData(string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select DrAmount,CrAmount,CreatedDate,PaymentTo As Description from PaymentVoucher where IsActive=true UNION ALL
                                      select DrAmount,CrAmount,CreatedDate,Narration As Description from JournalVoucher where IsActive=true UNION ALL
                                      select DrAmount,CrAmount,CreatedDate,Narration As Description from ContraVoucher where IsActive=true UNION ALL
                                      select DrAmount,CrAmount,CreatedDate,Narration As Description from OtherReceiptVoucher where IsActive=true UNION ALL
                                      select DebitAmount as DrAmount,CreditAmount as CrAmount,rm.ReceivedDate,Narration as Description from ReceiptDetails r inner join ReceiptMaster rm on r.ReceiptId=rm.ReceiptID where rm.IsActive=true";

                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetStudentSummaryData(string p_Year, string p_Standard, string p_Department, bool p_All)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"Select GRNumber as GRNo, LastName + ' ' + FirstName + ' ' + MiddleName as StudentName,Gender,BirthDate,Category,MobileNo as Mobile From StudentMaster
                                    where StandardId = @StandardId and  DivisionId = @DivisionId and IsActive=true ORDER BY Gender DESC, GRNumber";

                    if (p_All)
                    {
                        _Query = @"Select GRNumber as GRNo, LastName + ' ' + FirstName + ' ' + MiddleName as StudentName,Gender,BirthDate,Category,MobileNo as Mobile From StudentMaster
                                    where IsActive=true ORDER BY Gender DESC, GRNumber";
                    }
                    
                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    if (!p_All)
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@StandardId", p_Standard);
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@DivisionId", p_Department);
                    }                    

                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                }

                if (dataTable != null)
                {
                    _Result.Data = dataTable;
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.NoRecordMsg;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }
    }
}
