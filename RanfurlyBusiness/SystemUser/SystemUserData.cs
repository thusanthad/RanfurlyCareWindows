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
        protected DBCommand dbc;// = new DBCommand(DBCommand.TransactionType.WithoutTransaction);

        public SystemUserData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }
        public SystemUserData(string WithTransaction)
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithTransaction);
        }

        public List<Person> GetList()
        {
            List<Person> list = new List<Person>();

            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_SystemUsers");

            foreach (DataRow dr in dt.Rows)
            {
                SystemUser systemUser = new SystemUser
                {
                    UserId = (int)dr["UserId"],
                    UserName = dr["UserName"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),                    
                    Email = dr["Email"].ToString()
                };
                if (dr["StaffId"].ToString() != string.Empty)
                {
                    systemUser.PersonId = (int)dr["StaffId"];
                    systemUser.IsStaffMember = true;
                }
                   
                //else
                //    systemUser.PersonId = null;

                systemUser.RoleActions = GetUserRoleActions(systemUser);
                systemUser.OriginalRoleActions.AddRange(systemUser.RoleActions);
                list.Add(systemUser);

            }
            return list;
        }

        public SystemUser GetSystemUser(string UserName, string Password)
        {
            DataTable dt;
            //DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);            
            dt = dbc.GetDataTable(string.Format(SQLCommands.User,UserName,Password));
            //dbc.CloseConnection();
            SystemUser su = GetUser(dt);
            if(su !=null)
            {
                su.RoleActions = GetUserRoleActions(su);
            }            
            return su;        
        }

       
        private SystemUser GetUser(DataTable dt)
        {
            if (dt.Rows.Count >= 1)
            {
                //SystemUser user = CheckUserType(dt); //new SystemUser();//
                SystemUser user = new SystemUser
                {
                    UserName = dt.Rows[0]["UserName"].ToString(),
                    UserId = (int)dt.Rows[0]["UserId"],
                    UserPassword = dt.Rows[0]["UserPassword"].ToString(),
                    FirstName = dt.Rows[0]["FirstName"].ToString(),
                    LastName = dt.Rows[0]["LastName"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),

            };
                if (dt.Rows[0]["StaffId"].ToString() != string.Empty)
                    user.PersonId = (int)dt.Rows[0]["StaffId"];
                //else
                //    user.PersonId = null;
                return user;               
            }            
            else
                return null;           
        }

        //public static void UpdateUserPassword(SystemUser user)
        //{
        //    string sql = string.Format(SQLCommands.UpdateUser, user.UserPassword, user.UserId);
        //    DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        //    dbc.ExecuteCommand(sql);
        //    dbc.CloseConnection();           
        //}

        public void CreateUser(SystemUser user)
        {
            if (CheckIfUserExists(user))
                throw new Exception("User '" + user.UserName + "' exists");

            CommonFunctions.UpdateApostrophe(user);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO SystemUser(FirstName,LastName,UserName, Email, UserPassword,StaffId) VALUES(");
            sb.Append("'" + user.FirstName + "'");
            sb.Append(",'"+ user.LastName + "'");
            sb.Append(",'" + user.UserName + "'");
            sb.Append(",'" + user.Email+ "'");
            sb.Append(",'" + user.UserPassword + "'");
            if (user.PersonId !=0)
                sb.Append(","+ user.PersonId);
            else
                sb.Append(",null");

            sb.Append(")");

            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
            dbc.CloseConnection();
        }

        private bool CheckIfUserExists(SystemUser user)
        {
            DataTable dt;
            if (user.IsStaffMember)
            {
                dt = dbc.GetDataTable("SELECT * FROM vw_SystemUsers WHERE StaffIf=" + user.PersonId);                
            }
            else
            {
                dt = dbc.GetDataTable("SELECT * FROM vw_SystemUsers WHERE UserName='" + user.UserName+"'");
            }
            return dt.Rows.Count > 0;
        }

        public void ChangePassword(SystemUser user)
        {
            //SystemUser systemUser= GetSystemUser(user.UserName, user.UserPassword);
            //if(systemUser==null)
            //{
            //    throw new Exception("Incorrect password");
            //}

            string sql = "UPDATE SystemUser SET UserPassword ='" + user.UserNewPassword + "' WHERE UserId="+user.UserId;
            dbc.ExecuteCommand(sql);
        }

        //private static SystemUser CheckUserType(DataTable dt)
        //{
        //    string[] roles = new string[dt.Rows.Count];
        //    SystemUser user = new SystemUser();
        //    int i = -1;

        //    if (dt.Rows.Count > 1)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            i += 1;
        //            roles[i] = dt.Rows[i]["Role"].ToString();
        //        }
        //    }
        //    else
        //        roles[0] = dt.Rows[0]["Role"].ToString();

        //    //if (roles.Contains("Developer"))
        //    //    user = new Developer(new OnlyMyCurrentJobs());
        //    //else if (roles.Contains("Campaign Manager"))
        //    //    user = new CampaignManager(new OnlyMyCurrentJobs());
        //    //else if (roles.Contains("Admin"))
        //    //    user = new AnyOtherUser(new AllCurrentJobs());
        //    //else
        //    //    user = new AnyOtherUser(new AllCurrentJobs());

        //    user.Roles = roles;
        //    return user;
        //}

        private List<UserRoleAction> GetUserRoleActions(SystemUser user)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_UserRoleActions WHERE UserId = "+user.UserId);
            List<UserRoleAction> list = new List<UserRoleAction>();
            foreach (DataRow dr in dt.Rows)
            {
                UserRoleAction ua = new UserRoleAction
                {
                    UserRoleActionId = (int)dr["UserRoleActionId"],
                    UserId = (int)dr["UserId"],
                    RoleId = (int)dr["RoleId"],
                    RoleActionId = (int)dr["RoleActionid"],
                    Role = dr["Role"].ToString(),
                    RoleAction = dr["RoleAction"].ToString()
                };
                list.Add(ua);
            }
            return list;
        }

        public List<Role> GetRoles()
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM Role");
            List<Role> list = new List<Role>();
            foreach (DataRow dr in dt.Rows)
            {
                Role role = new Role
                {
                    RoleId = (int)dr["RoleId"],
                    RoleName = dr["Role"].ToString()
                };
                list.Add(role);
            }
            return list;
        }

        public void SaveSystemUserRoleActions(List<SystemUser> systemUsers)
        {         
            foreach (SystemUser systemUser in systemUsers)
            {
                List<UserRoleAction> itemsToDelete = GetRoleActionsToDelete(systemUser);//systemUser.OriginalRoleActions.Except(systemUser.RoleActions).ToList();
                List<UserRoleAction> itemsToAdd = GetRoleActionsToAdd(systemUser);// systemUser.RoleActions.Except(systemUser.OriginalRoleActions).ToList();
                //string sql = "DELETE from UserRoleAction WHERE UserId=" + systemUser.UserId;
                //DataTable dt = dbc.GetDataTable("SELECT * FROM UserRoleAction WHERE UserId="+systemUser.UserId);
                UpdatesystemUser(systemUser);

                //dbc.ExecuteCommand(sql);
                foreach (UserRoleAction roleAction in itemsToAdd)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO UserRoleAction (UserId,RoleId,RoleActionId) VALUES (");
                    sb.Append(systemUser.UserId);
                    sb.Append("," + roleAction.RoleId);
                    sb.Append("," + roleAction.RoleActionId);
                    sb.Append(")");
                    string sql = sb.ToString();
                    dbc.ExecuteCommand(sql);
                }

                foreach (UserRoleAction roleAction in itemsToDelete)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM UserRoleAction Where UserRoleActionId=" + roleAction.UserRoleActionId);
                    string sql = sb.ToString();
                    dbc.ExecuteCommand(sql);
                }
            }
            dbc.CommitTransactions();
            dbc.CloseConnection();
        }

        public void UpdatesystemUser(SystemUser user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE SystemUser SET ");
            sb.Append("UserName='"+user.UserName +"'");
            sb.Append(",FirstName='" + user.FirstName + "'");
            sb.Append(",LastName='" + user.LastName + "'");
            if(user.Email !=null & user.Email !=string.Empty)
                sb.Append(",Email='" + user.Email + "'");
            else
                sb.Append(",Email=null");
            sb.Append(" WHERE UserId = "+user.UserId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);

        }

        private List<UserRoleAction> GetRoleActionsToAdd(SystemUser user)
        {
            List<UserRoleAction> newList = new List<UserRoleAction>();
            foreach (UserRoleAction roleAction in user.RoleActions)
            {
                UserRoleAction action = user.OriginalRoleActions.Find(x => x.UserId == user.UserId && x.RoleId == roleAction.RoleId && x.RoleActionId == roleAction.RoleActionId);
                if (action == null)
                    newList.Add(roleAction);
            }
            return newList;
        }

        private List<UserRoleAction> GetRoleActionsToDelete(SystemUser user)
        {
            List<UserRoleAction> newList = new List<UserRoleAction>();
            foreach (UserRoleAction roleAction in user.OriginalRoleActions)
            {
                UserRoleAction action = user.RoleActions.Find(x => x.UserId == user.UserId && x.RoleId == roleAction.RoleId && x.RoleActionId == roleAction.RoleActionId);
                if (action == null)
                    newList.Add(roleAction);
            }
            return newList;
        }
    }
}

