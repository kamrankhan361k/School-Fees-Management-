using School.Common;
using School.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace School.DataAccess
{
    public class VoucherService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        #region SaveVouchers

        public Result<bool> SavePaymentVoucher(List<PaymentVoucher> p_PaymentVoucher, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            OleDbTransaction _OleDbTransaction;
            OleDbConnection _OleDbConnection = new OleDbConnection(this.ConnectionString);
            _OleDbConnection.Open();
            _OleDbTransaction = _OleDbConnection.BeginTransaction();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into PaymentVoucher (DepartmentID,VoucherNo,DebitorID,CreditorID,DrAmount,CrAmount,PaymentTo,Narration,IsActive,CreatedBy,CreatedDate)
                                                      values (@DepartmentID,@VoucherNo,@DebitorID,@CreditorID,@DrAmount,@CrAmount,@PaymentTo,@Narration,@IsActive,@CreatedBy,@CreatedDate)";

                int _ID = 0;
                foreach (var _PaymentVoucher in p_PaymentVoucher)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = _OleDbConnection;
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;
                        dbCommand.Transaction = _OleDbTransaction;

                        dbCommand.Parameters.AddWithValue("@DepartmentID", _PaymentVoucher.DepartmentId);
                        dbCommand.Parameters.AddWithValue("@VoucherNo", _PaymentVoucher.VoucherNo);
                        dbCommand.Parameters.AddWithValue("@DebitorID", _PaymentVoucher.DebitorID);
                        dbCommand.Parameters.AddWithValue("@CreditorID", _PaymentVoucher.CreditorID);
                        dbCommand.Parameters.AddWithValue("@DrAmount", _PaymentVoucher.DrAmount);
                        dbCommand.Parameters.AddWithValue("@CrAmount", _PaymentVoucher.CrAmount);
                        dbCommand.Parameters.AddWithValue("@PaymentTo", _PaymentVoucher.PaymentTo);
                        dbCommand.Parameters.AddWithValue("@Narration", _PaymentVoucher.Narration);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToShortDateString());

                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        _HistoryHelper.InsertHistory<PaymentVoucher>(_ID, TableType.LedgerDetail, OperationType.Insert, _PaymentVoucher, p_UserId, p_Year);
                    }
                }
                _OleDbTransaction.Commit();
                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _OleDbTransaction.Rollback();
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            finally
            {
                _OleDbConnection.Close();
            }
            return _Result;
        }

        public Result<bool> SaveJournalVoucher(List<JournalVoucher> p_JournalVoucher,VoucherBalanceSheet p_VoucherBalanceSheet, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            OleDbTransaction _OleDbTransaction;
            OleDbConnection _OleDbConnection = new OleDbConnection(this.ConnectionString);
            _OleDbConnection.Open();
            _OleDbTransaction = _OleDbConnection.BeginTransaction();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into JournalVoucher (VoucherNo,DrDepartmentID,CrDepartmentID,DrLedger,CrLedger,DrAmount,CrAmount,Narration,CreatedDate,CreatedBy,IsActive)
                                                      values (@VoucherNo,@DrDepartmentID,@CrDepartmentID,@DrLedger,@CrLedger,@DrAmount,@CrAmount,@Narration,@CreatedDate,@CreatedBy,@IsActive)";

                int _ID = 0;
                foreach (var _JournalVoucher in p_JournalVoucher)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = _OleDbConnection;
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;
                        dbCommand.Transaction = _OleDbTransaction;

                        dbCommand.Parameters.AddWithValue("@VoucherNo", _JournalVoucher.VoucherNo);
                        dbCommand.Parameters.AddWithValue("@DrDepartmentID", _JournalVoucher.DrDepartmentID);
                        dbCommand.Parameters.AddWithValue("@CrDepartmentID", _JournalVoucher.CrDepartmentID);
                        dbCommand.Parameters.AddWithValue("@DrLedger", _JournalVoucher.DrLedgerID);
                        dbCommand.Parameters.AddWithValue("@CrLedger", _JournalVoucher.CrLedgerID);
                        dbCommand.Parameters.AddWithValue("@DrAmount", _JournalVoucher.DrAmount);
                        dbCommand.Parameters.AddWithValue("@CrAmount", _JournalVoucher.CrAmount);
                        dbCommand.Parameters.AddWithValue("@Narration", _JournalVoucher.Narration);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToShortDateString());
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@IsActive", true);

                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        _HistoryHelper.InsertHistory<JournalVoucher>(_ID, TableType.LedgerDetail, OperationType.Insert, _JournalVoucher, p_UserId, p_Year);
                    }
                }

                _Query = @"insert into JournalVoucher (CreatedDate,Particular,VoucherNo,Cr,Dr,CreatedBy)
                                               values (@CreatedDate,@Particular,@VoucherNo,@Cr,@Dr,@CreatedBy)";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    dbCommand.Connection = _OleDbConnection;
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    dbCommand.Transaction = _OleDbTransaction;

                    dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@Particular", p_VoucherBalanceSheet.Particular);
                    dbCommand.Parameters.AddWithValue("@VoucherNo", p_VoucherBalanceSheet.VoucherNumber);
                    dbCommand.Parameters.AddWithValue("@Cr", p_VoucherBalanceSheet.Cr);
                    dbCommand.Parameters.AddWithValue("@Dr", p_VoucherBalanceSheet.Dr);
                    dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);

                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = "Select @@Identity";

                    _ID = (int)dbCommand.ExecuteScalar();

                    _HistoryHelper.InsertHistory<VoucherBalanceSheet>(_ID, TableType.LedgerDetail, OperationType.Insert, p_VoucherBalanceSheet, p_UserId, p_Year);
                }

                _OleDbTransaction.Commit();
                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _OleDbTransaction.Rollback();
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            finally
            {
                _OleDbConnection.Close();
            }
            return _Result;
        }

        public Result<bool> SaveContraVoucher(List<ContraVouncher> p_ContraVouncher, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            OleDbTransaction _OleDbTransaction;
            OleDbConnection _OleDbConnection = new OleDbConnection(this.ConnectionString);
            _OleDbConnection.Open();
            _OleDbTransaction = _OleDbConnection.BeginTransaction();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into ContraVoucher (DepartmentID,VoucherNo,DebitorID,CreditorID,DrAmount,CrAmount,PaymentBy,Narration,CreatedBy,IsActive,CreatedDate)
                                                    values (@DepartmentID,@VoucherNo,@DebitorID,@CreditorID,@DrAmount,@CrAmount,@PaymentBy,@Narration,@CreatedBy,@IsActive,@CreatedDate)";

                int _ID = 0;
                foreach (var _ContraVoucher in p_ContraVouncher)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = _OleDbConnection;
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;
                        dbCommand.Transaction = _OleDbTransaction;

                        dbCommand.Parameters.AddWithValue("@DepartmentID", _ContraVoucher.DepartmentID);
                        dbCommand.Parameters.AddWithValue("@VoucherNo", _ContraVoucher.VoucherNo);
                        dbCommand.Parameters.AddWithValue("@DebitorID", _ContraVoucher.DebitorID);
                        dbCommand.Parameters.AddWithValue("@CreditorID", _ContraVoucher.CreditorID);
                        dbCommand.Parameters.AddWithValue("@DrAmount", _ContraVoucher.DrAmount);
                        dbCommand.Parameters.AddWithValue("@CrAmount", _ContraVoucher.CrAmount);
                        dbCommand.Parameters.AddWithValue("@PaymentBy", _ContraVoucher.PaymentBy);
                        dbCommand.Parameters.AddWithValue("@Narration", _ContraVoucher.Narration);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToShortDateString());

                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        _HistoryHelper.InsertHistory<ContraVouncher>(_ID, TableType.LedgerDetail, OperationType.Insert, _ContraVoucher, p_UserId, p_Year);
                    }
                }
                _OleDbTransaction.Commit();
                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _OleDbTransaction.Rollback();
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            finally
            {
                _OleDbConnection.Close();
            }
            return _Result;
        }

        public Result<bool> SaveOtherReceiptVoucher(List<OtherReceipt> p_OtherReceipt, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            OleDbTransaction _OleDbTransaction;
            OleDbConnection _OleDbConnection = new OleDbConnection(this.ConnectionString);
            _OleDbConnection.Open();
            _OleDbTransaction = _OleDbConnection.BeginTransaction();
            try
            {
                _Result.IsSuccess = false;

                //string _Query = @"insert into OtherReceiptVoucher (DepartmentID,VoucherNo,DebitorID,CreditorID,DrAmount,CrAmount,ReceiveFrom,Narration,CreatedBy,CreatedDate,IsActive)
                //                                           values (@DepartmentID,@VoucherNo,@DebitorID,@CreditorID,@DrAmount,@CrAmount,@ReceiveFrom,@Narration,@CreatedBy,@CreatedDate,@IsActive)";
                string _Query = @"insert into OtherReceiptVoucher (DepartmentID,VoucherNo,DebitorID,CreditorID,DrAmount,CrAmount,ReceiveFrom,Narration,CreatedBy,IsActive,CreatedDate)
                                                           values (@DepartmentID,@VoucherNo,@DebitorID,@CreditorID,@DrAmount,@CrAmount,@ReceiveFrom,@Narration,@CreatedBy,@IsActive,@CreatedDate)";

                int _ID = 0;
                foreach (var _OtherReceipt in p_OtherReceipt)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = _OleDbConnection;
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;
                        dbCommand.Transaction = _OleDbTransaction;

                        dbCommand.Parameters.AddWithValue("@DepartmentID", _OtherReceipt.DepartmentId);
                        dbCommand.Parameters.AddWithValue("@VoucherNo", _OtherReceipt.VoucherNo);
                        dbCommand.Parameters.AddWithValue("@DebitorID", _OtherReceipt.DebitorID);
                        dbCommand.Parameters.AddWithValue("@CreditorID", _OtherReceipt.CreditorID);
                        dbCommand.Parameters.AddWithValue("@DrAmount", _OtherReceipt.DrAmount);
                        dbCommand.Parameters.AddWithValue("@CrAmount", _OtherReceipt.CrAmount);
                        dbCommand.Parameters.AddWithValue("@ReceiveFrom", _OtherReceipt.ReceiveFrom);
                        dbCommand.Parameters.AddWithValue("@Narration", _OtherReceipt.Narration);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());

                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        _HistoryHelper.InsertHistory<OtherReceipt>(_ID, TableType.OtherReceiptVoucher, OperationType.Insert, _OtherReceipt, p_UserId, p_Year);
                    }
                }
                _OleDbTransaction.Commit();
                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _OleDbTransaction.Rollback();
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            finally
            {
                _OleDbConnection.Close();
            }
            return _Result;
        }

        #endregion
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
                    string _Query = @"select LedgerDetailID, LedgerId,Department,VoucherNo,
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

        //public Result<bool> GetVoucherNoFromSort(string p_Year)
        //{
        //    this.Year = p_Year;
        //    Result<bool> _Result = new Result<bool>();

        //    //OpenFileDialog dialog = new OpenFileDialog();
        //    //String path = dialog.FileName; // get name of file
        //    //using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
        //    //{
        //    //    String line = reader.ReadToEnd();
        //    //    List<string> _InputArr = line.Split(new char[] { ' ' }).ToList();
        //    //    List<string> _DistinctCode = new List<string>();
        //    //    _InputArr = _InputArr.Where(p => !(p.Contains(line.Substring(0, 1)))).ToList();
        //    //    _DistinctCode.Add(line.Substring(0, 1));
        //    //    foreach (string _Postcode in _InputArr)
        //    //    {
        //    //        if (_DistinctCode.Where(p => p == _Postcode.Substring(0, 1)).Count() == 0)
        //    //        {
        //    //            _DistinctCode.Add(_Postcode.Substring(0, 1));
        //    //        }
        //    //    }
        //    //    string _distp = "";
        //    //    foreach (string _postcode in _DistinctCode)
        //    //    {
        //    //        _distp = _distp + "" + _postcode;
        //    //    }
        //    //    MessageBox.Show(_distp, "Distinct Postcode", MessageBoxButtons.OK);
        //    }
        //    try
        //    {
        //        using (OleDbCommand dbCommand = new OleDbCommand())
        //        {
        //            string _Query = "select max(VoucherNo) as VoucherNo from LedgerDetail";
        //            dbCommand.Connection = new OleDbConnection(this.ConnectionString);
        //            dbCommand.CommandType = CommandType.Text;
        //            dbCommand.CommandText = _Query;
        //            dbCommand.Connection.Open();

        //            OleDbDataReader reader1 = dbCommand.ExecuteReader();

        //            bool _VoucherNo = 1;
        //            if (reader1.Read())
        //            {
        //                //_VoucherNo = reader1.IsDBNullAsync(0) ? 0 : Convert.ToString(reader1["VoucherNo"]);
        //                _Result.IsSuccess = true;
        //                _Result.Data = _VoucherNo + 1;
        //            }
        //            reader.Close();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _Result.IsSuccess = false;
        //    }
        //    return _Result;
        //}

        public Result<string> GetVoucherNo(string p_Prifix, string p_Year, string p_ID, string p_Table)
        {
            this.Year = p_Year;
            Result<string> _Result = new Result<string>();
            string _VoucherNo;
            try
            {
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    string _Query = "SELECT VoucherNo FROM " + p_Table + " where " + p_ID + " = (select max (" + p_ID + ") from " + p_Table + ")";
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    dbCommand.Connection.Open();

                    var Number = dbCommand.ExecuteScalar();

                    if (Number == null)
                    {
                        _VoucherNo = p_Prifix + "-" + p_Year + "|1";
                    }
                    else
                    {
                        string Num = Number.ToString();
                        string[] _No = Num.Split('|');
                        _VoucherNo = p_Prifix + "-" + p_Year + "|" + (Convert.ToInt32(_No[1]) + 1).ToString();
                    }
                    _Result.Data = _VoucherNo;
                    _Result.IsSuccess = true;
                }
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        #region Balance Sheet

        public Result<bool> SaveVoucherBalanceSheet(VoucherBalanceSheet p_VoucherBalanceSheet, int p_UserId, string p_Year)
        {
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into VoucherBalanceSheet (CreatedDate,Particular,Standard,VoucherNo,Cr,Dr,CreatedBy)
                                                           values (@CreatedDate,@Particular,@Standard,@VoucherNo,@Cr,@Dr,@CreatedBy)";

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                    dbCommand.Parameters.AddWithValue("@Particular", p_VoucherBalanceSheet.Particular);
                    dbCommand.Parameters.AddWithValue("@Standard", p_VoucherBalanceSheet.Standard);
                    dbCommand.Parameters.AddWithValue("@VoucherNo", p_VoucherBalanceSheet.VoucherNumber);
                    dbCommand.Parameters.AddWithValue("@Cr", p_VoucherBalanceSheet.Cr);
                    dbCommand.Parameters.AddWithValue("@Dr", p_VoucherBalanceSheet.Dr);
                    dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = "Select @@Identity";

                    _ID = (int)dbCommand.ExecuteScalar();


                    dbCommand.Connection.Close();
                    _Flag = rowsAffected > 0;
                }

                if (_Flag)
                {
                    _Result.Data = true;
                    _Result.IsSuccess = true;
                    _Result.Id = _ID;
                    _Result.Id = _ID;
                    _HistoryHelper.InsertHistory<VoucherBalanceSheet>(_ID, TableType.DepartmentMaster, OperationType.Insert, p_VoucherBalanceSheet, p_UserId, p_Year);
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

        #endregion

    }
}
