using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class NextOfKinAdd : Form
    {
        public NextOfKin NextOfKin { get; set; }
        protected AddNextOfKinBase _aedb;  

        public NextOfKinAdd(NextOfKin nextOfKin)
        {
            InitializeComponent();
            NextOfKin = nextOfKin;
                _aedb = new AddNewNextOfKin(this);      
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {           
            PopulateDoctor();           
        }

        private void PopulateDoctor()
        {
            //txtDoctorName.Text = _doctor.FullName;
            //txtAddr1.Text = _doctor.Addr1;
            //txtAddr2.Text = _doctor.Addr2;
            //txtAddr3.Text = _doctor.Addr3;
            //txtAddr4.Text = _doctor.Addr4;
            //txtPostcode.Text = _doctor.Postcode;
            //txtPhone.Text = _doctor.Phone;
            //txtEmail.Text = _doctor.Email;
            //DataBase db = new DoctorData();
            //_doctorList = db.GetList().ConvertAll(x => x as Doctor);
        }

        private void CmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_aedb.ValidateInput())
            {
                try
                {
                    _aedb.Commit();
                    //DataBase db = new DoctorData();

                    //_doctor.FullName = txtDoctorName.Text;
                    //_doctor.Addr1 = txtAddr1.Text;
                    //_doctor.Addr2 = txtAddr2.Text;
                    //_doctor.Addr3 = txtAddr3.Text;
                    //_doctor.Addr4 = txtAddr4.Text;
                    //_doctor.Postcode = txtPostcode.Text;
                    //_doctor.Phone = txtPhone.Text;
                    //_doctor.Email = txtEmail.Text;

                    //db.Update(_doctor);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private bool ValidateInput()
        //{
        //    ep.Clear();
        //    if (txtDoctorName.Text == string.Empty)
        //        ep.SetError(txtDoctorName, "Type new doctor name");
        //    if (txtAddr1.Text == string.Empty)
        //        ep.SetError(txtAddr1, "Type Addr1");
        //    if (txtAddr2.Text == string.Empty)
        //        ep.SetError(txtAddr2, "Type Addr2");
        //    if (txtAddr3.Text == string.Empty)
        //        ep.SetError(txtAddr3, "Type Addr3");
        //    if (txtPostcode.Text == string.Empty)
        //        ep.SetError(txtPostcode, "Type Postcode");
        //    if (txtPhone.Text == string.Empty)
        //        ep.SetError(txtPhone, "Type Phone");

        //    bool failed = true;
        //    foreach (Control c in this.Controls)
        //    {
        //        if (ep.GetError(c).Length > 0)
        //        {
        //            failed = false;
        //            break ;
        //        }
        //    }
        //    return failed;
        //}
    }
}
