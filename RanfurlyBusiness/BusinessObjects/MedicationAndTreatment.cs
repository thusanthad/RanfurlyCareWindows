using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class MedicationAndTreatment
    {
        public int StudentMedicationAndTreatmentId { get; set; }
        public int StudentId { get; set; }
        public string Frequency { get; set; }
        public string Medication { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
    }
}
