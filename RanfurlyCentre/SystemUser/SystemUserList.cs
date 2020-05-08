using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class SystemUserList : Form
    {
        protected List<SystemUser> _userList;
        protected List<Role> _roles;
        protected SystemUserData sud;
        protected SystemUser _selectedSystemUser;
        public SystemUserList()
        {
            InitializeComponent();
            sud = new SystemUserData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save changes?","Save changes",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                try
                {
                    sud = new SystemUserData("WithTransaction");
                   // sud = new SystemUserData();
                    sud.SaveSystemUserRoleActions(_userList);
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Save changes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                }
        }

        private void SystemUserList_Load(object sender, EventArgs e)
        {
            treeView1.AfterCheck -= treeView1_AfterCheck;
            dgSystemUsers.RowEnter -= dgSystemUsers_RowEnter;
            PopulateRoles();
            PopulateUsers();            
            treeView1.ExpandAll();
           
            if (_userList.Count>0)
            SelectedUser(0);
        }

        private void PopulateRoles()
        {      
            _roles = sud.GetRoles();
        }

        private void PopulateUsers()
        {
            dgSystemUsers.AutoGenerateColumns = false;
            _userList = sud.GetList().ConvertAll(x => x as SystemUser);
            dgSystemUsers.DataSource = null;
            dgSystemUsers.DataSource = _userList;
            dgSystemUsers.Refresh();
            lblUserCount.Text = "User count: " + _userList.Count;
            lblUserCount.Refresh();
        }

        private void SelectedUser(int rowIndex)
        {
            SystemUser user = GetCurrentSystemUser(rowIndex);
            _selectedSystemUser = user;
            foreach (UserRoleAction ra in user.RoleActions)
            {
                if (ra.RoleId == 1)
                {
                    IsSystemAdministrator(true);
                    break;
                }
                else
                {
                   SelectNodes(ra);
                }
            }
        }

        private bool SelectNodes(UserRoleAction Ra)
        {
            TreeNode[] treeNode = treeView1.Nodes.Find(Ra.Role.Replace(" ",""), false);
            if (treeNode[0] != null)
            {
                treeNode[0].Checked = true;
                foreach (TreeNode node1 in treeNode[0].Nodes)
                {
                    if (node1.Name == Ra.Role.Replace(" ", "") + Ra.RoleAction)
                    {
                        //return true;
                        node1.Checked = true;
                    }
                }

            }
            return false;
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Name != "SystemAdministrtator")
            {
                if (treeView1.Nodes["SystemAdministrtator"].Checked)
                    e.Cancel = true;
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Name == "SystemAdministrtator")
                {
                    SelectUnselectAdminNode(e.Node.Checked);
                    AddRemoveUserRoleAction(e.Node, e.Node);
                }
                else
                {
                    if (e.Node.Nodes.Count > 0) // parent node checked
                    {
                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            node.Checked = e.Node.Checked;
                            AddRemoveUserRoleAction(e.Node, node);
                        }
                    }
                    else
                    {
                        if (e.Node.Parent != null)
                        {
                            if (CheckIfAnyChildNodeIsChecked(e.Node.Parent))
                            {
                                e.Node.Parent.Checked = true;// e.Node.Checked;
                            }
                            else
                            {
                                e.Node.Parent.Checked = false;
                            }
                            AddRemoveUserRoleAction(e.Node.Parent, e.Node);
                        }
                    }
                }

            }
        }

        private void IsSystemAdministrator(bool YesNo)
        {
            treeView1.BeforeCheck -= treeView1_BeforeCheck;
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Checked = YesNo;
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = YesNo;
                }
            }
            treeView1.BeforeCheck += treeView1_BeforeCheck;
        }

        private void SystemUserList_Shown(object sender, EventArgs e)
        {
            treeView1.AfterCheck += treeView1_AfterCheck;
           // dgSystemUsers.RowLeave += dgSystemUsers_RowLeave;
            dgSystemUsers.RowEnter += dgSystemUsers_RowEnter;
        }

        private bool CheckIfAnyChildNodeIsChecked(TreeNode ParentNode)
        {
            bool returnValue = false;
            foreach (TreeNode node in ParentNode.Nodes)
            {
                if (node.Checked)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        private void SelectUnselectAdminNode(bool selection)
        {
            treeView1.BeforeCheck -= treeView1_BeforeCheck;
            foreach (TreeNode parentNode in treeView1.Nodes)
            {
                parentNode.Checked = selection;
                foreach (TreeNode node in parentNode.Nodes)
                {
                    node.Checked = selection;
                }
            }
            treeView1.BeforeCheck += treeView1_BeforeCheck;
        }

       
        private SystemUser GetCurrentSystemUser(int rowIndex)
        {
            int userId = (int)dgSystemUsers.Rows[rowIndex].Cells[0].Value;
            
            SystemUser user = _userList.Find(x => x.UserId == userId);
            return user;
        }

        private int FindRoleId(string RoleName)
        {
            Role role = _roles.Find(x => x.RoleName == RoleName);
            return role.RoleId;
        }

        private int FindRoleActionId(string RoleActionName)
        {
            if (RoleActionName.Contains("Add"))
                return 1;
            else if (RoleActionName.Contains("Edit"))
                return 2;
            else
                return 3;
        }

        private void AddRemoveUserRoleAction(TreeNode parentNode, TreeNode childNode)
        {
            if (parentNode.Name == "SystemAdministrtator")
            {
                _selectedSystemUser.RoleActions.Clear();
                if (parentNode.Checked)
                {                    
                    UserRoleAction userRoleAction = new UserRoleAction();
                    userRoleAction.Role = "System Administrator";
                    userRoleAction.RoleId = 1;
                    userRoleAction.RoleAction = "Admin";
                    userRoleAction.RoleActionId = 4;
                    _selectedSystemUser.RoleActions.Add(userRoleAction);
                }
            }
            else
            {
                int roleId = FindRoleId(parentNode.Text); 
                int roleActionId = FindRoleActionId(childNode.Name);
                if (childNode.Checked)
                {
                    UserRoleAction userRoleAction = new UserRoleAction();
                    userRoleAction.Role = parentNode.Name;
                    userRoleAction.RoleId = roleId;// FindRoleId(parentNode.Name);
                    userRoleAction.RoleAction = childNode.Text;
                    userRoleAction.RoleActionId = roleActionId;// FindRoleActionId(childNode.Name);
                    userRoleAction.UserId = _selectedSystemUser.UserId;
                    _selectedSystemUser.RoleActions.Add(userRoleAction);
                }
                else
                {                    
                    UserRoleAction adminRoleAction = _selectedSystemUser.RoleActions.Find(x => x.RoleId ==roleId &&x.RoleActionId==roleActionId );
                    if (adminRoleAction != null)
                        _selectedSystemUser.RoleActions.Remove(adminRoleAction);
                }
            }
        }

        private void dgSystemUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectUnselectAdminNode(false);
            SelectedUser(e.RowIndex);
        }

        private void addMNewSystemUsetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSystemUser addNewSystemUser = new AddNewSystemUser(_userList);
            addNewSystemUser.ShowDialog();
            if (addNewSystemUser.DialogResult == DialogResult.OK)
            {
                PopulateUsers();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
