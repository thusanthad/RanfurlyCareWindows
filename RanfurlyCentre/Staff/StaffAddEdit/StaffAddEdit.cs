using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class StaffAddEdit : Form
    {
        protected StaffAddEditBase _saeb;
        protected bool _changedOccured;
        public Jarvis Jarvis { get; set; }

        public StaffAddEdit(Person staff, string editType )
        {
            InitializeComponent();
            if (editType == "edit")
                _saeb = new StaffEdit(this, (Staff)staff);
            else
                _saeb = new StaffAdd(this, (Staff)staff);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!Jarvis.CurrentUser.UserHasPermissionForAction("Staff", "Edit"))
                return;
            //if (_saeb.Validated())
            //{
            //    try
            //    {
            SaveChanges();
                //    if (Application.OpenForms["StaffSearch"] as StaffSearch != null)
                //    {
                //        StaffSearch frm1 = (StaffSearch)Application.OpenForms["StaffSearch"];
                //        frm1.LoadStaffList();
                //        frm1.SetDataSource();
                //    }
                //    this.Close();
                //}                        
            //}
               
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
        }

        private void PopulateTitle()
        {
            TitleData td = new TitleData();
            cmbTitle.DataSource = td.GetList();

            cmbTitle.DisplayMember = "TitleName";
            cmbTitle.ValueMember = "TitleId";

        }

        private void CmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
            {
                if (_saeb.Validated())
                {
                    try
                    {
                        _saeb.update();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

       

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_saeb.Validated())
                {
                    StaffLocationAllocation swa = new StaffLocationAllocation(_saeb.Staff, "allocate");
                    {
                        swa.ShowDialog();
                        if (swa.DialogResult == DialogResult.OK)
                        {
                            _saeb.PopulateWorkCentres();
                            //btnUpdae.Enabled = true;
                        }
                    }
                }
                else
                {
                    this.tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

//        private void removeStaffToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if(_saeb.Staff.WorkCentres.Count>0)
//                {
//                    StaffWorkCentreAllocation swa = new StaffWorkCentreAllocation(_saeb.Staff,"remove");
//                    {
//                        swa.ShowDialog();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//}

        public void ChangesOccuredEvent(object sender, EventArgs e)
        {
            _changedOccured = true;
            //btnUpdae.Enabled = true;
        }

        private void StaffAddEdit_Shown(object sender, EventArgs e)
        {
            _saeb.SetTextChangeDEventForControls();
        }

        //private void StaffAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //if (_changedOccured && _saeb is StaffEdit)
        //    //{
        //    //    if (MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    //    {
        //    //        SaveChanges();
        //    //    }
        //    //    else
        //    //    {
        //    //if (Application.OpenForms["StaffSearch"] as StaffSearch != null)
        //    //{
        //    //    StaffSearch frm1 = (StaffSearch)Application.OpenForms["StaffSearch"];
        //    //    frm1.LoadStaffList();
        //    //    frm1.SetDataSource();
        //    //}

        //    //    }
        //    //}
        //}
    }
}
