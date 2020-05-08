using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Web;
using RanfurlyBusiness;


namespace RanfurlyCentre
{
    public partial class MDIMainForm : Form
    {
        private int childFormNumber = 0;
        //public SystemUser CurrentUser { get; set; }
        public Jarvis Jarvis { get; set; }
        private Welcome frm;

        public MDIMainForm(Jarvis jarvis)
        {
            InitializeComponent();
            Jarvis = jarvis;
        }

        private void MDIMainForm_Load(object sender, EventArgs e)
        {
            frm = new Welcome(Jarvis);
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

       

        private void jobsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Report", "View"))
                return;
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        public void OpenWelcomeForm()
        {
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.lblCurrentLogin.Text = "Current login - " + Jarvis.CurrentUser.FirstName + " " + Jarvis.CurrentUser.LastName;
            //frm.lblRole.Text = "Role - " + InterfaceTasks.GetUserRole(Jarvis.CurrentUser);
            //frm.lblMessage.Text = Jarvis.CurrentUser.ShowWelcomeMessage();
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
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Student", "View"))
                return;
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
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Staff", "View"))
                return;
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
            
        }

        private void tsStaff_Click_1(object sender, EventArgs e)
        {

        }

        //private void addStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    //if (Application.OpenForms["StudentAdd"] as StudentAdd == null)
        //    //{

        //    //StudentAddEditClass saec = new StudentAddEditClass(new Student());
        //    StudentAddEdit frm = new StudentAddEdit(new Student(),Jarvis);
        //    frm.headerLabel.Text = "Student Add";
        //        //frm.MdiParent = this;
        //        //frm.Dock = DockStyle.Fill;
        //        //frm.FormBorderStyle = FormBorderStyle.None;
        //        frm.ShowDialog();
        //    if(frm.DialogResult == DialogResult.OK)
        //    {
        //        if (Application.OpenForms["StudentSearch"] as StudentSearch != null)
        //        {
        //            StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
        //            frm1.LoadStudentList();
        //            frm1.SetDataSource();
        //        }
        //        //{
        //    }
        //    //}
        //    //else
        //    //{
        //    //    StudentAdd frm1 = (StudentAdd)Application.OpenForms["StudentAdd"];
        //    //    frm1.Focus();
        //    //}
        //}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox(Jarvis.License);
            ab.ShowDialog();        }

        private void ethnicityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Admin", "View"))
                return;
            EthnicityEdit ab = new EthnicityEdit();
            ab.ShowDialog();
            if(ab.DialogResult==DialogResult.OK)
            {
                if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
                {
                    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
                    frm1.PopulateEthnicityComboBox();
                }
            }
        }

