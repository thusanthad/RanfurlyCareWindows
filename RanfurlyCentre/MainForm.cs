using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using ClassStructure;
using System.Diagnostics;

namespace TimeTracker
{
    public partial class MainForm : Form
    {
        //List<Address> addList = new List<Address>();
        public MainForm()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = GenerateClass();
        }

        //private List<Address> GenerateClass()   
        //{
            
        //    //Address add1 = new Address();
        //    //add1.Address1 = "Address1";
        //    //add1.Address2 = "Address2";
        //    //add1.Address3 = "Address3";
        //    //add1.Address4 = "Address4";
        //    //add1.Postcode = "1111";
        //    //addList.Add(add1);

        //    //Address add2 = new Address();
        //    //add2.Address1 = "Address12";
        //    //add2.Address2 = "Address22";
        //    //add2.Address3 = "Address32";
        //    //add2.Address4 = "Address42";
        //    //add2.Postcode = "2222";
        //    //addList.Add(add2);
        //    //return addList;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            ////foreach (Address add in addList)
            ////{
            //    Address add2 = new Address();
            //    add2.Address1 = "Address13";
            //    add2.Address2 = "Address23";
            //    add2.Address3 = "Address33";
            //    add2.Address4 = "Address43";
            //    add2.Postcode = "3333";
            //    addList.Add(add2);
            //    //Console.WriteLine(add.Address1);
            //    dataGridView1.DataSource=null;
            //    dataGridView1.DataSource = addList;
            //    //dataGridView1.DataSource = new BindingSource(
            ////}
        }
    }
}
