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
    public partial class LocationAdd : Form
    {
        public LocationAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(IsValidated())
            {
                try
                {
                    LocationData ed = new LocationData();
                    Location location = new Location
                    {
                        LocationName = txtLocation.Text,
                        Abbreviation = txtAbbreviation.Text,
                        FullAddress = txtFullAddress.Text,
                        Telephone = txtTelephone.Text,
                        IsResidence = chkIsResidence.Checked,
                        IsStudentCentre = chkIsStudentCentre.Checked,
                        IsRollCall = chkIsRollCall.Checked,
                        RollReference = txtRollReference.Text
                    };
                    int ethnicityId = ed.Add(location);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidated()
        {
            ep.Clear();
            int errors = 0;
            if (txtLocation.Text == string.Empty)
            {
                
                ep.SetError(txtLocation, "Type Location name");
            }

            if (txtAbbreviation.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtAbbreviation, "Type Abbreviation");
            }

            if (txtFullAddress.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtFullAddress, "Type Full address");
            }
                
            if (txtTelephone.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtTelephone, "Type telephone number(s)");
            }
            if (chkIsResidence.Checked && txtRollReference.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtRollReference, "Type Roll Reference for the location");
            }
            return errors == 0;
        }

        private void chkIsRollCall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsRollCall.Checked)
                txtRollReference.Enabled = true;
            else
            {
                txtRollReference.Text = string.Empty;
                txtRollReference.Enabled = false;
            }
        }
    }
}