        private void addWorkCentreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Admin", "View"))
                return;
            LocationEdit ab = new LocationEdit();
            ab.ShowDialog();
        }

        //private void addNextOfKinToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        //private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DoctorAddEdit sa = new DoctorAddEdit(new Doctor(), "add");
        //    sa.ShowDialog();
        //    if (sa.DialogResult == DialogResult.OK)
        //    {
        //        if (Application.OpenForms["DoctorSearch"] as DoctorSearch != null)
        //        {
        //            DoctorSearch frm1 = (DoctorSearch)Application.OpenForms["DoctorSearch"];
        //            frm1.LoadFullList();
        //            frm1.SetDataSource();
        //        }
        //    }
        //}

        //private void addStaffToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    if (!Jarvis.CurrentUser.UserHasPermissionForAction("Staff", "Add"))
        //        return;
        //    StaffAddEdit sa = new StaffAddEdit(new Staff(), "add");
        //    sa.Jarvis = Jarvis;
        //    sa.ShowDialog();
        //    if(sa.DialogResult==DialogResult.OK)
        //    {
        //        if (Application.OpenForms["StaffSearch"] as StaffSearch != null)
        //        {
        //            StaffSearch frm1 = (StaffSearch)Application.OpenForms["StaffSearch"];
        //            frm1.LoadStaffList();
        //            frm1.SetDataSource();
        //        }
        //    }
        //}

        private void otherProfessionalServiceProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Medical Service", "View"))
                return;
            if (Application.OpenForms["ProfessionalServicesSearch"] as ProfessionalServicesSearch == null)
            {
                ProfessionalServicesSearch frm = new ProfessionalServicesSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                ProfessionalServicesSearch frm1 = (ProfessionalServicesSearch)Application.OpenForms["ProfessionalServicesSearch"];
                frm1.Focus();
            }
        }

        private void doctorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Medical Service", "View"))
                return;
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

        private void createNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("User", "View"))
                return;
            SystemUserList systemUserLia = new SystemUserList();
            systemUserLia.ShowDialog();
        }

        private void incidentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Incident", "View"))
                return;
            if (Application.OpenForms["Incidents"] as IncidentSearch == null)
            {
                IncidentSearch frm = new IncidentSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                IncidentSearch frm1 = (IncidentSearch)Application.OpenForms["Incidents"];
                frm1.Focus();
            }
        }

        private void importRollCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("RollCall", "Add"))
                return;
            ImportResidentRollCall irc = new ImportResidentRollCall(Jarvis);
            irc.ShowDialog();
            if(irc.DialogResult == DialogResult.OK)
            {


            }
        }

        private void rollCallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("RollCall", "View"))
                return;
            if (Application.OpenForms["RollCallSearch"] as RollCallSearch == null)
            {
                RollCallSearch frm = new RollCallSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                RollCallSearch frm1 = (RollCallSearch)Application.OpenForms["RollCallSearch"];
                frm1.Focus();
            }
        }

        private void removeImportedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("RollCall", "Add"))
                return;
            ResidentRollCallFileRemove frm = new ResidentRollCallFileRemove();
            frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
                //LoadRollCallList();
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Jarvis.CurrentUser.UserHasPermissionForAction("Backup", "View"))
                    return;
                BackupDatabase();
                MessageBox.Show("Database Backed up successfully", "Database backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { }            
        }

        private void BackupDatabase()
        {
            try
            {
                Jarvis.BackupDatabase();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void addNewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!Jarvis.CurrentUser.UserHasPermissionForAction("Appointment", "Add"))
        //        return;
        //    Appointments.AddEditAppointment  frm = new Appointments.AddEditAppointment(new DoctorAppointment());
        //    frm.ShowDialog();
        //}

        private void viewAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Appointment", "View"))
                return;
            if (Application.OpenForms["AppointmentSearch"] as AppointmentSearch == null)
            {
                AppointmentSearch frm = new AppointmentSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                AppointmentSearch frm1 = (AppointmentSearch)Application.OpenForms["AppointmentSearch"];
                frm1.Focus();
            }
        }

        private void MDIMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackupDatabase();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(Jarvis);
            cp.ShowDialog();
            if(cp.DialogResult == DialogResult.OK)
                MessageBox.Show("Password changed successfully", "Password change", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void adminChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Admin", "Admin"))
                return;
            AdminChangePassword cp = new AdminChangePassword(Jarvis);
            cp.ShowDialog();
            if (cp.DialogResult == DialogResult.OK)
                MessageBox.Show("Password changed successfully", "Password change", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Watch this space, coming soon in the next version", "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Appointment", "View"))
                return;
            if (Application.OpenForms["AppointmentSearch"] as AppointmentSearch == null)
            {
                AppointmentSearch frm = new AppointmentSearch(this);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
            }
            else
            {
                AppointmentSearch frm1 = (AppointmentSearch)Application.OpenForms["AppointmentSearch"];
                frm1.Focus();
            }
        }







        //private void doctorsToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    if (Application.OpenForms["DoctorSearch"] as DoctorSearch == null)
        //    {
        //        DoctorSearch frm = new DoctorSearch(this);
        //        frm.MdiParent = this;
        //        frm.Dock = DockStyle.Fill;
        //        frm.FormBorderStyle = FormBorderStyle.None;
        //        frm.Show();
        //    }
        //    else
        //    {
        //        DoctorSearch frm1 = (DoctorSearch)Application.OpenForms["DoctorSearch"];
        //        frm1.Focus();
        //    }
        //}





        //private void CheckAdminFunctions()
        //{
        //    if (CurrentUser.Roles.Contains("Admin"))
        //        createNewUserToolStripMenuItem.Enabled = true;
        //}
    }
}
