using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Web;
using RanfurlyBusiness;


namespace RanfurlyCentre
{
    public partial class MDIMainForm : Form
    {
        private int childFormNumber = 0;
        public SystemUser CurrentUser { get; set; }
        private Welcome frm;

        public MDIMainForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name !="Welcome")
                    childForm.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripJobSearch_Click(object sender, EventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["JobSearch"] as JobSearch == null)
            //{
            //    JobSearch frm = new JobSearch(CurrentUser);
            //    frm.MdiForm = this;
            //    frm.MdiParent = this;
            //    frm.Dock = DockStyle.Fill;
            //    frm.FormBorderStyle = FormBorderStyle.None;
            //    frm.Show();
            //}
            //else
            //{
            //    JobSearch frm1 = (JobSearch)Application.OpenForms["JobSearch"];
            //    frm1.Focus();
            //}
        }

        private void MDIMainForm_Load(object sender, EventArgs e)
        {
            frm = new Welcome();
            OpenWelcomeForm();

            this.menuStrip.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();
            });

            //this.menuStrip.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            //{
            //    x.MouseLeave += (obj, arg) => ((ToolStripDropDownItem)obj).HideDropDown();
            //});

        }

        private void jobsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void OpenWelcomeForm()
        {
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.lblCurrentLogin.Text = "Current login - " + CurrentUser.PersonFullName;
            frm.lblRole.Text = "Role - " + InterfaceTasks.GetUserRole(CurrentUser);
            frm.lblMessage.Text = CurrentUser.ShowWelcomeMessage();
            frm.Show();
        }

        private void addNewJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["AddNewJob"] as AddNewJob == null)
            //{
            //    AddNewJob frm = new AddNewJob();
            //    frm.MdiParent = this;
            //    frm.Dock = DockStyle.Fill;
            //    frm.FormBorderStyle = FormBorderStyle.None;
            //    frm.Show();
            //}
            //else
            //{
            //    AddNewJob frm1 = (AddNewJob)Application.OpenForms["AddNewJob"];
            //    frm1.Focus();
            //}
        }

        private void jobReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["JobReportsNew"] as SpecialReports == null)
            //{
            //    SpecialReports frm = new SpecialReports(CurrentUser);
            //    frm.MdiParent = this;
            //    frm.MdiForm = this;
            //    frm.Dock = DockStyle.Fill;
            //    frm.FormBorderStyle = FormBorderStyle.None;
            //    frm.Show();
            //}
            //else
            //{
            //    SpecialReports frm1 = (SpecialReports)Application.OpenForms["JobReportsNew"];
            //    frm1.Focus();
            //}
        }

        //private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ChangePassword cp = new ChangePassword();
        //    cp.CurrentUser = CurrentUser;
        //    cp.ShowDialog();
        //}

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (CurrentUser.Roles.Contains("Admin"))
            //{
            //    CreateUser cp = new CreateUser();
            //    cp.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Only users with 'Admin' rights can create a new user", "Create new user account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tsStudent_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["StudentSearch"] as StudentSearch == null)
            {
                StudentSearch frm = new StudentSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
                frm1.Focus();
            }
        }

        private void tsStaff_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["StaffSearchNew"] as StaffSearch == null)
            {
                StaffSearch frm = new StaffSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                StaffSearch frm1 = (StaffSearch)Application.OpenForms["StaffSearch"];
                frm1.Focus();
            }
        }

        private void menuStrip_MouseEnter(object sender, EventArgs e)
        {
            menuStrip.Cursor = Cursors.Hand;
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doctorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DoctorSearch"] as DoctorSearch == null)
            {
                DoctorSearch frm = new DoctorSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                DoctorSearch frm1 = (DoctorSearch)Application.OpenForms["DoctorSearch"];
                frm1.Focus();
            }
        }

        private void tsStaff_Click_1(object sender, EventArgs e)
        {

        }

        private void addStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //if (Application.OpenForms["StudentAdd"] as StudentAdd == null)
            //{
                StudentAdd frm = new StudentAdd(this);
                //frm.MdiParent = this;
                //frm.Dock = DockStyle.Fill;
                //frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
            //}
            //else
            //{
            //    StudentAdd frm1 = (StudentAdd)Application.OpenForms["StudentAdd"];
            //    frm1.Focus();
            //}
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();        }

        private void ethnicityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EthnicityEdit ab = new EthnicityEdit();
            ab.ShowDialog();
        }

        private void addWorkCentreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkCentreEdit ab = new WorkCentreEdit();
            ab.ShowDialog();
        }

       



        //private void CheckAdminFunctions()
        //{
        //    if (CurrentUser.Roles.Contains("Admin"))
        //        createNewUserToolStripMenuItem.Enabled = true;
        //}
    }
}
