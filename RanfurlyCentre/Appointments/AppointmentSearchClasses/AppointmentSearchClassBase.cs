using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class AppointmentSearchClassBase
    {        
        protected AppointmentSearch _frm;        
        protected AppointmentData _ad;
        protected List<AppointmentBase> _allAppointments;
        protected string _sql;
        public AppointmentSearchClassBase(AppointmentSearch frm)
        {
            _frm=  frm;
            _frm.lblFrom.Visible = false;
            _frm.lblTo.Visible = false;
            _frm.dtpFrom.Visible = false;
            _frm.dtpTo.Visible = false;
            _ad = new AppointmentData();
           // DisableIndexChangedEvents();
            //SetDataSource();
        }

        public virtual void SetDataSource()
        {
            _allAppointments = _ad.GetList(_sql).OrderBy(x => x.AppointmentDate).ThenBy(x => x.AppointmentHour).ToList();//.ConvertAll(x => x as AppointmentBase);
            _allAppointments.ForEach(x => x.UpdateDisplayNames());
            SetDataGridViewData();
            //_frm.dgAppointment.AutoGenerateColumns = false;
            //_frm.dgAppointment.DataSource = _allAppointments;// bs;// _studentBs.DataSource;
            //_frm.dgAppointment.Refresh();
            //_frm.dgAppointment.Columns[1].DefaultCellStyle.Format = "dd-MMMM-yyyy";
            //_frm.lblAppointmentCount.Text = "Appointment Count: " + _frm.dgAppointment.Rows.Count.ToString();
        }

        public virtual void SetSortDataSource(string propertyName, bool IsAscending)
        {
            if (!IsAscending)
            {
                _allAppointments = _allAppointments.OrderBy(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
            }
            else
            {
                _allAppointments = _allAppointments.OrderByDescending(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
            }
            SetDataGridViewData();
        }

        private void SetDataGridViewData()
        {
            _frm.dgAppointment.AutoGenerateColumns = false;
            _frm.dgAppointment.DataSource = null;
            _frm.dgAppointment.DataSource = _allAppointments;// bs;// _studentBs.DataSource;
            _frm.dgAppointment.Refresh();
            _frm.dgAppointment.Columns[1].DefaultCellStyle.Format = "dd-MMMM-yyyy";
            _frm.lblAppointmentCount.Text = "Appointment Count: " + _frm.dgAppointment.Rows.Count.ToString();
        }

        public AppointmentBase GetAppointment(int apId)
        {
            return _allAppointments.Find(x => x.AppointmentId == apId);
        }

        protected void DisableIndexChangedEvents()
        {
            _frm.dtpFrom.ValueChanged -= _frm.dtpFrom_ValueChanged;
            _frm.dtpTo.ValueChanged -= _frm.dtpTo_ValueChanged;
        }

        protected void EnableIndexChangedEvents()
        {
            _frm.dtpFrom.ValueChanged += _frm.dtpFrom_ValueChanged;
            _frm.dtpTo.ValueChanged += _frm.dtpTo_ValueChanged;
        }


    }
}
