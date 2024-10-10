
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
    public class ReceiptService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<Int64> SaveReceipt(List<ReceiptMaster> p_ReceiptMaster, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<Int64> _Result = new Result<Int64>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into ReceiptMaster (FeesId,StudentId,ReceivedBy,ReceivedDate,GivenBy,PayFees,YearId,ReceiptNo,CreatedBy,CreatedDate,IsActive)
                                   values (@FeesId,@StudentId,@ReceivedBy,@ReceivedDate,@GivenBy,@PayFees,@YearId,@ReceiptNo,@CreatedBy,@CreatedDate,@IsActive)";

                int _ID = 0;

                Int64 _ReceiptNo = GetReceiptNo(p_Year) + 1;

                foreach (ReceiptMaster _ReceiptMaster in p_ReceiptMaster)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;

                        dbCommand.Parameters.AddWithValue("@FeesId", _ReceiptMaster.FeesId);
                        dbCommand.Parameters.AddWithValue("@StudentId", _ReceiptMaster.StudentId);
                        dbCommand.Parameters.AddWithValue("@ReceivedBy", _ReceiptMaster.ReceivedBy);
                        dbCommand.Parameters.AddWithValue("@ReceivedDate", _ReceiptMaster.ReceivedDate);
                        dbCommand.Parameters.AddWithValue("@GivenBy", _ReceiptMaster.GivenBy);
                        dbCommand.Parameters.AddWithValue("@PayFees", _ReceiptMaster.PayFees);
                        dbCommand.Parameters.AddWithValue("@YearId", _ReceiptMaster.YearId);
                        dbCommand.Parameters.AddWithValue("@ReceiptNo", _ReceiptNo);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);

                        dbCommand.Connection.Open();
                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        dbCommand.Connection.Close();

                        _HistoryHelper.InsertHistory<ReceiptMaster>(_ID, TableType.ReceiptMaster, OperationType.Insert, _ReceiptMaster, p_UserId, p_Year);
                    }
                }

                _Result.Data = _ReceiptNo;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Int64 GetReceiptNo(string p_Year)
        {
            this.Year = p_Year;
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                string _Query = "select max(ReceiptNo) as ReceiptNo from ReceiptMaster";
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = _Query;
                dbCommand.Connection.Open();

                OleDbDataReader reader = dbCommand.ExecuteReader();

                Int64 _ReceiptNo = 1;
                if (reader.Read())
                {
                    _ReceiptNo = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader["ReceiptNo"]);
                }

                reader.Close();

                return _ReceiptNo;
            }
        }

        public Result<bool> TruncateReceiptMaster(string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "delete from ReceiptMaster";
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    _Flag = rowsAffected > 0;

                    _Query = "alter table ReceiptMaster alter column ReceiptID number";

                    dbCommand.CommandText = _Query;
                    dbCommand.ExecuteNonQuery();

                    _Query = "alter table ReceiptMaster alter column ReceiptID AUTOINCREMENT";

                    dbCommand.CommandText = _Query;
                    dbCommand.ExecuteNonQuery();

                    dbCommand.Connection.Close();
                }

                _Result.Data = true;
                _Result.IsSuccess = true;

            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }
        
        public Result<DataTable> GetReceipt(int p_StudentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select fm.FeesID,fm.DisplayFeesName,r.PayFees,IIf(fm.IsOneTime, 'One Time', 'Monthly') as FeesType,r.ReceivedDate,r.ReceiptNo from FeesMaster fm inner join ReceiptMaster r on fm.FeesID=r.FeesId where fm.IsActive=true and r.IsActive=true and r.StudentId=" + p_StudentId + " and fm.IsOtherFees=" + p_IsOtherFees + " order by r.ReceiptNo,fm.FeesID";

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

        public Result<DataTable> GetAllFeesReceiptByStudentId(int p_StudentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.StudentID,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,dv.Division,r.ReceiptNo,First(r.ReceivedDate) as ReceivedDate,sum(r.PayFees) as PayFees" +
                    @" from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join ReceiptMaster r on r.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=r.FeesId) 
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and r.IsActive=true and fm.IsActive=true and r.StudentId=" + p_StudentId + " and fm.IsOtherFees=" + p_IsOtherFees +
                    " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,d.Department,dv.Division,r.ReceiptNo";

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
        
        public Result<DataTable> GetFeesReceiptByReceiptNo(Int64 p_ReceiptNo, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.StudentID,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,d.Address,dv.Division,Min(fm.MonthNumber) as StartMonthNo,Max(fm.MonthNumber) as EndMonthNo, fm.FeesName,r.ReceiptNo,First(r.ReceivedDate) as [Date],sum(r.PayFees) as Fees,fm.IsOneTime" +
                    @" from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join FeesMaster fm on fm.StandardId=st.StandardId and fm.DepartmentId=st.DepartmentId) inner join ReceiptMaster r on r.StudentId=st.StudentID and r.FeesId=fm.FeesID) 
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and r.IsActive=true and fm.IsActive=true and r.ReceiptNo=" + p_ReceiptNo +
                    " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,d.Department,d.Address,dv.Division,fm.FeesName,r.ReceiptNo,fm.IsOneTime";

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
                    foreach (DataRow _DataRow in dataTable.Rows)
                    {
                        if (!Convert.ToBoolean(_DataRow["IsOneTime"]))
                        {
                            if (Convert.ToInt32(_DataRow["StartMonthNo"]) != Convert.ToInt32(_DataRow["EndMonthNo"]))
                            {
                                _DataRow["FeesName"] = Helper.GetMonthNameByNumber(Convert.ToInt32(_DataRow["StartMonthNo"])) + " થી " + Helper.GetMonthNameByNumber(Convert.ToInt32(_DataRow["EndMonthNo"]));
                            }
                            else
                            {
                                _DataRow["FeesName"] = Helper.GetMonthNameByNumber(Convert.ToInt32(_DataRow["StartMonthNo"]));
                            }
                        }
                    }

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

        public Result<DataTable> GetAllFeesReceipt( string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.StudentID,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,dv.Division,r.ReceiptNo,First(r.ReceivedDate) as ReceivedDate,sum(r.PayFees) as PayFees,IIf(fm.IsOtherFees, 'Other', 'Regular') as FeesType,r.ReceivedBy" +
                    @" from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join ReceiptMaster r on r.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=r.FeesId) 
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and r.IsActive=true and fm.IsActive=true"+
                    " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,s.Standard,d.Department,dv.Division,r.ReceiptNo,fm.IsOtherFees,r.ReceivedBy order by r.ReceiptNo desc";

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

        public Result<bool> SaveReceiptDetails(List<ReceiptDetail> p_ReceiptDetail, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into ReceiptDetails (ReceiptId,PaymentType,CreditAmount,DebitAmount,Narration,VoucherTypeID)
                                                     values (@ReceiptId,@PaymentType,@CreditAmount,@DebitAmount,@Narration,@VoucherTypeID)";

                int _ID = 0;

                foreach (ReceiptDetail _ReceiptDetail in p_ReceiptDetail)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;

                        dbCommand.Parameters.AddWithValue("@ReceiptId", _ReceiptDetail.ReceiptID);
                        dbCommand.Parameters.AddWithValue("@PaymentType", _ReceiptDetail.PaymentType);
                        dbCommand.Parameters.AddWithValue("@CreditAmount", _ReceiptDetail.CreditAmount);
                        dbCommand.Parameters.AddWithValue("@DebitAmount", _ReceiptDetail.DebitAmount);
                        dbCommand.Parameters.AddWithValue("@Narration", _ReceiptDetail.Narration);
                        dbCommand.Parameters.AddWithValue("@VoucherTypeID", _ReceiptDetail.VoucherTypeId);

                        dbCommand.Connection.Open();
                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        dbCommand.Connection.Close();

                        _HistoryHelper.InsertHistory<ReceiptDetail>(_ID, TableType.ReceiptDetail, OperationType.Insert, _ReceiptDetail, p_UserId, p_Year);
                    }
                }
               
                _Result.IsSuccess = true;
                _Result.Data = true;
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
