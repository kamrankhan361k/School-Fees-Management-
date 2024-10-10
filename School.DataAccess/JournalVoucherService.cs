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
    public class JournalVoucherService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<bool> SaveJournalVoucher(JournalVoucher p_JournalVoucher, int p_UserId, string p_Year)
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

                    dbCommand.Parameters.AddWithValue("@LedgerId", p_JournalVoucher.LedgerID);
                    dbCommand.Parameters.AddWithValue("@Department", p_JournalVoucher.DepartmentID);
                    dbCommand.Parameters.AddWithValue("@Standard", 0);
                    dbCommand.Parameters.AddWithValue("@Division", 0);
                    dbCommand.Parameters.AddWithValue("@VoucherNo", p_JournalVoucher.VoucherNo);
                    dbCommand.Parameters.AddWithValue("@VoucherType", p_JournalVoucher.VoucherType);
                    dbCommand.Parameters.AddWithValue("@VoucherDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@Debit", p_JournalVoucher.DrAmount);
                    dbCommand.Parameters.AddWithValue("@Credit", p_JournalVoucher.CrAmount);
                    dbCommand.Parameters.AddWithValue("@PaymentTo", "");
                    dbCommand.Parameters.AddWithValue("@Narration", p_JournalVoucher.Narration);

                    if (p_JournalVoucher.JournalVoucherId == null)
                    {
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                    }

                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_JournalVoucher.JournalVoucherId == null)
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

                    if (p_JournalVoucher.JournalVoucherId == null)
                    {
                        _HistoryHelper.InsertHistory<JournalVoucher>(_ID, TableType.LedgerDetail, OperationType.Insert, p_JournalVoucher, p_UserId, p_Year);
                    }
                    else
                    {
                        _Result.Id = p_JournalVoucher.JournalVoucherId;
                        _HistoryHelper.InsertHistory<JournalVoucher>(Convert.ToInt32(p_JournalVoucher.JournalVoucherId), TableType.LedgerDetail, OperationType.Update, p_JournalVoucher, p_UserId, p_Year);
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
            catch (Exception)
            {
                _Result.IsSuccess = false;
            }
            return _Result;
        }
    }
}
