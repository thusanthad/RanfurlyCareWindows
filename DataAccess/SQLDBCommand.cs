using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public  class SQLDBCommand
    {  
        public enum TransactionType
        {
            WithTransaction,
            WithoutTransaction
        }
      
        private  SqlCommand cmd=new SqlCommand();
        private SqlConnection con = new SqlConnection(CommonVariables.connectionString);
        private  string rtnPrm = "@rtnValue";
        private  DataTable rtnPrmDt=null;
        private  SqlDataAdapter ad=null;
        private  SqlTransaction tr = null;

        public SQLDBCommand(TransactionType trType)
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
                throw new Exception (ex.Message);
            }
        }
       
        public int ReturnValue()
        {
            return (int)cmd.Parameters["@rtnValue"].Value;
        }
       
        public void addPrm(string prmName, object prmValue)
            {
                cmd.Parameters.AddWithValue(prmName, prmValue);
            }
       
       public void AddPrmRtn()
        {
            cmd.Parameters.AddWithValue(rtnPrm, "");
            cmd.Parameters[rtnPrm].Direction = ParameterDirection.ReturnValue;
        }        
       
        public void ClearPrm()
        {
            cmd.Parameters.Clear();
        }   
       
        public void ConClose()
        {
            con.Close();
            con.Dispose();
        }   
         
        public bool ExecSP(string procName)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }

        public void Commit()
        {            
            try
            {
                cmd.Transaction.Commit();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Rollback()
        {
            try
            {                  
                cmd.Transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
           public DataTable GetDataSource(string procName)
           {
             ad = new SqlDataAdapter();
             rtnPrmDt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            try
               {
                ad.SelectCommand = cmd;
                ad.Fill(rtnPrmDt);
                return rtnPrmDt;
               }
              catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               } 
           } 
    }
}


 