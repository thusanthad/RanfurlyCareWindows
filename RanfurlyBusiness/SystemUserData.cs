using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class SystemUserData
    {
        public static SystemUser GetSystemUser(string UserName, string Password)
        {
            DataTable dt;
            DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);            
            dt = dbc.GetDataTable(string.Format(SQLCommands.User,UserName,Password));
            dbc.CloseConnection();
            return CreateUser(dt);            
        }

       
        private static SystemUser CreateUser(DataTable dt)
        {
            if (dt.Rows.Count >= 1)
            {
                SystemUser user = CheckUserType(dt); //new SystemUser();//
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.UserId = (int)dt.Rows[0]["UserId"];
                user.PersonId = (int)dt.Rows[0]["StaffId"];
                user.UserPassword  = dt.Rows[0]["UserPassword"].ToString();
                user.PersonFullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                user.PersonFirstName = dt.Rows[0]["FirstName"].ToString();
                user.PersonLastName = dt.Rows[0]["LastName"].ToString();     
                return user;               
            }            
            else
                return null;           
        }

        public static void UpdateUserPassword(SystemUser user)
        {
            string sql = string.Format(SQLCommands.UpdateUser, user.UserPassword, user.UserId);
            DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            dbc.ExecuteCommand(sql);
            dbc.CloseConnection();           
        }

        public static void CreateUser(SystemUser user)
        {
            // Create Person            
            DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            string sql = string.Format(SQLCommands.CreatePerson, user.PersonFirstName, user.PersonLastName);
            int lastPersonId = dbc.ExecuteCommand(sql);

             sql = string.Format(SQLCommands.CreateUser, user.UserName, user.UserPassword,lastPersonId);
            int lastUserId = dbc.ExecuteCommand(sql);

            foreach (string role in user.Roles)
            {
                sql = string.Format(SQLCommands.CreateRole, lastUserId, role);
                dbc.ExecuteCommand(sql);
            }
            dbc.CloseConnection();
        }

        private static SystemUser CheckUserType(DataTable dt)
        {
            string[] roles = new string[dt.Rows.Count];
            SystemUser user = new SystemUser();
            int i = -1;

            if (dt.Rows.Count > 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    i += 1;
                    roles[i] = dt.Rows[i]["Role"].ToString();
                }
            }
            else
                roles[0] = dt.Rows[0]["Role"].ToString();

            //if (roles.Contains("Developer"))
            //    user = new Developer(new OnlyMyCurrentJobs());
            //else if (roles.Contains("Campaign Manager"))
            //    user = new CampaignManager(new OnlyMyCurrentJobs());
            //else if (roles.Contains("Admin"))
            //    user = new AnyOtherUser(new AllCurrentJobs());
            //else
            //    user = new AnyOtherUser(new AllCurrentJobs());

            user.Roles = roles;
            return user;
        }
    }
}

