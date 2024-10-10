
using School.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class HistoryHelper : ConnectionAccess
    {
        public void InsertHistory<T>(int p_TableId, TableType p_TableType, OperationType p_OperationType, T p_ToSerialize, int p_UserId, string p_Year)
        {
            this.Year = p_Year;
            string _Query = "Insert into [History] ([Description],[TableId],[TableTypeId],[OperationTypeId],[UserId],[CreatedDate]) Values(@Description,@TableId,@TableTypeId,@OperationTypeId,@UserId,@CreatedDate)";

            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = _Query;
                // Add the input parameters to the parameter collection
                oleDbCommand.Parameters.AddWithValue("@Description", p_TableType.ToString() + " " + p_OperationType.ToString());
                oleDbCommand.Parameters.AddWithValue("@TableId",
                             p_TableId);
                oleDbCommand.Parameters.AddWithValue("@TableTypeId",
                            Convert.ToInt32(p_TableType));
                oleDbCommand.Parameters.AddWithValue("@OperationTypeId",
                            Convert.ToInt32(p_OperationType));
                oleDbCommand.Parameters.AddWithValue("@UserId",
                            p_UserId);
                oleDbCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();
            }
        }

    }
}
