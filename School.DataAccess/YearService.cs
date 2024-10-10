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
    public class YearService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetAllYear()
        {
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select YearID,Year,DisplayYear from YearMaster where IsActive=true order by Year Desc";

                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionStringMaster);
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

        public Result<bool> CheckDuplicateYear(string p_Year)
        {
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "select count(YearID) from YearMaster where IsActive=true and Year=@Year";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionStringMaster);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@Year", p_Year);

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

        public Result<int> SaveYear(YearMaster p_Year, int p_UserId, string p_YearName)
        {
            Result<int> _Result = new Result<int>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into YearMaster([Year],DisplayYear,CreatedBy,CreatedDate,IsActive)
                                   values (@Year,@DisplayYear,@CreatedBy,@CreatedDate,@IsActive)";

                int _ID = 0;

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionStringMaster);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@Year", p_Year.Year);
                    dbCommand.Parameters.AddWithValue("@DisplayYear", p_Year.DisplayYear);
                    dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                    dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@IsActive", false);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = "Select @@Identity";

                    _ID = (int)dbCommand.ExecuteScalar();

                    dbCommand.Connection.Close();
                }

                if (_ID > 0)
                {
                    _Result.Data = _ID;
                    _Result.IsSuccess = true;
                    _HistoryHelper.InsertHistory<YearMaster>(_ID, TableType.YearMaster, OperationType.Insert, p_Year, p_UserId,p_YearName);
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

        public Result<bool> ActiveYearById(int p_YearId, int p_UserId,string p_Year)
        {
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"update YearMaster set IsActive=@IsActive,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where YearID=@YearID";

                bool _Flag = false;

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionStringMaster);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@IsActive", true);
                    dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                    dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@YearID", p_YearId);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    _Flag = rowsAffected > 0;
                }

                if (_Flag)
                {
                    _Result.Data = _Flag;
                    _Result.IsSuccess = true;
                    _HistoryHelper.InsertHistory<int>(p_YearId, TableType.YearMaster, OperationType.Update, p_YearId, p_UserId,p_Year);
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
    }
}
