using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RanfurlyBusiness
{
    public class Person//:INotifyPropertyChanged
    {
        public int PersonId { get; set; }
        public string PreferredName { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }   
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? AdmissionToResidence { get; set; }
        public DateTime? AdmissionToCareCentre { get; set; }
        public string NHINumber { get; set; }
        public string WINZNumber { get; set; }
        public string IRDNumber { get; set; } 
        public bool IsResident { get; set; }
        public string Ethnicity { get; set; }
        //public DateTime? DateOfAdmission { get; set; }
        public bool IsActive { get; set; }
        public string HomePhone { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HearingNotes { get; set; }
        public string MedicalAppointmentNotes { get; set; }
        public string Relationship { get; set; }
        //public List<Address> Address { get; set; }
        public List<Person> Doctors { get; set; }
        public List<Person> NextOfKin { get; set; }
        public List<MedicalCondition> MedicalConditions { get; set; }
        public List<Address> Addresses { get; set; }
        public List<EmergencyContact> EmergencyContacts { get; set; }


        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        //{
        //    //if (PropertyChanged != null)
        //    //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        //    //if (makeDirty)
        //    //    _IsDirty = true;
        //}

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    OnPropertyChanged(propertyName, true);
        //}

        

    }
}
