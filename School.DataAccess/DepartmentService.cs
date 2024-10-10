
using School.Common;
using School.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace School.DataAccess
{
    public class DepartmentService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetAllDepartment(string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select DepartmentID,Department,Address from DepartmentMaster where IsActive=true";

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

        public Result<bool> DeleteDepartmentById(int p_Id, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update DepartmentMaster set IsActive=false,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where DepartmentID=@DepartmentID";
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
                    dbCommand.Parameters.AddWithValue("@DepartmentID", p_Id);

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

                    _HistoryHelper.InsertHistory<int>(p_Id, TableType.DepartmentMaster, OperationType.Delete, p_Id, p_UserId,p_Year);
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

        public Result<DepartmentMaster> GetDepartmentById(int p_Id, string p_Year)
        {
            this.Year = p_Year;
            Result<DepartmentMaster> _Result = new Result<DepartmentMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select DepartmentID,Department,Address from DepartmentMaster where DepartmentID=" + p_Id;

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
                    DepartmentMaster _DepartmentMaster = new DepartmentMaster();

                    _DepartmentMaster.DepartmentID = Convert.ToInt32(dataTable.Rows[0]["DepartmentID"]);
                    _DepartmentMaster.Department = Convert.ToString(dataTable.Rows[0]["Department"]);
                    _DepartmentMaster.Address = Convert.ToString(dataTable.Rows[0]["Address"]);

                    _Result.Data = _DepartmentMaster;
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

        public Result<bool> SaveDepartment(DepartmentMaster p_Department, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into DepartmentMaster (Department,Address,CreatedBy,CreatedDate,IsActive)
                                   values (@Department,@Address,@CreatedBy,@CreatedDate,@IsActive)";

                if (p_Department.DepartmentID != null)
                {
                    _Query = @"update DepartmentMaster set Department=@Department,Address=@Address,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where DepartmentID=@DepartmentID";
                }

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@Department", p_Department.Department);
                    dbCommand.Parameters.AddWithValue("@Address", p_Department.Address);

                    if (p_Department.DepartmentID == null)
                    {
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                    }
                    else
                    {
                        dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@DepartmentID", p_Department.DepartmentID);
                    }
                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_Department.DepartmentID == null)
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
                    _Result.Id = p_Department.DepartmentID;

                    if (p_Department.DepartmentID == null)
                    {
                        _Result.Id = _ID;
                        _HistoryHelper.InsertHistory<DepartmentMaster>(_ID, TableType.DepartmentMaster, OperationType.Insert, p_Department, p_UserId,p_Year);
                    }
                    else
                    {
                        _HistoryHelper.InsertHistory<DepartmentMaster>(Convert.ToInt32(p_Department.DepartmentID), TableType.DepartmentMaster, OperationType.Update, p_Department, p_UserId,p_Year);
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

        public Result<bool> CheckDuplicateDepartment(string p_Department, int? p_DepartmentId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;
                if (p_DepartmentId == null)
                {
                    p_DepartmentId = 0;
                }
                string _Query = "select count(DepartmentID) from DepartmentMaster where IsActive=true and Department=@Department and DepartmentID<>@DepartmentID";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@Department", p_Department);
                    dbCommand.Parameters.AddWithValue("@DepartmentID", p_DepartmentId);

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
    }
}
