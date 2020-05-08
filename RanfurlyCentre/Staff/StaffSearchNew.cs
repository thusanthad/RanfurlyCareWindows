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
    public partial class StaffSearchNew : Form
    {
        public MDIMainForm _mdiForm { get; set; }
        private BindingSource _bs;
        private List<Person> _allStaff;
        private List<Person> _filteredStaffList;
        private bool _sorted;

        public StaffSearchNew(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
        }
    }
}
