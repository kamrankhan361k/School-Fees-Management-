
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
    public class CollectFeesService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetCollectFeesByStudentId(int p_StudentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select fm.FeesID,fm.DisplayFeesName,fm.FeesName,fm.Fees from FeesMaster fm inner join CollectFeesMaster cf on fm.FeesID=cf.FeesId where fm.IsActive=true and cf.IsActive=true and cf.StudentId=" + p_StudentId + " and fm.IsOtherFees=" + p_IsOtherFees;

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

        public Result<bool> SaveCollectFees(List<CollectFeesMaster> p_CollectFeesMaster, int p_StudentId, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into CollectFeesMaster (FeesId,StudentId,Fees,PayFees,PendingFees,YearId,CreatedBy,CreatedDate,IsActive)
                                   values (@FeesId,@StudentId,@Fees,@PayFees,@PendingFees,@YearId,@CreatedBy,@CreatedDate,@IsActive)";

                int _ID = 0;

                foreach (CollectFeesMaster _CollectFeesMaster in p_CollectFeesMaster)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;

                        dbCommand.Parameters.AddWithValue("@FeesId", _CollectFeesMaster.FeesId);
                        dbCommand.Parameters.AddWithValue("@StudentId", p_StudentId);
                        dbCommand.Parameters.AddWithValue("@Fees", _CollectFeesMaster.Fees);
                        dbCommand.Parameters.AddWithValue("@PayFees", 0);
                        dbCommand.Parameters.AddWithValue("@PendingFees", _CollectFeesMaster.Fees);
                        dbCommand.Parameters.AddWithValue("@YearId", _CollectFeesMaster.YearId);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);

                        dbCommand.Connection.Open();
                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "Select @@Identity";

                        _ID = (int)dbCommand.ExecuteScalar();

                        dbCommand.Connection.Close();

                        _HistoryHelper.InsertHistory<CollectFeesMaster>(_ID, TableType.CollectFeesMaster, OperationType.Insert, _CollectFeesMaster, p_UserId, p_Year);
                    }
                }

                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<DataTable> GetAllPendingFeesStudent(bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select * from (select st.StudentID,st.StandardId,st.DivisionId,st.DepartmentId,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,IIf(st.Gender, 'Male', 'FeMale') as Gender,s.Standard,d.Department,dv.Division, sum(cf.PayFees) as Fees, sum(cf.PendingFees) as PendingFees from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=cf.FeesId) where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and cf.IsActive=true and fm.IsActive=true and fm.IsOtherFees=" + p_IsOtherFees + " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,st.Gender,s.Standard,d.Department,dv.Division,st.StandardId,st.DivisionId,st.DepartmentId) fmm where fmm.Fees<1";

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

        public Result<DataTable> GetAllInCompleteFeesStudent(bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select * from (select st.StudentID,st.StandardId,st.DivisionId,st.DepartmentId,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,IIf(st.Gender, 'Male', 'FeMale') as Gender,s.Standard,d.Department,dv.Division, sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees from (((((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on fm.FeesID=cf.FeesId) where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and cf.IsActive=true and fm.IsActive=true and fm.IsOtherFees=" + p_IsOtherFees + " group by st.StudentID,st.GRNumber,st.FirstName,st.MiddleName,st.LastName,st.Gender,s.Standard,d.Department,dv.Division,st.StandardId,st.DivisionId,st.DepartmentId) fmm where fmm.PayFees>0";

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

        public Result<DataTable> GetAllPendingFees(int p_StudentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select cf.CollectFeesID,fm.FeesID,fm.DisplayFeesName,cf.Fees,cf.PayFees,cf.PendingFees,IIf(fm.IsOneTime, 'One Time', 'Monthly') as FeesType from FeesMaster fm inner join CollectFeesMaster cf on fm.FeesID=cf.FeesId where fm.IsActive=true and cf.IsActive=true and cf.PendingFees>0 and cf.StudentId=" + p_StudentId + " and fm.IsOtherFees=" + p_IsOtherFees + " order by fm.FeesID";

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

        public Result<bool> UpdateCollectFees(List<CollectFeesMaster> p_CollectFeesMaster, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"update CollectFeesMaster set PayFees=PayFees+@PayFees,PendingFees=PendingFees-@PendingFees,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where CollectFeesID=@CollectFeesID";

                foreach (CollectFeesMaster _CollectFeesMaster in p_CollectFeesMaster)
                {
                    using (OleDbCommand dbCommand = new OleDbCommand())
                    {
                        dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = _Query;

                        dbCommand.Parameters.AddWithValue("@PayFees", _CollectFeesMaster.PayFees);
                        dbCommand.Parameters.AddWithValue("@PendingFees", _CollectFeesMaster.PayFees);
                        dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@CollectFeesID", _CollectFeesMaster.CollectFeesID);

                        dbCommand.Connection.Open();
                        var rowsAffected = dbCommand.ExecuteNonQuery();

                        dbCommand.Connection.Close();

                        _HistoryHelper.InsertHistory<CollectFeesMaster>(_CollectFeesMaster.CollectFeesID.Value, TableType.CollectFeesMaster, OperationType.Update, _CollectFeesMaster, p_UserId, p_Year);
                    }
                }

                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<bool> TruncateCollectFeesMaster(string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "delete from CollectFeesMaster";
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    _Flag = rowsAffected > 0;

                    _Query = "alter table CollectFeesMaster alter column CollectFeesID number";

                    dbCommand.CommandText = _Query;
                    dbCommand.ExecuteNonQuery();

                    _Query = "alter table CollectFeesMaster alter column CollectFeesID AUTOINCREMENT";

                    dbCommand.CommandText = _Query;
                    dbCommand.ExecuteNonQuery();

                    dbCommand.Connection.Close();
                }

                _Result.Data = true;
                _Result.IsSuccess = true;
            }
            catch (Exception _Exception)
            {
                _Result.IsSuccess = false;
                _Result.Message = Messages.ExceptionMsg;
                _Result.Exception = _Exception;
            }
            return _Result;
        }

        public Result<List<TreeList>> GetCollectFeesDetail(string p_Year, bool p_IsOtherFees)
        {
            this.Year = p_Year;
            Result<List<TreeList>> _Result = new Result<List<TreeList>>();
            try
            {
                _Result.IsSuccess = false;

                List<TreeList> _ListOfTreeList = new List<TreeList>();

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select d.Department,d.DepartmentID,sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees from ((StudentMaster st inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on cf.FeesId=fm.FeesID where st.IsActive=true and d.IsActive=true and cf.IsActive=true and fm.IsActive=true and fm.IsOtherFees=" + p_IsOtherFees + " group by d.Department,d.DepartmentID order by d.Department";

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
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow item in dataTable.Rows)
                        {
                            TreeList _TreeList = new TreeList();

                            _TreeList.ParentId = string.Empty;
                            _TreeList.ChildId = Convert.ToString(Guid.NewGuid());
                            _TreeList.TreeText = Convert.ToString(item["Department"]) + "    Fees : " + Convert.ToString(item["Fees"]) + " - " + Convert.ToString(item["PayFees"]) + " = " + Convert.ToString(item["PendingFees"]);

                            _ListOfTreeList.Add(_TreeList);

                            this.GetCollectFeesDetailStandard(Convert.ToInt32(item["DepartmentID"]), _TreeList.ChildId, p_Year, p_IsOtherFees, ref _ListOfTreeList);
                        }
                    }
                }

                if (_ListOfTreeList.Count() > 0)
                {
                    _Result.Data = _ListOfTreeList;
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

        public void GetCollectFeesDetailStandard(int p_DepartmentId, string p_ParentId, string p_Year, bool p_IsOtherFees, ref List<TreeList> p_ListOfTreeList)
        {
            this.Year = p_Year;

            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                string _Query = "select s.Standard,s.StandardID,sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees from ((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on cf.FeesId=fm.FeesID where st.IsActive=true and s.IsActive=true and cf.IsActive=true and fm.IsActive=true and st.DepartmentId=" + p_DepartmentId + " and fm.IsOtherFees=" + p_IsOtherFees + " group by s.Standard,s.StandardID order by s.StandardID";

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
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable.Rows)
                    {
                        TreeList _TreeList = new TreeList();

                        _TreeList.ParentId = p_ParentId;
                        _TreeList.ChildId = Convert.ToString(Guid.NewGuid());
                        _TreeList.TreeText = Convert.ToString(item["Standard"]) + "    Fees : " + Convert.ToString(item["Fees"]) + " - " + Convert.ToString(item["PayFees"]) + " = " + Convert.ToString(item["PendingFees"]);

                        p_ListOfTreeList.Add(_TreeList);
                        this.GetCollectFeesDetailDivision(p_DepartmentId, Convert.ToInt32(item["StandardID"]), _TreeList.ChildId, p_Year, p_IsOtherFees, ref p_ListOfTreeList);
                    }
                }
            }
        }

        public void GetCollectFeesDetailDivision(int p_DepartmentId, int p_StandardId, string p_ParentId, string p_Year, bool p_IsOtherFees, ref List<TreeList> p_ListOfTreeList)
        {
            this.Year = p_Year;

            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                string _Query = "select d.Division,d.DivisionID,sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees from ((StudentMaster st inner join DivisionMaster d on st.DivisionId=d.DivisionID) inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on cf.FeesId=fm.FeesID where st.IsActive=true and d.IsActive=true and cf.IsActive=true and fm.IsActive=true and st.DepartmentId=" + p_DepartmentId + " and st.StandardId=" + p_StandardId + " and fm.IsOtherFees=" + p_IsOtherFees + " group by d.Division,d.DivisionID order by d.DivisionID";

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
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable.Rows)
                    {
                        TreeList _TreeList = new TreeList();

                        _TreeList.ParentId = p_ParentId;
                        _TreeList.ChildId = Convert.ToString(Guid.NewGuid());
                        _TreeList.TreeText = Convert.ToString(item["Division"]) + "    Fees : " + Convert.ToString(item["Fees"]) + " - " + Convert.ToString(item["PayFees"]) + " = " + Convert.ToString(item["PendingFees"]);

                        p_ListOfTreeList.Add(_TreeList);

                        this.GetCollectFeesDetailStudent(p_DepartmentId, p_StandardId, Convert.ToInt32(item["DivisionID"]), _TreeList.ChildId, p_Year, p_IsOtherFees, ref p_ListOfTreeList);
                    }
                }
            }
        }

        public void GetCollectFeesDetailStudent(int p_DepartmentId, int p_StandardId, int p_DivisionId, string p_ParentId, string p_Year, bool p_IsOtherFees, ref List<TreeList> p_ListOfTreeList)
        {
            this.Year = p_Year;

            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                string _Query = "select (IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,st.StudentID,sum(cf.Fees) as Fees, sum(cf.PayFees) as PayFees,sum(cf.PendingFees) as PendingFees from (StudentMaster st inner join CollectFeesMaster cf on cf.StudentId=st.StudentID) inner join FeesMaster fm on cf.FeesId=fm.FeesID where st.IsActive=true and cf.IsActive=true and fm.IsActive=true and st.DepartmentId=" + p_DepartmentId + " and st.StandardId=" + p_StandardId + " and st.DivisionId=" + p_DivisionId + " and fm.IsOtherFees=" + p_IsOtherFees + " group by st.LastName,st.FirstName,st.MiddleName,st.StudentID order by st.StudentID";

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
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable.Rows)
                    {
                        TreeList _TreeList = new TreeList();

                        _TreeList.ParentId = p_ParentId;
                        _TreeList.ChildId = Convert.ToString(item["StudentID"]);
                        _TreeList.TreeText = Convert.ToString(item["Name"]) + "    Fees : " + Convert.ToString(item["Fees"]) + " - " + Convert.ToString(item["PayFees"]) + " = " + Convert.ToString(item["PendingFees"]);

                        p_ListOfTreeList.Add(_TreeList);
                    }
                }
            }
        }

        public Result<bool> CheckPendingFeesCountByStudent(int p_StudentId, bool p_IsOtherFees, string p_Year)
        {
            this.Year = Convert.ToString(Convert.ToInt32(p_Year) - 1);
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "select count(cf.CollectFeesID) from FeesMaster fm inner join CollectFeesMaster cf on fm.FeesID=cf.FeesId where fm.IsActive=true and cf.IsActive=true and cf.PendingFees>0 and cf.StudentId=" + p_StudentId + " and fm.IsOtherFees=" + p_IsOtherFees;

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                 
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
