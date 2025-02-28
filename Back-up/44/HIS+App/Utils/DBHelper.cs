using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Utils
{
    public class DBHelper: IDisposable
    {
        public string ConnectionString { get; private set; }

        public SqlConnection Connection { get; private set; }

      
        bool disposed = false;

        public DBHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
            Connection = new SqlConnection(this.ConnectionString);
        }

        ~DBHelper()
        {
            Dispose(false);
        }

        public  System.Data.DataTable ExecuteQuery(string query)
        {
            if (Connection == null)
                Connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            cmd.CommandText = query;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            return dt;
        }

        public System.Data.DataTable Select(string tableName, string filter)
        {
            var query = "Select * FROM " + tableName;

            if (!(string.IsNullOrEmpty(filter)))
                query += " where " + filter;

            return ExecuteQuery(query);
        }

        public System.Data.DataTable Select(string tableName)
        {
            return Select(tableName, null);
        }

        public DataRow SelectSingle(string tableName, string filter)
        {
            var table = Select(tableName, filter);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }

        public DataRow GetNewRow(string tableName, out SqlDataAdapter dataAdapter)
        {
            if (Connection == null)
                Connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            cmd.CommandText = "Select top 0 * FROM " + tableName;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            dataAdapter = da;
            DataRow row = ds.Tables[tableName].NewRow();
            ds.Tables[tableName].Rows.Add(row);
            return row;
        }

        public DataRow Insert(DataRow row, SqlDataAdapter dataAdapter)
        {
            DataRow result = null;

            if (Connection == null)
                Connection = new SqlConnection(ConnectionString);
            
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            string tableName = row.Table.TableName;

            SqlCommand cmd = new SqlCommand();
            //cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            cmd.CommandText = "Select * FROM " + tableName;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, row.Table.TableName);
            ds.Tables[row.Table.TableName].ImportRow(row);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            cmd.ExecuteNonQuery();
            da.Update(ds, row.Table.TableName);

            da.Fill(ds, row.Table.TableName);
            result = ds.Tables[row.Table.TableName].Rows[ds.Tables[row.Table.TableName].Rows.Count - 1];

            return result;
        }

        public void Update(DataRow row, SqlDataAdapter dataAdapter, string tableName)
        {
            if (Connection == null)
                Connection = new SqlConnection(ConnectionString);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            cmd.CommandText = "Select * FROM " + tableName;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            dataAdapter = da;
            ds.Tables[tableName].ImportRow(row);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            
            cmd.ExecuteNonQuery();
            dataAdapter.Update(ds, tableName);
        }

        public void Delete(string tableName, string id)
        {
            if (Connection == null)
                Connection = new SqlConnection(ConnectionString);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM " + tableName + " WHERE ID_ =" + id;
            cmd.Connection = Connection;
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public byte[] InsertFileDataToDB(string fileName)
        {
            //if (Connection == null)
            //    Connection = new SqlConnection(ConnectionString);

            //if (Connection.State == ConnectionState.Closed)
            //    Connection.Open();

            byte[] convertBytes = System.IO.File.ReadAllBytes(fileName);
           // wordDoc = Image.FromFile(fileName);
          //  MemoryStream tmpStream = new MemoryStream();
            ////wordDoc.sa
            ////wordDoc.Save(tmpStream,WdSaveFormat.wdFormatTemplate); // change to other format
            //tmpStream.Seek(0, SeekOrigin.Begin);
            byte[] wordBytes = new byte[(System.IO.File.ReadAllBytes(fileName)).Length];
            //int i = BitConverter.ToInt32(wordBytes, 0);
           // tmpStream.Read(wordBytes, 0, i);

            DataRow dr = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_InsertFileData";
            cmd.Connection = Connection;
            cmd.Parameters.Add("@wordfile", SqlDbType.Binary).Value = wordBytes;
            cmd.ExecuteNonQuery();
            
            //int lastRecordID ;
            //lastRecordID =Int32.Parse(dr["ID"].ToString());
            return wordBytes;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (this.Connection != null)
                    this.Connection.Dispose();
            }

            // Free any unmanaged objects here. 
            //


            disposed = true;
        }
    }
}
