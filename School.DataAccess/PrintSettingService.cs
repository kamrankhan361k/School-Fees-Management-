
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
    public class PrintSettingService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<PrintSettingMaster> GetPrintSetting(string p_Year)
        {
            this.Year = p_Year;
            Result<PrintSettingMaster> _Result = new Result<PrintSettingMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select top 1 * from PrintSettingMaster";

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
                    PrintSettingMaster _PrintSettingMaster = new PrintSettingMaster();

                    _PrintSettingMaster.PrintSettingID = Convert.ToInt32(dataTable.Rows[0]["PrintSettingID"]);
                    _PrintSettingMaster.OutPutFormat = Convert.ToString(dataTable.Rows[0]["OutPutFormat"]);
                    _PrintSettingMaster.PageHeight = Convert.ToDecimal(dataTable.Rows[0]["PageHeight"]);
                    _PrintSettingMaster.PageWidth = Convert.ToDecimal(dataTable.Rows[0]["PageWidth"]);
                    _PrintSettingMaster.MarginTop = Convert.ToDecimal(dataTable.Rows[0]["MarginTop"]);
                    _PrintSettingMaster.MarginLeft = Convert.ToDecimal(dataTable.Rows[0]["MarginLeft"]);
                    _PrintSettingMaster.MarginRight = Convert.ToDecimal(dataTable.Rows[0]["MarginRight"]);
                    _PrintSettingMaster.MarginBottom = Convert.ToDecimal(dataTable.Rows[0]["MarginBottom"]);

                    _Result.Data = _PrintSettingMaster;
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

        public Result<bool> SavePrintSetting(PrintSettingMaster p_PrintSettingMaster, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into PrintSettingMaster (OutPutFormat,PageHeight,PageWidth,MarginTop,MarginLeft,MarginRight,MarginBottom)
                                   values (@OutPutFormat,@PageHeight,@PageWidth,@MarginTop,@MarginLeft,@MarginRight,@MarginBottom)";

                if (p_PrintSettingMaster.PrintSettingID != null)
                {
                    _Query = @"update PrintSettingMaster set OutPutFormat=@OutPutFormat,PageHeight=@PageHeight,PageWidth=@PageWidth,MarginTop=@MarginTop,MarginLeft=@MarginLeft,MarginRight=@MarginRight,MarginBottom=@MarginBottom where PrintSettingID=@PrintSettingID";
                }

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@OutPutFormat", p_PrintSettingMaster.OutPutFormat);
                    dbCommand.Parameters.AddWithValue("@PageHeight", p_PrintSettingMaster.PageHeight);
                    dbCommand.Parameters.AddWithValue("@PageWidth", p_PrintSettingMaster.PageWidth);
                    dbCommand.Parameters.AddWithValue("@MarginTop", p_PrintSettingMaster.MarginTop);
                    dbCommand.Parameters.AddWithValue("@MarginLeft", p_PrintSettingMaster.MarginLeft);
                    dbCommand.Parameters.AddWithValue("@MarginRight", p_PrintSettingMaster.MarginRight);
                    dbCommand.Parameters.AddWithValue("@MarginBottom", p_PrintSettingMaster.MarginBottom);

                    if (p_PrintSettingMaster.PrintSettingID != null)
                    {
                        dbCommand.Parameters.AddWithValue("@PrintSettingID", p_PrintSettingMaster.PrintSettingID);
                    }
                    
                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_PrintSettingMaster.PrintSettingID == null)
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

                    if (p_PrintSettingMaster.PrintSettingID == null)
                    {
                        _HistoryHelper.InsertHistory<PrintSettingMaster>(_ID, TableType.PrintSettingMaster, OperationType.Insert, p_PrintSettingMaster, p_UserId,p_Year);
                    }
                    else
                    {
                        _HistoryHelper.InsertHistory<PrintSettingMaster>(Convert.ToInt32(p_PrintSettingMaster.PrintSettingID), TableType.PrintSettingMaster, OperationType.Update, p_PrintSettingMaster, p_UserId,p_Year);
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

    }
}
