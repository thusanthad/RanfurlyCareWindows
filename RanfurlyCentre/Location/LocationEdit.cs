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
    public partial class LocationEdit : Form
    {
        protected List<Location> _list;
        public LocationEdit()
        {
            InitializeComponent();
            PopulateLocations();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UpdateLocations();
            this.Close();
        }

        private void PopulateLocations()
        {
            try
            {
                LocationData db =  new LocationData();
            _list = db.GetList();
            dgLocation.AutoGenerateColumns = false;
            dgLocation.DataSource = _list;
            dgLocation.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addEthnicityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LocationAdd ed = new LocationAdd();
                ed.ShowDialog();
                if (ed.DialogResult == DialogResult.OK)
                    PopulateLocations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        //private void LocationEdit_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //UpdateLocations();
        //    //if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
        //    //{
        //    //    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
        //    //    frm1.PopulateLocationCombobox();
        //    //}
        //}

        private void UpdateLocations()
        {
            try
            {
                LocationData ld = new LocationData();
                foreach (Location location in _list)
                {
                    ld.Update(location);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
