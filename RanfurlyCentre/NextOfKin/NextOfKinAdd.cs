using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class NextOfKinAdd : Form
    {
        protected Student _student;
        protected NextOfKin _selectedNextOfKin;
        protected AddNextOfKinToStudentBase _anofToStudent;
        protected AddNextOfKinFormBase _anofkinBase;

        //public AddNextOfKin(Student student )
        //{
        //    InitializeComponent();
        //    _student = student;
        //}

        public NextOfKinAdd(AddNextOfKinToStudentBase addNextOfKinToStudentBase)
        {
            InitializeComponent();
            _anofToStudent = addNextOfKinToStudentBase;
            _student = _anofToStudent.Student;
            _anofkinBase = new AssignNextOfKinForm(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            cmbNextOfKinName.SelectedIndexChanged -= cmbFullName_SelectedIndexChanged;
            PopulateNextOfKin();
            cmbNextOfKinName.SelectedIndexChanged += cmbFullName_SelectedIndexChanged;
        }

        private void PopulateNextOfKin()
        {           
            cmbNextOfKinName.DisplayMember = "FullName";
            cmbNextOfKinName.ValueMember = "PersonId";
            DataBase db = new NextOfKinData();
            List<NextOfKin> list = db.GetList().ConvertAll(x=>x as NextOfKin);
            List<NextOfKin> nextOfKin = list.Except(_student.Doctors.ConvertAll(x=>x as NextOfKin)).ToList();
            cmbNextOfKinName.DataSource = GetOtherNextOfKin(list, _student.NextOfKin.ConvertAll(x => x as NextOfKin));// db.GetList();            
            cmbNextOfKinName.SelectedIndex = -1;
            cmbNextOfKinName.Refresh();
        }

        //private void CmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
            //if (cmbNextOfKinName.Text == string.Empty && rbAllocateFromList.Checked)
            //    ep.SetError(cmbNextOfKinName, "Select next of kin or type new next of kin name");
            //if (txtNextOfKinName.Text == string.Empty && rbAddNewNextOfKin.Checked)
            //    ep.SetError(cmbNextOfKinName, "Type new next of kin name");
            //if (txtAddr1.Text == string.Empty)
            //    ep.SetError(txtAddr1, "Type Addr1");
            //if (txtAddr2.Text == string.Empty)
            //    ep.SetError(txtAddr2, "Type Addr2");
            //if (txtAddr3.Text == string.Empty)
            //    ep.SetError(txtAddr3, "Type Addr3");
            //if (txtPostcode.Text == string.Empty)
            //    ep.SetError(txtPostcode, "Type Postcode");
            //if (txtPhone.Text == string.Empty)
            //    ep.SetError(txtPhone, "Type Phone");
            //if (txtRelationship.Text == string.Empty)
            //    ep.SetError(txtRelationship, "Type Relationship");

            //bool failed = false;
            //foreach (Control c in this.Controls)
            //{
            //    if (ep.GetError(c).Length > 0)
            //        failed = true;
            //}

            if (_anofkinBase.Validated())
            {
            //    return;
            //}
            //else
            //{
                try
                {
                   // DataBase db = new NextOfKinData();
                    if (_selectedNextOfKin == null) // add next of kin and assign to student
                    {
                        Person nextofKin = new NextOfKin
                        {
                            FullName = txtNextOfKinName.Text,
                            Addr1 = txtAddr1.Text,
                            Addr2 = txtAddr2.Text,
                            Addr3 = txtAddr3.Text,
                            Addr4 = txtAddr4.Text,
                            Postcode = txtPostcode.Text,
                            Phone = txtPhone.Text,
                            Email = txtEmail.Text,
                            Relationship = txtRelationship.Text
                        };

                        _anofToStudent.AddNextOfKin((NextOfKin)nextofKin);
                        //int nextofKinId = db.Add(nextofKin,_student.PersonId);
                        //nextofKin.PersonId = nextofKinId;
                    }
                    else // add next of kin
                    {
                        _selectedNextOfKin.Relationship = txtRelationship.Text;
                        _anofToStudent.AllocateNextOfKin(_selectedNextOfKin);
                        //_selectedNextOfKin.Relationship = txtRelationship.Text;
                        //db.Allocate(_selectedNextOfKin, _student.PersonId);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            
        }

        private void cmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (cmbNextOfKinName.SelectedIndex >= 0)
                {
                    _selectedNextOfKin = (NextOfKin)cmbNextOfKinName.SelectedItem;
                    txtAddr1.Text = _selectedNextOfKin.Addr1;
                    txtAddr2.Text = _selectedNextOfKin.Addr2;
                    txtAddr3.Text = _selectedNextOfKin.Addr3;
                    txtAddr4.Text = _selectedNextOfKin.Addr4;
                    txtPostcode.Text = _selectedNextOfKin.Postcode;
                    txtPhone.Text = _selectedNextOfKin.Phone;
                    txtEmail.Text = _selectedNextOfKin.Email;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbAllocateFromList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllocateFromList.Checked)
            {
                SelectOption();
                cmbNextOfKinName.Focus();
            }
        }

        private void rbAddNewDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddNewNextOfKin.Checked)
            {
                SelectOption();
                txtNextOfKinName.Focus();
            } 
        }

        private void SelectOption()
        {
            ep.Clear();
            if (rbAllocateFromList.Checked)
            {
                cmbNextOfKinName.Visible = true;
                txtNextOfKinName.Visible = false;                
            }
            else
            {
                cmbNextOfKinName.Visible = false;
                txtNextOfKinName.Visible = true;
            }

            cmbNextOfKinName.SelectedIndex = -1;
            txtNextOfKinName.Text = string.Empty;
            txtAddr1.Text = string.Empty;
            txtAddr2.Text = string.Empty;
            txtAddr3.Text = string.Empty;
            txtAddr4.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private List<NextOfKin> GetOtherNextOfKin(List<NextOfKin> nextOfKin, List<NextOfKin> studentNextOfKin)
        {
            //List<Doctor> otherDoctors = new List<Doctor>();
            //foreach (Doctor dr in doctors)
            //{
                foreach (NextOfKin nofk in studentNextOfKin)
                {
                NextOfKin doctor = nextOfKin.Find(x => x.PersonId == nofk.PersonId);
                if (doctor != null)
                    nextOfKin.Remove(doctor);
                }
            //}
            return nextOfKin;
        }

        //private void cmbFullName_SelectionChangeCommitted(object sender, EventArgs e)
        //{


        //}
    }
}
