
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
    public class StudentService : ConnectionAccess
    {
        #region Variables

        private HistoryHelper _HistoryHelper = new HistoryHelper();

        #endregion

        public Result<DataTable> GetAllStudent(string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select st.IsActive,st.StudentID,st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name , st.RegisterDate,IIf(st.Gender, 'Male', 'FeMale') as Gender,s.Standard,d.Department,dv.Division,st.Category from (((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID) where s.IsActive=true and d.IsActive=true and dv.IsActive=true";

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

        public Result<bool> DeleteStudentById(int p_Id, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update StudentMaster set IsActive=false,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where StudentID=@StudentID";
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
                    dbCommand.Parameters.AddWithValue("@StudentID", p_Id);

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

                    _HistoryHelper.InsertHistory<int>(p_Id, TableType.StudentMaster, OperationType.Delete, p_Id, p_UserId,p_Year);
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

        public Result<int> GetGRNumberByDepartmentId(int p_DepartmentId, string p_Year)
        {
            this.Year = p_Year;
            Result<int> _Result = new Result<int>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select Max(GRNumber) from StudentMaster where DepartmentId=" + p_DepartmentId;

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
                    if (dataTable.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dataTable.Rows[0][0])))
                    {
                        _Result.Data = Convert.ToInt32(dataTable.Rows[0][0]) + 1;
                    }
                    else
                    {
                        _Result.Data = 1;
                    }
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

        public Result<StudentMaster> GetStudentById(int p_Id, string p_Year)
        {
            this.Year = p_Year;
            Result<StudentMaster> _Result = new Result<StudentMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select StudentID,StandardId,DivisionId,DepartmentId,GRNumber,FirstName,MiddleName,LastName,FatherName,MotherName,Gender,City,Address,PhoneNo,MobileNo,BirthDate,RegisterDate,Category from StudentMaster where StudentID=" + p_Id;

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
                    StudentMaster _StudentMaster = new StudentMaster();

                    _StudentMaster.StudentID = Convert.ToInt32(dataTable.Rows[0]["StudentID"]);
                    _StudentMaster.StandardId = Convert.ToInt32(dataTable.Rows[0]["StandardId"]);
                    _StudentMaster.DivisionId = Convert.ToInt32(dataTable.Rows[0]["DivisionId"]);
                    _StudentMaster.DepartmentId = Convert.ToInt32(dataTable.Rows[0]["DepartmentId"]);
                    _StudentMaster.GRNumber = Convert.ToInt32(dataTable.Rows[0]["GRNumber"]);
                    _StudentMaster.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                    _StudentMaster.MiddleName = Convert.ToString(dataTable.Rows[0]["MiddleName"]);
                    _StudentMaster.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                    _StudentMaster.FatherName = Convert.ToString(dataTable.Rows[0]["FatherName"]);
                    _StudentMaster.MotherName = Convert.ToString(dataTable.Rows[0]["MotherName"]);
                    _StudentMaster.IsGender = Convert.ToBoolean(dataTable.Rows[0]["Gender"]);
                    _StudentMaster.BirthDate = Convert.ToDateTime(dataTable.Rows[0]["BirthDate"]);
                    _StudentMaster.RegisterDate = Convert.ToDateTime(dataTable.Rows[0]["RegisterDate"]);
                    _StudentMaster.City = Convert.ToString(dataTable.Rows[0]["City"]);
                    _StudentMaster.Address = Convert.ToString(dataTable.Rows[0]["Address"]);
                    _StudentMaster.PhoneNo = Convert.ToString(dataTable.Rows[0]["PhoneNo"]);
                    _StudentMaster.MobileNo = Convert.ToString(dataTable.Rows[0]["MobileNo"]);
                    _StudentMaster.Category = Convert.ToString(dataTable.Rows[0]["Category"]);

                    _Result.Data = _StudentMaster;
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

        public Result<bool> SaveStudent(StudentMaster p_StudentMaster, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = @"insert into StudentMaster (StandardId,DivisionId,DepartmentId,FirstName,MiddleName,LastName,Gender,FatherName,MotherName,City,Address,BirthDate,RegisterDate,PhoneNo,MobileNo,GRNumber,Category,YearId,CreatedBy,CreatedDate,IsActive,IsUpdate)
                                   values (@StandardId,@DivisionId,@DepartmentId,@FirstName,@MiddleName,@LastName,@Gender,@FatherName,@MotherName,@City,@Address,@BirthDate,@RegisterDate,@PhoneNo,@MobileNo,@GRNumber,@Category,@YearId,@CreatedBy,@CreatedDate,@IsActive,@IsUpdate)";

                if (p_StudentMaster.StudentID != null)
                {
                    _Query = @"update StudentMaster set StandardId=@StandardId,DivisionId=@DivisionId,DepartmentId=@DepartmentId,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,Gender=@Gender,FatherName=@FatherName,MotherName=@MotherName,City=@City,Address=@Address,BirthDate=@BirthDate,RegisterDate=@RegisterDate,PhoneNo=@PhoneNo,MobileNo=@MobileNo,GRNumber=@GRNumber,Category=@Category,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where StudentID=@StudentID";
                }

                int _ID = 0;
                bool _Flag = false;
                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;

                    dbCommand.Parameters.AddWithValue("@StandardId", p_StudentMaster.StandardId);
                    dbCommand.Parameters.AddWithValue("@DivisionId", p_StudentMaster.DivisionId);
                    dbCommand.Parameters.AddWithValue("@DepartmentId", p_StudentMaster.DepartmentId);
                    dbCommand.Parameters.AddWithValue("@FirstName", p_StudentMaster.FirstName);
                    dbCommand.Parameters.AddWithValue("@MiddleName", p_StudentMaster.MiddleName);
                    dbCommand.Parameters.AddWithValue("@LastName", p_StudentMaster.LastName);
                    dbCommand.Parameters.AddWithValue("@Gender", p_StudentMaster.IsGender);
                    dbCommand.Parameters.AddWithValue("@FatherName", p_StudentMaster.FatherName);
                    dbCommand.Parameters.AddWithValue("@MotherName", p_StudentMaster.MotherName);
                    dbCommand.Parameters.AddWithValue("@City", p_StudentMaster.City);
                    dbCommand.Parameters.AddWithValue("@Address", p_StudentMaster.Address);
                    dbCommand.Parameters.AddWithValue("@BirthDate", p_StudentMaster.BirthDate.ToString());
                    dbCommand.Parameters.AddWithValue("@RegisterDate", p_StudentMaster.RegisterDate.ToString());
                    dbCommand.Parameters.AddWithValue("@PhoneNo", p_StudentMaster.PhoneNo);
                    dbCommand.Parameters.AddWithValue("@MobileNo", p_StudentMaster.MobileNo);
                    dbCommand.Parameters.AddWithValue("@GRNumber", p_StudentMaster.GRNumber);
                    dbCommand.Parameters.AddWithValue("@Category", p_StudentMaster.Category);

                    if (p_StudentMaster.StudentID == null)
                    {
                        dbCommand.Parameters.AddWithValue("@YearId", p_StudentMaster.YearId);
                        dbCommand.Parameters.AddWithValue("@CreatedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@IsActive", true);
                        dbCommand.Parameters.AddWithValue("@IsUpdate", true);
                    }
                    else
                    {
                        dbCommand.Parameters.AddWithValue("@ModifiedBy", p_UserId);
                        dbCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString());
                        dbCommand.Parameters.AddWithValue("@StudentID", p_StudentMaster.StudentID);
                    }
                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();

                    if (p_StudentMaster.StudentID == null)
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

                    if (p_StudentMaster.StudentID == null)
                    {
                        _HistoryHelper.InsertHistory<StudentMaster>(_ID, TableType.StudentMaster, OperationType.Insert, p_StudentMaster, p_UserId,p_Year);
                    }
                    else
                    {
                        _Result.Id = p_StudentMaster.StudentID;
                        _HistoryHelper.InsertHistory<StudentMaster>(Convert.ToInt32(p_StudentMaster.StudentID), TableType.StudentMaster, OperationType.Update, p_StudentMaster, p_UserId,p_Year);
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

        public Result<DataTable> GetAllStudentByStandardDivisionDepartment(int p_StandardId, int p_DivisionId, int p_DepartmentId, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select st.StudentID,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name from StudentMaster st where st.IsActive=true and st.StandardId=" + p_StandardId + " and st.DivisionId=" + p_DivisionId + " and st.DepartmentId=" + p_DepartmentId;

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

        public Result<bool> CheckDuplicateGRNo(int p_GRNo, int? p_StudentId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;
                if (p_StudentId == null)
                {
                    p_StudentId = 0;
                }
                string _Query = "select count(StudentID) from StudentMaster where IsActive=true and GRNumber=@GRNumber and StudentID<>@StudentID";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@GRNumber", p_GRNo);
                    dbCommand.Parameters.AddWithValue("@StudentID", p_StudentId);

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

        public Result<DateTime> GetLastRegistrationDate()
        {   
            Result<DateTime> _Result = new Result<DateTime>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select RegisterDate from StudentMaster where StudentID= (select Max(StudentID) from StudentMaster)";

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
                        _Result.Data = Convert.ToDateTime(dataTable.Rows[0][0]);
                        _Result.IsSuccess = true;
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

        public Result<bool> GetIsDemoValid(int p_StandardId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "select count(StudentID) from StudentMaster where IsActive=true and StandardId=@StandardId";

                using (OleDbCommand dbCommand = new OleDbCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = _Query;
                    // Add the input parameters to the parameter collection
                    dbCommand.Parameters.AddWithValue("@StandardId", p_StandardId);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var _Count = dbCommand.ExecuteScalar();
                    dbCommand.Connection.Close();

                    _Result.IsSuccess = true;
                    if (Convert.ToInt32(_Count) > 2)
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

        public Result<bool> UpdateAllStudent(string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update StudentMaster set IsUpdate=false where IsActive=true";
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
                    dbCommand.Connection.Close();
                    _Flag = rowsAffected > 0;
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

        public Result<bool> CheckUpdateStudent(string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;
              
                string _Query = "select count(StudentID) from StudentMaster where IsActive=true and IsUpdate=false";

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

        public Result<DataTable> GetOldStudentByStandardDivisionDepartment(int p_StandardId, int p_DivisionId, int p_DepartmentId, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select st.StudentID,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as StudentName, st.GRNumber as GRNo from StudentMaster st where st.IsActive=true and st.IsUpdate=false and st.StandardId=" + p_StandardId + " and st.DivisionId=" + p_DivisionId + " and st.DepartmentId=" + p_DepartmentId;

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

        public Result<DataTable> GetNewStudentByStandardDivisionDepartment(int p_StandardId, int p_DivisionId, int p_DepartmentId, string p_Year)
        {
            this.Year = p_Year;
            Result<DataTable> _Result = new Result<DataTable>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = "select st.StudentID,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as StudentName, st.GRNumber as GRNo from StudentMaster st where st.IsActive=true and st.IsUpdate=true and st.StandardId=" + p_StandardId + " and st.DivisionId=" + p_DivisionId + " and st.DepartmentId=" + p_DepartmentId;

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

        public Result<bool> UpdateUpStudentByStudentIds(string p_StudentIds, int p_StandardId, int p_DivisionId, int p_DepartmentId, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            Result<bool> _Result = new Result<bool>();
            try
            {
                _Result.IsSuccess = false;

                string _Query = "update StudentMaster set IsUpdate=true,StandardId=" + p_StandardId + ",DivisionId=" + p_DivisionId + ",DepartmentId=" + p_DepartmentId +" where StudentID in("+p_StudentIds+")";
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
                    dbCommand.Connection.Close();
                    _Flag = rowsAffected > 0;

                    if (_Flag)
                    {
                        _HistoryHelper.InsertHistory<string>(0, TableType.StudentMaster, OperationType.UpProcess, p_StudentIds, p_UserId, p_Year);
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

        public Result<StudentMaster> GetStudentDetailById(int p_Id, string p_Year)
        {
            this.Year = p_Year;
            Result<StudentMaster> _Result = new Result<StudentMaster>();
            try
            {
                _Result.IsSuccess = false;

                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    string _Query = @"select st.GRNumber,(IIf(st.LastName Is NULL, '', st.LastName)+' '+IIf(st.FirstName Is NULL, '', st.FirstName)+' '+IIf(st.MiddleName Is NULL, '', st.MiddleName)) as Name,s.Standard,d.Department,dv.Division" +
                 @" from (((StudentMaster st inner join StandardMaster s on st.StandardId=s.StandardID) inner join DepartmentMaster d on st.DepartmentId=d.DepartmentID) inner join DivisionMaster dv on st.DivisionId=dv.DivisionID)
                    where st.IsActive=true and s.IsActive=true and d.IsActive=true and dv.IsActive=true and st.StudentID="+p_Id;
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
                    StudentMaster _StudentMaster = new StudentMaster();

                    _StudentMaster.GRNumber = Convert.ToInt32(dataTable.Rows[0]["GRNumber"]);
                    _StudentMaster.FirstName = Convert.ToString(dataTable.Rows[0]["Name"]);
                    _StudentMaster.Standard = Convert.ToString(dataTable.Rows[0]["Standard"]);
                    _StudentMaster.Department = Convert.ToString(dataTable.Rows[0]["Department"]);
                    _StudentMaster.Division = Convert.ToString(dataTable.Rows[0]["Division"]);

                    _Result.Data = _StudentMaster;
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
