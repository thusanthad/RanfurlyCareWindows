using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public class IndividualStudentReport:ReportViewerBase
    {
        public IndividualStudentReport(Microsoft.Reporting.WinForms.ReportViewer reportViewer, object objectType):base(reportViewer,objectType)
        {
            
        }

        public override void ShowReport()
        {
            Student _student = (Student)_object;
            _student.FullName = _student.GetFullName();
            _student.FullAddress = _student.GetFullAddress();
            ReportDataSource rdsDoctors = new ReportDataSource();
            rdsDoctors.Name = "Doctors";
            rdsDoctors.Value = _student.Doctors;

            ReportDataSource rdsNextOfKin = new ReportDataSource();
            rdsNextOfKin.Name = "NextOfKin";
            rdsNextOfKin.Value = _student.NextOfKin;

            ReportDataSource rdsEmergencyContacts = new ReportDataSource();
            rdsEmergencyContacts.Name = "EmergencyContacts";
            rdsEmergencyContacts.Value = _student.EmergencyContacts;

            ReportDataSource rdsMedicalConditions = new ReportDataSource();
            rdsMedicalConditions.Name = "MedicalConditions";
            rdsMedicalConditions.Value = _student.MedicalConditions;

            ReportDataSource rdsStudentNotes = new ReportDataSource();
            rdsStudentNotes.Name = "StudentNotes";
            rdsStudentNotes.Value = _student.StudentNotes;

            ReportDataSource rdsRiskManagementPlans = new ReportDataSource();
            rdsRiskManagementPlans.Name = "RiskManagementPlans";
            rdsRiskManagementPlans.Value = _student.RiskManagementPlans;

            ReportDataSource rdsPersonalCare = new ReportDataSource();
            rdsPersonalCare.Name = "PersonalCare";
            rdsPersonalCare.Value = _student.PersonalCare;

            ReportDataSource rdsMedicationAndTreatments = new ReportDataSource();
            rdsMedicationAndTreatments.Name = "MedicationAndTreatments";
            rdsMedicationAndTreatments.Value = _student.MedicationAndTreatments;

            ReportDataSource rdsPhysicalDisabilities = new ReportDataSource();
            rdsPhysicalDisabilities.Name = "PhysicalAbilities";
            rdsPhysicalDisabilities.Value = _student.PhysicalAbilities;

            ReportDataSource rdsCommunityOrientations = new ReportDataSource();
            rdsCommunityOrientations.Name = "CommunityOrientations";
            rdsCommunityOrientations.Value = _student.CommunityOrientations;

            ReportDataSource rdsCommunityInterractions = new ReportDataSource();
            rdsCommunityInterractions.Name = "CommunityInterractions";
            rdsCommunityInterractions.Value = _student.CommunityInteractions;

            ReportDataSource rdsAsthma = new ReportDataSource();
            rdsAsthma.Name = "Asthma";
            rdsAsthma.Value = _student.AsthmaList;

            ReportDataSource rdsAllergies = new ReportDataSource();
            rdsAllergies.Name = "Allergies";
            rdsAllergies.Value = _student.Allergies;

            ReportDataSource rdsEpilepsy = new ReportDataSource();
            rdsEpilepsy.Name = "Epilepsy";
            rdsEpilepsy.Value = _student.EpilepsyList;

            ReportDataSource rdsBehaviour = new ReportDataSource();
            rdsBehaviour.Name = "StudentBehaviour";
            rdsBehaviour.Value = _student.Behaviours;

            ReportDataSource rdsProfessionalServiceProviders = new ReportDataSource();
            rdsProfessionalServiceProviders.Name = "ProfessionalServiceProviders";
            rdsProfessionalServiceProviders.Value = _student.ProfessionalServiceProviders;

            ReportDataSource rdsIncidents = new ReportDataSource();
            rdsIncidents.Name = "Incidents";
            rdsIncidents.Value = _student.GetIncidents(); 

            ReportParameter[] p = new ReportParameter[25];
            p[0] = new ReportParameter("FullName", _student.FullName, true);
            p[1] = new ReportParameter("Gender", _student.Gender, true);
            p[2] = new ReportParameter("DateOfBirth", _student.DateOfBirth?.ToString("dd MMMM yyyy"), true);
            p[3] = new ReportParameter("Ethnicity", _student.Ethnicity, true);
            p[4] = new ReportParameter("AdmittedToCareCentre", _student.AdmittedToActivityCentre?.ToString("dd MMMM yyyy"), true);
            p[5] = new ReportParameter("PlaceOfBirth", _student.PlaceOfBirth, true);
            p[6] = new ReportParameter("AdmittedToResidence", _student.AdmittedToResidence?.ToString("dd MMMM yyyy"), true);
            p[7] = new ReportParameter("NHINumber", _student.NHINumber, true);
            p[8] = new ReportParameter("HomePhone", _student.HomePhone, true);
            p[9] = new ReportParameter("MobilePhone", _student.MobilePhone, true);
            p[10] = new ReportParameter("FullAddress", _student.FullAddress, true);
            p[11] = new ReportParameter("ActivityCentreCoach", _student.ActivityCentreCoach, true);
            p[12] = new ReportParameter("ResidenceCoach", _student.ResidentCoach, true);
            p[13] = new ReportParameter("Location", _student.LocationName, true);
            p[14] = new ReportParameter("StudentId", _student.PersonId.ToString(), true);
            p[15] = new ReportParameter("IsActive", _student.IsActive.ToString(), true);
            p[16] = new ReportParameter("AttendsActivityCentre", _student.AttendsActivityCentre.ToString(), true);
            p[17] = new ReportParameter("IsResident", _student.IsResident.ToString(), true);
            p[18] = new ReportParameter("WINZNumber", _student.WINZNumber.ToString(), true);
            p[19] = new ReportParameter("MobilityCardNumber", _student.MobilityCardNumber.ToString(), true);
            p[20] = new ReportParameter("GoldCardNumber", _student.GoldCardNumber.ToString(), true);
            p[21] = new ReportParameter("IRDNumber", _student.IRDNumber.ToString(), true);
            p[22] = new ReportParameter("CommunityServicesCardNumber", _student.CommunityServicesCardNumber.ToString(), true);
            p[23] = new ReportParameter("ShortNotes", _student.ShortNotes.ToString(), true);
            p[24] = new ReportParameter("FuneralArrangement", _student.FuneralArrangement.ToString(), true);

            _reportViewer.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Reports.RDLCReports.IndividualStudentReport.rdlc";
            //is.reportViewer1.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Application.Reports.RDLCReports.IndividualStudentReport.rdlc";
            _reportViewer.LocalReport.SetParameters(p);
            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(rdsDoctors);
            _reportViewer.LocalReport.DataSources.Add(rdsNextOfKin);
            _reportViewer.LocalReport.DataSources.Add(rdsEmergencyContacts);
            _reportViewer.LocalReport.DataSources.Add(rdsMedicalConditions);
            _reportViewer.LocalReport.DataSources.Add(rdsStudentNotes);
            _reportViewer.LocalReport.DataSources.Add(rdsRiskManagementPlans);
            _reportViewer.LocalReport.DataSources.Add(rdsPersonalCare);
            _reportViewer.LocalReport.DataSources.Add(rdsMedicationAndTreatments);
            _reportViewer.LocalReport.DataSources.Add(rdsPhysicalDisabilities);
            _reportViewer.LocalReport.DataSources.Add(rdsCommunityOrientations);
            _reportViewer.LocalReport.DataSources.Add(rdsCommunityInterractions);
            _reportViewer.LocalReport.DataSources.Add(rdsAsthma);
            _reportViewer.LocalReport.DataSources.Add(rdsAllergies);
            _reportViewer.LocalReport.DataSources.Add(rdsEpilepsy);
            _reportViewer.LocalReport.DataSources.Add(rdsBehaviour);
            _reportViewer.LocalReport.DataSources.Add(rdsProfessionalServiceProviders);
            _reportViewer.LocalReport.DataSources.Add(rdsIncidents);

            _reportViewer.LocalReport.DisplayName = "Student Report for " + _student.PersonId + "_'" + _student.FullName + "'";
            _reportViewer.RefreshReport();
        }
    }

    
}
