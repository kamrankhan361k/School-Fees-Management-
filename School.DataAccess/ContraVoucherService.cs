using CNMehta_School.Common;
using CNMehta_School.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNMehta_School.DataAccess
{
    public class ContraVoucherService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<bool> SaveContraVoucher(ContraVouncher p_ContraVouncher, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into LedgerDetail (LedgerId,Department,Standard,Division,VoucherNo,VoucherType,VoucherDate,Debit,Credit,PaymentTo,Narration)
                                                    values (@LedgerId,@Department,@Standard,@Division,@VoucherNo,@VoucherType,@VoucherDate,@Debit,@Credit,@PaymentTo,@Narration)";
                
                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@LedgerId", p_ContraVouncher.LedgerID);
                    dbCommand.Parameters.AddWithValue("@Department", p_ContraVouncher.DepartmentID);
                    dbCommand.Parameters.AddWithValue("@Standard", p_ContraVouncher.StandardID);
                    dbCommand.Parameters.AddWithValue("@Division", p_ContraVouncher.DivisionID);
                    dbCommand.Parameters.AddWithValue("@VoucherNo", p_ContraVouncher.VoucherNo);
                    dbCommand.Parameters.AddWithValue("@VoucherType", p_ContraVouncher.VoucherType);
                    dbCommand.Parameters.AddWithValue("@VoucherDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@Debit", p_ContraVouncher.DrAmount);
                    dbCommand.Parameters.AddWithValue("@Credit", p_ContraVouncher.CrAmount);
                    dbCommand.Parameters.AddWithValue("@PaymentTo", p_ContraVouncher.PaymentTo);
                    dbCommand.Parameters.AddWithValue("@Narration", p_ContraVouncher.Narration);

                    if (p_ContraVouncher.ContraVoucherId == null)
                    {
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                    }

                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_ContraVouncher.ContraVoucherId == null)
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
                    _Result.Id = _ID;
                    _Result.IsSuccess = true;

                    if (p_ContraVouncher.ContraVoucherId == null)
                    {
                        _HistoryHelper.InsertHistory<ContraVouncher>(_ID, TableType.LedgerDetail, OperationType.Insert, p_ContraVouncher, p_UserId, p_Year);
                    }
                    else
                    {
                        _Result.Id = p_ContraVouncher.ContraVoucherId;
                        _HistoryHelper.InsertHistory<ContraVouncher>(Convert.ToInt32(p_ContraVouncher.ContraVoucherId), TableType.LedgerDetail, OperationType.Update, p_ContraVouncher, p_UserId, p_Year);
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

        public Result<int> GetVoucherNo()
        {
            Result<int> _Result = new Result<int>();
            try
            {
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    string _Query = "select max(VoucherNo) as VoucherNo from LedgerDetail";
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    dbCommand.Connection.Open();

                    OleDbDataReader reader = dbCommand.ExecuteReader();

                    int _VoucherNo = 1;
                    if (reader.Read())
                    {
                        _VoucherNo = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader["VoucherNo"]);
                        _Result.IsSuccess = true;
                        _Result.Data = _VoucherNo + 1;
                    }
                    reader.Close();                    
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Exception = _Exception;
            }
           return _Result;
        }
    }
}
