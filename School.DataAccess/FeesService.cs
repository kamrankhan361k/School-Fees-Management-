
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
    public class FeesService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetAllFees(bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select f.FeesID,f.DisplayFeesName, f.FeesName,f.Fees,f.IsOneTime,IIf(f.IsOneTime, 'One Time', 'Monthly') as FeesType,s.Standard,d.Department from (FeesMaster f inner join StandardMaster s on f.StandardId=s.StandardID) inner join DepartmentMaster d on f.DepartmentId=d.DepartmentID where f.IsActive=true and s.IsActive=true and d.IsActive=true and IsOtherFees=" + p_IsOtherFees;

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

        public Result<bool> DeleteFeesById(int p_Id, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update FeesMaster set IsActive=false,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where FeesID=@FeesID";
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                    dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@FeesID", p_Id);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();
                    _Flag = rowsAffected > 0;
                }

                if (_Flag)
                {
                    _Result.Data = true;
                    _Result.IsSuccess = true;

                    _HistoryHelper.InsertHistory<int>(p_Id, TableType.FeesMaster, OperationType.Delete, p_Id, p_UserId, p_Year);
                }
                else
                {
                    _Result.Message = Messages.ExceptionMsg;
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

        public Result<FeesMaster> GetFeesById(int p_Id, string p_Year)
        {
            this.Year = p_Year;
            Result<FeesMaster> _Result = new Result<FeesMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select FeesID,StandardId,FeesName,DisplayFeesName,Fees,DepartmentId from FeesMaster where FeesID=" + p_Id;

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
                    FeesMaster _FeesMaster = new FeesMaster();

                    _FeesMaster.FeesID = Convert.ToInt32(dataTable.Rows[0]["FeesID"]);
                    _FeesMaster.StandardId = Convert.ToInt32(dataTable.Rows[0]["StandardId"]);
                    _FeesMaster.FeesName = Convert.ToString(dataTable.Rows[0]["FeesName"]);
                    _FeesMaster.DisplayFeesName = Convert.ToString(dataTable.Rows[0]["DisplayFeesName"]);
                    _FeesMaster.Fees = Convert.ToDecimal(dataTable.Rows[0]["Fees"]);
                    _FeesMaster.DepartmentId = Convert.ToInt32(dataTable.Rows[0]["DepartmentId"]);

                    _Result.Data = _FeesMaster;
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

        public Result<bool> SaveFees(FeesMaster p_FeesMaster, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into FeesMaster (FeesName,StandardId,DepartmentId,Fees,IsOneTime,IsOtherFees,CreatedBy,CreatedDate,IsActive,DisplayFeesName,MonthNumber)
                                   values (@FeesName,@StandardId,@DepartmentId,@Fees,@IsOneTime,@IsOtherFees,@CreatedBy,@CreatedDate,@IsActive,@DisplayFeesName,@MonthNumber)";

                if (p_FeesMaster.FeesID != null)
                {
                    _Query = @"update FeesMaster set FeesName=@FeesName,StandardId=@StandardId,DepartmentId=@DepartmentId,Fees=@Fees,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where FeesID=@FeesID";
                }

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@FeesName", p_FeesMaster.FeesName);
                    dbCommand.Parameters.AddWithValue("@StandardId", p_FeesMaster.StandardId);
                    dbCommand.Parameters.AddWithValue("@DepartmentId", p_FeesMaster.DepartmentId);
                    dbCommand.Parameters.AddWithValue("@Fees", p_FeesMaster.Fees);

                    if (p_FeesMaster.FeesID == null)
                    {
                        dbCommand.Parameters.AddWithValue("@IsOneTime", p_FeesMaster.IsOneTime);
                        dbCommand.Parameters.AddWithValue("@IsOtherFees", p_FeesMaster.IsOtherFees);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                        dbCommand.Parameters.AddWithValue("@DisplayFeesName", p_FeesMaster.DisplayFeesName);
                        dbCommand.Parameters.AddWithValue("@MonthNumber", p_FeesMaster.MonthNumber);
                    }
                    else
                    {
                        dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@FeesID", p_FeesMaster.FeesID);
                    }
                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_FeesMaster.FeesID == null)
                    {
                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();
                    }

                    dbCommand.Connection.Close();
                    _Flag = rowsAffected > 0;
                }

                if (_Flag)
                {
                    _Result.Data = true;
                    _Result.IsSuccess = true;

                    if (p_FeesMaster.FeesID == null)
                    {
                        _HistoryHelper.InsertHistory<FeesMaster>(_ID, TableType.FeesMaster, OperationType.Insert, p_FeesMaster, p_UserId, p_Year);
                    }
                    else
                    {
                        _HistoryHelper.InsertHistory<FeesMaster>(Convert.ToInt32(p_FeesMaster.FeesID), TableType.FeesMaster, OperationType.Update, p_FeesMaster, p_UserId, p_Year);
                    }
                }
                else
                {
                    _Result.Message = Messages.ExceptionMsg;
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

        public Result<bool> CheckDuplicateFees(FeesMaster p_FeesMaster, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;
                if (p_FeesMaster.FeesID == null)
                {
                    p_FeesMaster.FeesID = 0;
                }
                string _Query = "select count(FeesID) from FeesMaster where IsActive=true and FeesName=@FeesName and DisplayFeesName=@DisplayFeesName and StandardId=@StandardId and DepartmentId=@DepartmentId and IsOtherFees=@IsOtherFees and FeesID<>@FeesID";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@FeesName", p_FeesMaster.FeesName);
                    dbCommand.Parameters.AddWithValue("@DisplayFeesName", p_FeesMaster.DisplayFeesName);
                    dbCommand.Parameters.AddWithValue("@StandardId", p_FeesMaster.StandardId);
                    dbCommand.Parameters.AddWithValue("@DepartmentId", p_FeesMaster.DepartmentId);
                    dbCommand.Parameters.AddWithValue("@IsOtherFees", p_FeesMaster.IsOtherFees);
                    dbCommand.Parameters.AddWithValue("@FeesID", p_FeesMaster.FeesID);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var _Count = dbCommand.ExecuteScalar();
                    dbCommand.Connection.Close();

                    _Result.IsSuccess = true;
                    if (Convert.ToInt32(_Count) > 0)
                    {
                        _Result.Data = true;
                    }
                    else
                    {
                        _Result.Data = false;
                    }
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

        public Result<bool> CheckFeesReferences(int p_FeesId, decimal p_Fees, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "select count(CollectFeesID) from CollectFeesMaster where IsActive=true and FeesId=" + p_FeesId + " and PayFees>" + p_Fees;

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Connection.Open();
                    var _Count = dbCommand.ExecuteScalar();
                    dbCommand.Connection.Close();

                    _Result.IsSuccess = true;
                    if (Convert.ToInt32(_Count) > 0)
                    {
                        _Result.Data = true;
                    }
                    else
                    {
                        _Result.Data = false;
                    }
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

        public Result<DataTable> GetAllFeesByStandardDepartment(int p_StandardId, int p_DepartmentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select FeesID,DisplayFeesName,FeesName,Fees from FeesMaster where IsActive=true and StandardId=" + p_StandardId + " and DepartmentId=" + p_DepartmentId + " and IsOtherFees=" + p_IsOtherFees + " order by FeesID";

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


    }
}
