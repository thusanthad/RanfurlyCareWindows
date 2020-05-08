using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentRiskManagementAddEdit : StudentDataAddEditBase
    {
        public StudentRiskManagementAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            RiskManagementPlanData riskManagementPlanData = new RiskManagementPlanData(dbc);
            foreach (RiskManagementPlan rmp in student.RiskManagementPlans)
            {
                if (rmp.StudentRiskManagementId == 0)
                {
                    riskManagementPlanData.Add(rmp, student.PersonId);
                }
                else
                {
                    riskManagementPlanData.Update(rmp);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is RiskManagementPlan)
                {
                    riskManagementPlanData.Remove(((RiskManagementPlan)obj).StudentRiskManagementId);
                }
            }
        }
    }
}
