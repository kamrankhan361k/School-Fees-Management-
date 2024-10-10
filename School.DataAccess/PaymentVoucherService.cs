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
    public class PaymentVoucherService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<bool> SavePaymentVoucher(PaymentVoucherMatser p_PaymentVoucherMatser, int p_UserId, string p_Year)
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

                    dbCommand.Parameters.AddWithValue("@LedgerId", p_PaymentVoucherMatser.LedgerID);
                    dbCommand.Parameters.AddWithValue("@Department", p_PaymentVoucherMatser.DepartmentID);
                    dbCommand.Parameters.AddWithValue("@Standard", 0);
                    dbCommand.Parameters.AddWithValue("@Division", 0);
                    dbCommand.Parameters.AddWithValue("@VoucherNo", p_PaymentVoucherMatser.VoucherNo);
                    dbCommand.Parameters.AddWithValue("@VoucherType", p_PaymentVoucherMatser.VoucherType);
                    dbCommand.Parameters.AddWithValue("@VoucherDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@Debit", p_PaymentVoucherMatser.DrAmount);
                    dbCommand.Parameters.AddWithValue("@Credit", p_PaymentVoucherMatser.CrAmount);
                    dbCommand.Parameters.AddWithValue("@PaymentTo", p_PaymentVoucherMatser.PaymentTo);
                    dbCommand.Parameters.AddWithValue("@Narration", p_PaymentVoucherMatser.Narration);

                    if (p_PaymentVoucherMatser.PaymentVoucherId == null)
                    {
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                    }

                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_PaymentVoucherMatser.PaymentVoucherId == null)
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

                    if (p_PaymentVoucherMatser.PaymentVoucherId == null)
                    {
                        _HistoryHelper.InsertHistory<PaymentVoucherMatser>(_ID, TableType.LedgerDetail, OperationType.Insert, p_PaymentVoucherMatser, p_UserId, p_Year);
                    }
                    else
                    {
                        _Result.Id = p_PaymentVoucherMatser.PaymentVoucherId;
                        _HistoryHelper.InsertHistory<PaymentVoucherMatser>(Convert.ToInt32(p_PaymentVoucherMatser.PaymentVoucherId), TableType.LedgerDetail, OperationType.Update, p_PaymentVoucherMatser, p_UserId, p_Year);
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

        public Result<DataTable> GetVoucherByVoucherNo(int p_VoucherNo, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select LedgerDetailID, LedgerId,Department,Standard,Division,VoucherNo,
                                        VoucherType,VoucherDate,Debit,Credit,PaymentTo,Narration
                                        from LedgerDetail where VoucherNo=" + p_VoucherNo;

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
