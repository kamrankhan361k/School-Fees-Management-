
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
    public class UserService : ConnectionAccess
    {
        public Result<int> CheckLogin(string p_UserName, string p_Password, string p_Year)
        {
            this.Year = p_Year;

            Result<int> _Result = new Result<int>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                DataRow dataRow = null;
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select UserID from UserMaster where UserName=@UserName and Password=@Password and IsActive=true";

                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new OleDbCommand();
                    dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = _Query;
                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", p_UserName);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Password", p_Password);
                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);
                    // Get the datarow from the table
                    dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                }

                if (dataRow != null)
                {
                    _Result.Data = Convert.ToInt32(dataRow["UserID"]);
                    _Result.IsSuccess = true;
                }
                else
                {
                    _Result.Message = Messages.FailLogin;
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
