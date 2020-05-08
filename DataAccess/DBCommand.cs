using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace DataAccess
{
    public  class DBCommand
    {
        public enum TransactionType
        {
            WithTransaction,
            WithoutTransaction
        }

        private OleDbCommand cmd = new OleDbCommand();
        private OleDbConnection con = new OleDbConnection(Singleton.GetConnectionString());        
        private OleDbDataAdapter ad = new OleDbDataAdapter();
        private OleDbTransaction tr = null;

        public DBCommand(TransactionType trType)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                if (trType == TransactionType.WithTransaction)
                {
                    tr = con.BeginTransaction();
                    cmd.Transaction = tr;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DBCommand()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                //if (trType == TransactionType.WithTransaction)
                //{
                //    tr = con.BeginTransaction();
                //    cmd.Transaction = tr;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetDataTable(string strSQL)
        {
                DataTable dt = new DataTable();
                cmd.CommandText = strSQL;
                cmd.Connection = con;
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                return dt; 
        }

        public int ExecuteCommand(string strSQL)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Select @@Identity";
                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateDatabase(string UpdateString)
        {
            cmd.CommandText = UpdateString;
            cmd.ExecuteNonQuery();
        }
    
        public void CloseConnection()
        {
            con.Close();
            con.Dispose();
        }

        public void CommitTransactions()
        {
            tr.Commit();
        }

        public void rollbackTransactions()
        {
            tr.Rollback();
        }
    }
}


 