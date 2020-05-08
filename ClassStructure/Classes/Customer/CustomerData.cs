using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace ClassStructure
{
    public static class CustomerData
    {
        public static void AddNewCustomer(DataTable Customers)
        {
            SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
            string sqlCustomer= string.Empty;
            foreach (DataRow dr in Customers.Rows)
            {
                try
                {
                    sqlCustomer = string.Format("INSERT INTO Customer (CustomerName) VALUES ('{0}')", dr["CustomerName"].ToString());
                    dbc.ExecuteCommand(sqlCustomer);
                }
                catch (Exception ex) { }                
            }
            dbc.CloseConnection();
        }
    }
}
