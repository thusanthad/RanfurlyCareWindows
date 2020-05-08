using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class NextOfKinAssign : Form
    {
        protected Student _student;
        protected NextOfKin _selectedNextOfKin;

        public NextOfKinAssign(Student student)
        {
            InitializeComponent();
            _student = student;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            PopulateNextOfKin();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (cmbNextOfKinName.SelectedIndex == -1)
            {
                ep.SetError(cmbNextOfKinName, "select next of Kin from list");
                return;
            }
            else if (txtRelationship.Text == string.Empty)
            {
                ep.SetError(txtRelationship, "Type relationship");
                return;
            }
            else
            {
                _selectedNextOfKin = (NextOfKin)cmbNextOfKinName.SelectedItem;
                _selectedNextOfKin.FullAddress = _selectedNextOfKin.GetFullAddress();
                _selectedNextOfKin.Relationship = txtRelationship.Text;
                _student.NextOfKin.Add(_selectedNextOfKin);
                this.DialogResult = DialogResult.OK;
            }
        }

        private List<NextOfKin> GetOtherNextOfKin(List<NextOfKin> nextOfKin, List<NextOfKin> studentNextOfKin)
        {
                foreach (NextOfKin nofk in studentNextOfKin)
                {
                NextOfKin doctor = nextOfKin.Find(x => x.PersonId == nofk.PersonId);
                if (doctor != null)
                    nextOfKin.Remove(doctor);
                }
            return nextOfKin;
        }
    }
}
