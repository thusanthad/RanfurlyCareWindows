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
    public partial class ProfessionalServicesSearch : Form
    {
        // SystemUser currentUser;
        public MDIMainForm _mdiForm { get; set; }
        private BindingSource _bs;
        private List<Specialist> _allProfessionals;
        private List<Specialist> _filteredList;
        private List<Specialist> _groupList;
        private bool _sorted;

        public ProfessionalServicesSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
        }

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new GenericFormIntialiser(this);
            
            LoadFullList();
            SetDataSource();

            if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            {
                MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadFullList();
        }

        public void LoadFullList()
        {
            ep.SetError(dgProfessionalServices, "");
            try
            {
                DataBase db = new SpecialistData();

                _allProfessionals = db.GetList().ConvertAll(x=>x as Specialist);
                _filteredList = _allProfessionals;
                _groupList = _allProfessionals;

            }
            catch (Exception ex)
            {
                ep.SetError(dgProfessionalServices, ex.Message);
            }
        }

        public void SetDataSource()
        {
            dgProfessionalServices.AutoGenerateColumns = false;
            _bs.DataSource = _filteredList;
            dgProfessionalServices.DataSource = _bs.DataSource;
            dgProfessionalServices.Refresh();
            lblStudentCount.Text = "Professional Count: " + dgProfessionalServices.Rows.Count.ToString();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void rdStaff_CheckedChanged(object sender, EventArgs e)
        //{
        //    LoadFullList();
        //    //SetSearchType();
        //    //LoadFullList();
        //    //SetDateColumnsVisible();
        //}

        //private void txtDocketNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //InterfaceTasks.ValidateOnlyDigits(txtSearch, e);
        //}

        //private void btnGenerateReport_Click(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
        //    {
        //        //SetSearchType();
        //        //ReportProcessor rp = new JobReport();
        //        //rp.CurrentUser = currentUser;               
        //        ReportViewer frm = new ReportViewer(_allProfessionals);
        //        frm.MdiParent = _mdiForm;
        //        frm.Dock = DockStyle.Fill;
        //        frm.FormBorderStyle = FormBorderStyle.Sizable;
        //        frm.Show();
        //    }
        //}

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadFullList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            _filteredList = _groupList;
            SetDataSource();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                _filteredList = _groupList.FindAll(x => x.FullName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                SetDataSource();
            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            int personId = (int)dgProfessionalServices.Rows[e.RowIndex].Cells[0].Value;
            Specialist person = _allProfessionals.Find(x => x.PersonId == personId);
            if (person != null)
            {
                //if (Application.OpenForms["EditDoctor"] as StudentEdit != null)
                //{
                //    EditDoctor frm1 = (EditDoctor)Application.OpenForms["EditDoctor"];
                //    frm1.Close();
                //}
                ProfessionalAddEdit frm = new ProfessionalAddEdit(person,"Edit");
                //frm.MdiParent = _mdiForm;
                //frm.Dock = DockStyle.Fill;
                //frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                    LoadFullList();
                    SetDataSource();
                //}
            }
        }

            private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                int index = e.ColumnIndex;
                string propertyName = dgProfessionalServices.Columns[index].DataPropertyName;
                if (!_sorted)
                {
                    _filteredList = _filteredList.OrderBy(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = true;
                }
                else
                {
                    _filteredList = _filteredList.OrderByDescending(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = false;
                }


                SetDataSource();
            }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            _mdiForm.Jarvis.ExportFileData = _filteredList.ConvertAll(x => x as object);
            FileExportBase efb = new SpecialistFile(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void addNewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfessionalAddEdit sa = new ProfessionalAddEdit(new Specialist(), "add");
            sa.ShowDialog();
            if (sa.DialogResult == DialogResult.OK)
            {
                //if (Application.OpenForms["DoctorSearch"] as DoctorSearch != null)
                //{
                //DoctorSearch frm1 = (DoctorSearch)Application.OpenForms["DoctorSearch"];
                LoadFullList();
                SetDataSource();
                // }
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                ApplyFilter(0);
            }
        }

        private void rbDentists_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDentists.Checked)
            {
                ApplyFilter(2);
            }
        }

        private void rbPodatrists_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPodatrists.Checked)
            {
                ApplyFilter(5);
            }
        }

        private void rbAudiologist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAudiologist.Checked)
            {
                ApplyFilter(4);
            }
        }

        private void rbOtherSpecialist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtherSpecialist.Checked)
            {
                ApplyFilter(6);
            }
        }

        private void rbOpticians_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOpticians.Checked)
            {
                ApplyFilter(3);
            }
        }

        private void rbSurgeon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSurgeon.Checked)
            {
                ApplyFilter(7);
            }
        }

        private void ApplyFilter(int personType)
        {
            txtSearch.Text = string.Empty;
            if (personType == 0)
                _groupList = _allProfessionals;
            else
                _groupList = _allProfessionals.FindAll(x => x.ProfessionalServiceProviderTypeId == personType);

            _filteredList = _groupList;
            SetDataSource();
        }

       
    }
    }

