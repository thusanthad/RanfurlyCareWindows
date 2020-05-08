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
    public partial class AddWorkCentre : Form
    {
        DataTable customer = new DataTable();
        public AddWorkCentre()
        {
            InitializeComponent();            
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            if (customer.Rows.Count > 0)
            {
                //CustomerData.AddNewCustomer(customer);
                MessageBox.Show("Customers Added successfully.", "Add Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please type new customer list on the grid", "Add Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }


            
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            customer.Columns.Add("CustomerName");
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = customer;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
