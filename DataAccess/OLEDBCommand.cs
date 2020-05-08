using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DataAccess
{
    public class OLEDBCommand:DBCommand
    {
        private OleDbCommand cmd;
        private OleDbConnection con;// = new OleDbConnection(CommonVariables.connectionString);
        private OleDbDataAdapter ad = new OleDbDataAdapter();

        public OLEDBCommand(string conString):base(conString)
            {
            cmd = new OleDbCommand();
            con = new OleDbConnection(_connectionString);
            ad = new OleDbDataAdapter();
            //protected object _cmd;

        }

        public override DataTable GetDataSource(string strSQL)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = strSQL; 
            cmd.Connection = con;
            ad.SelectCommand = cmd;
            ad.Fill(dt);
            return dt;
        }
    }
}
