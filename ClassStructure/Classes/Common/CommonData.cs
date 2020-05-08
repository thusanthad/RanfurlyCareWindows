using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public static class CommonData
    {
        public static void FillComboBoxes(List<ComboBox> ListComboBoxes)
        {
            //SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
            DataTable dt;
            //  ComboBox cmb;

            DBCommand dbc = new OLEDBCommand(CommonVariables.GetConnectionString());
            foreach(ComboBox cmb in ListComboBoxes)
            {
                if (cmb.Name.Contains("Customer"))
                {
                    // Customers
                    dt = dbc.GetDataSource("SELECT * FROM vw_Customer");                   
                    cmb.DataSource =dt;
                    cmb.ValueMember = "CustomerId";
                    cmb.DisplayMember = "CustomerName";
                }

                if (cmb.Name.Contains("Programmer"))
                {
                     //// Programmer
                    dt = dbc.GetDataSource("SELECT * FROM vw_Programmer");                    
                    cmb.DataSource = dt;
                    cmb.ValueMember = "PersonId";
                    cmb.DisplayMember = "Programmer";
                }

                if (cmb.Name.Contains("CampaignManager"))
                {
                    //// Campaign Manager
                    dt = dbc.GetDataSource("SELECT * FROM vw_CampaignManager");                    
                    cmb.DataSource = dt;
                    cmb.ValueMember = "PersonId";
                    cmb.DisplayMember = "CampaignManager";
                }

                if (cmb.Name.Contains("JobType"))
                {
                    //// Campaign Manager
                    dt = dbc.GetDataSource("SELECT * FROM vw_JobType");                   
                    cmb.DataSource = dt;
                    cmb.ValueMember = "JobTypeId";
                    cmb.DisplayMember = "JobType";
                }

                if (cmb.Name.Contains("JobStatus"))
                {
                    // Job Status
                    dt = dbc.GetDataSource("SELECT * FROM vw_JobStatus");
                    cmb.DataSource = dt;
                    cmb.ValueMember = "JobStatusId";
                    cmb.DisplayMember = "JobStatus";
                }

                if (cmb.Name.Contains("Task"))
                {
                    // Job Status
                    dt = dbc.GetDataSource("SELECT * FROM vw_Task");
                    cmb.DataSource = dt;
                    cmb.ValueMember = "TaskId";
                    cmb.DisplayMember = "Task";
                }

                if (cmb.Name.Contains("Department"))
                {
                    // Job Status
                    dt = dbc.GetDataSource("SELECT * FROM vw_Department");
                    cmb.DataSource = dt;
                    cmb.ValueMember = "DepartmentId";
                    cmb.DisplayMember = "DepartmentName";
                }
            }           

            dbc.CloseConnection();
        }


        public static void FillRoles(CheckedListBox lstBox)
        {
            DBCommand dbc = new OLEDBCommand(CommonVariables.GetConnectionString());
            DataTable dt = dbc.GetDataSource("SELECT * FROM vw_Role");
            lstBox.DataSource = dt;
            lstBox.ValueMember = "RoleId";
            lstBox.DisplayMember = "Role";
            dbc.CloseConnection();
        }


        public static void FillJobTask(DataGridViewComboBoxColumn cmb)
        {
            DBCommand dbc = new OLEDBCommand(CommonVariables.GetConnectionString());
            DataTable dt = dbc.GetDataSource("SELECT * FROM vw_Task");
            cmb.DataSource = dt;
            cmb.ValueMember = "TaskId";
            cmb.DisplayMember = "Task";
            dbc.CloseConnection();
        }
    }
}
