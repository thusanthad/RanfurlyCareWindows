using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RanfurlyBusiness
{
    public class Student :Person//:INotifyPropertyChanged
    {
        public string PlaceOfBirth { get; set; }
        public DateTime? AdmittedToResidence { get; set; }
        public DateTime? AdmittedToActivityCentre { get; set; }
        public DateTime? DateLeft { get; set; }
        public string NHINumber { get; set; }        
        public bool IsResident { get; set; }
        public bool AttendsActivityCentre { get; set; }
        public string Ethnicity { get; set; }
        public int EthnicityId { get; set; }
        public int LocationId { get; set; }
        // public DateTime? DateOfAdmission { get; set; }
        public bool IsActive { get; set; }
        public bool IsShortStayResident { get; set; }
        public string HearingNotes { get; set; }
        public string ShortNotes { get; set; }
        public string LocationName { get; set; }
        public List<Specialist> ProfessionalServiceProviders { get; set; }
        public List<Person> Doctors { get; set; }        
        public List<NextOfKin> NextOfKin { get; set; }
        public List<MedicalCondition> MedicalConditions { get; set; }
        public List<StudentNote> StudentNotes { get; set; }
        public List<RiskManagementPlan> RiskManagementPlans { get; set; }
        public List<StudentPersonalCare> PersonalCare { get; set; }
        public List<MedicationAndTreatment> MedicationAndTreatments { get; set; }
        public List<StudentAbilityBase> StudentAbilities { get; set; }
        public List<StudentBehaviour> Behaviours { get; set; }
        public List<Incident> Incidents { get; set; }

        public List<EmergencyContact> EmergencyContacts { get; set; }
        public List<StudentMedicalConditionAlertBase> MedicalConditionAlerts { get; set; }
        
        public List<Asthma> AsthmaList { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Epilepsy> EpilepsyList { get; set; }        
        public List<PhysicalAbility> PhysicalAbilities { get; set; }
        public List<CommunityOrientation> CommunityOrientations { get; set; }
        public List<CommunityInteraction> CommunityInteractions { get; set; }

        //public List<RiskManagementPlan> ssssssssssssssssss { get; set; }
        public int ResidentCoachId { get; set; }
        public int ActivityCentreCoachId { get; set; }
        public string ResidentCoach { get; set; }
        public string ActivityCentreCoach { get; set; }
        public List<object> RemovedObjects { get; set; }
        public string FuneralArrangement { get; set; }
        public string WINZNumber { get; set; }
        public string IRDNumber { get; set; }
        public string MobilityCardNumber { get; set; }
        public string GoldCardNumber { get; set; }        
        public string CommunityServicesCardNumber { get; set; }

        //public List<Address> Addresses { get; set; }

        public Student()
        {
            Doctors = new List<Person>();
            NextOfKin = new List<NextOfKin>();
            MedicalConditions = new List<MedicalCondition>();
            RemovedObjects = new List<object>();
            EmergencyContacts = new List<EmergencyContact>();           
        }

        public List<Incident> GetIncidents()
        {
            IncidentData data = new IncidentData();
            return data.GetList(PersonId);
        }


    }
}
