
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
    public class StandardService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetAllStandard(string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select StandardID,Standard from StandardMaster where IsActive=true";

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

        public Result<bool> DeleteStandardById(int p_Id, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update StandardMaster set IsActive=false,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where StandardID=@StandardID";
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
                    dbCommand.Parameters.AddWithValue("@StandardID", p_Id);

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

                    _HistoryHelper.InsertHistory<int>(p_Id, TableType.StandardMaster, OperationType.Delete, p_Id, p_UserId,p_Year);
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

        public Result<StandardMaster> GetStandardById(int p_Id, string p_Year)
        {
            this.Year = p_Year;
            Result<StandardMaster> _Result = new Result<StandardMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select StandardID,Standard from StandardMaster where StandardID=" + p_Id;

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
                    StandardMaster _StandardMaster = new StandardMaster();

                    _StandardMaster.StandardID = Convert.ToInt32(dataTable.Rows[0]["StandardID"]);
                    _StandardMaster.Standard = Convert.ToString(dataTable.Rows[0]["Standard"]);

                    _Result.Data = _StandardMaster;
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

        public Result<bool> SaveStandard(StandardMaster p_Standard, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into StandardMaster (Standard,CreatedBy,CreatedDate,IsActive)
                                   values (@Standard,@CreatedBy,@CreatedDate,@IsActive)";

                if (p_Standard.StandardID != null)
                {
                    _Query = @"update StandardMaster set Standard=@Standard,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where StandardID=@StandardID";
                }

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@Standard", p_Standard.Standard);

                    if (p_Standard.StandardID == null)
                    {
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                    }
                    else
                    {
                        dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@StandardID", p_Standard.StandardID);
                    }
                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_Standard.StandardID == null)
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
                    _Result.Id = p_Standard.StandardID;

                    if (p_Standard.StandardID == null)
                    {
                        _Result.Id = _ID;
                        _HistoryHelper.InsertHistory<StandardMaster>(_ID, TableType.StandardMaster, OperationType.Insert, p_Standard, p_UserId,p_Year);
                    }
                    else
                    {
                        _HistoryHelper.InsertHistory<StandardMaster>(Convert.ToInt32(p_Standard.StandardID), TableType.StandardMaster, OperationType.Update, p_Standard, p_UserId,p_Year);
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

        public Result<bool> CheckDuplicateStandard(string p_Standard, int? p_StandardId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;
                if (p_StandardId == null)
                {
                    p_StandardId = 0;
                }
                string _Query = "select count(StandardID) from StandardMaster where IsActive=true and Standard=@Standard and StandardID<>@StandardID";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@Standard", p_Standard);
                    dbCommand.Parameters.AddWithValue("@StandardID", p_StandardId);

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
