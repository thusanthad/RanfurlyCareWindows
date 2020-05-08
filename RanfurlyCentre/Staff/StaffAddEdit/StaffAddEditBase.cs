using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public abstract class StaffAddEditBase
    {        
        public abstract void update();
        public Staff Staff { get; set; }
        protected StaffAddEdit _staffEdit;

        public StaffAddEditBase(StaffAddEdit staffAddEdit, Staff staff )
        {
            _staffEdit = staffAddEdit;
            Staff = staff;
            //_staffEdit.cha
            PopulateTitle();
            PopulateStaff();
            PopulateWorkCentres();
           // SetTextChangeDEventForControls();


            //_staffEdit.txtFirstName.Text = _staff.FirstName;
            //_staffEdit.txtLastName.Text = _staff.LastName;
            //_staffEdit.cmbTitle.SelectedValue = _staff.TitleId;
            //_staffEdit.txtAddr1.Text = _staff.Addr1;
            //_staffEdit.txtAddr2.Text = _staff.Addr2;
            //_staffEdit.txtAddr3.Text = _staff.Addr3;
            //_staffEdit.txtAddr4.Text = _staff.Addr4;
            //_staffEdit.txtPostcode.Text = _staff.Postcode;
            //_staffEdit.txtHomePhone.Text = _staff.HomePhone;
            //_staffEdit.txtMobilePhone.Text = _staff.MobilePhone;
            //_staffEdit.txtEmail.Text = _staff.Email;
        }

        private void PopulateTitle()
        {
            TitleData td = new TitleData();
            _staffEdit.cmbTitle.DataSource = td.GetList();

            _staffEdit.cmbTitle.DisplayMember = "TitleName";
            _staffEdit.cmbTitle.ValueMember = "TitleId";

        }

        private void PopulateStaff()
        {
            _staffEdit.txtFirstName.DataBindings.Add("Text", Staff, "FirstName");
            _staffEdit.txtLastName.DataBindings.Add("Text", Staff, "LastName");
            _staffEdit.cmbTitle.DataBindings.Add("SelectedValue", Staff, "TitleId");
            _staffEdit.txtAddr1.DataBindings.Add("Text", Staff, "Addr1");
            _staffEdit.txtAddr2.DataBindings.Add("Text", Staff, "Addr2");
            _staffEdit.txtAddr3.DataBindings.Add("Text", Staff, "Addr3");
            _staffEdit.txtAddr4.DataBindings.Add("Text", Staff, "Addr4");
            _staffEdit.txtPostcode.DataBindings.Add("Text", Staff, "Postcode");
            _staffEdit.txtHomePhone.DataBindings.Add("Text", Staff, "HomePhone");
            _staffEdit.txtMobilePhone.DataBindings.Add("Text", Staff, "MobilePhone");
            _staffEdit.txtEmail.DataBindings.Add("Text", Staff, "Email");
        }

        public void PopulateWorkCentres()
        {
            _staffEdit.dgWorkCentres.DataSource = null;
            _staffEdit.dgWorkCentres.AutoGenerateColumns = false;
            //Staff staff = (Staff)Staff;
            _staffEdit.dgWorkCentres.DataSource = Staff.Locations;
            _staffEdit.dgWorkCentres.Refresh();
        }

        public virtual bool Validated()
        {
            _staffEdit.ep.Clear();
            if (_staffEdit.txtFirstName.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtFirstName, "Type new first name");
            if (_staffEdit.txtLastName.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtLastName, "Type new last name");
            if (_staffEdit.cmbTitle.SelectedIndex == -1)
                _staffEdit.ep.SetError(_staffEdit.cmbTitle, "Select Title");
            if (_staffEdit.txtAddr1.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtAddr1, "Type Addr1");
            if (_staffEdit.txtAddr2.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtAddr2, "Type Addr2");
            if (_staffEdit.txtAddr3.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtAddr3, "Type Addr3");
            if (_staffEdit.txtPostcode.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtPostcode, "Type Postcode");
            if (_staffEdit.txtMobilePhone.Text == string.Empty)
                _staffEdit.ep.SetError(_staffEdit.txtMobilePhone, "Type Mobile Phone");

            bool failed = true;
            foreach (Control c in _staffEdit.tabControl1.TabPages[0].Controls)
            {
                if (_staffEdit.ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }
            }
            return failed;
        }

        public void SetTextChangeDEventForControls()
        {
            foreach (Control c in _staffEdit.tabControl1.TabPages[0].Controls)
            {
                if (c is TextBox)
                {
                    c.TextChanged += _staffEdit.ChangesOccuredEvent;
                }
                else if (c is ComboBox)
                {
                    c.TextChanged += _staffEdit.ChangesOccuredEvent;
                }
            }

        }

        //private void C_TextChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
