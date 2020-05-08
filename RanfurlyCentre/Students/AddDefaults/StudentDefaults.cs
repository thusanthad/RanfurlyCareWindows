using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students.AddDefaults
{
    public partial class StudentDefaults : Form
    {
        protected List<StudentAbilityBase> _defaults;
        protected int _defaultType;
        public List<StudentAbilityBase> SelectedList { get; set; }
        public StudentDefaults(List<StudentAbilityBase> defaults, int defaultType)
        {
            InitializeComponent();
            _defaults = defaults;
            _defaultType = defaultType;
            lblDeafaultType.Text = GetDefdaultType(defaultType);
        }

        private void StudentDefaults_Load(object sender, EventArgs e)
        {
            dgData.AutoGenerateColumns = false;
            List<StudentAbilityBase> defaultList = _defaults.FindAll(x => x.StudentAbilityTypeId == _defaultType).ToList();
            dgData.DataSource = defaultList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add the defaults?", "Add Defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {

            }
            
            SelectedList = _defaults.FindAll(x => x.Selected == true && x.StudentAbilityTypeId== _defaultType).ToList();
            this.DialogResult = DialogResult.OK;
        }

        private string GetDefdaultType(int id)
        {
            string defaultType;
            switch(id)
            {
                case 1:
                    defaultType = "Physical Ability";
                    break;
                case 2:
                    defaultType = "Community Orientation";
                    break;
                case 3:
                    defaultType = "Community Interraction";
                    break;
                default:
                    defaultType = "Persona Care";
                    break;
            }

            return defaultType;
        }

        
    }
}