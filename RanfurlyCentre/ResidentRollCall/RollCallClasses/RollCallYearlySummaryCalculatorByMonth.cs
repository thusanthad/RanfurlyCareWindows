using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Reflection;

namespace RanfurlyCentre
{
    public class RollCallYearlySummaryOverallCalculatorByMonth : RollCallSummaryCalculatorBase
    {
        public RollCallYearlySummaryOverallCalculatorByMonth(List<ResidentRollCall> rollCallList):base(rollCallList)
        {
        }

        public override void Calculate()
        {
            PropertyInfo[] properties = GetRollCallProperties();
            foreach (ResidentRollCall call in _rollCallList)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (CommonFunctions.IsNumeric(property.Name.Replace("d", "")))
                    {
                        ResidentYearlyCallSummaryByMonth found = (ResidentYearlyCallSummaryByMonth)FindSummaryItems(call);
                        ResidentYearlyCallSummaryByMonth summary;
                        if (found == null)
                        {
                            summary = new ResidentYearlyCallSummaryByMonth();
                            summary.LocationName = call.LocationName;
                            summary.RollReference = call.RollReference;
                            summary.YearNumber = call.YearNumber;
                            summary.MonthNumber = call.MonthNumber;
                        }
                        else
                        {
                            summary = found;
                        }


                        var rollValue = call.GetType().GetProperty(property.Name).GetValue(call, null);
                        if (rollValue != null)
                        {
                            if (rollValue.ToString() == "1")
                            {
                                if (call.Abbreviation == "CPA")
                                    summary.CPA += 1;
                                else if (call.Abbreviation == "M")
                                    summary.M += 1;
                                else if (call.Abbreviation == "RH")
                                    summary.RH += 1;
                            }
                            else
                            {
                                if (rollValue.ToString() == "DH")
                                    summary.DH += 1;
                                else if (rollValue.ToString() == "H")
                                    summary.H += 1;
                                else if (rollValue.ToString() == "AL")
                                    summary.AL += 1;
                                else if (rollValue.ToString() == "W")
                                    summary.W += 1;
                                else if (rollValue.ToString() == "ST")
                                    summary.ST += 1;
                            }

                            if (found == null)
                                ResidentCallSummaryListBase.Add(summary);
                        }
                    }
                }
            }
            ResidentCallSummaryListBase.ForEach(x => x.CalculateTotal());
        }

        public override ResidentCallSummaryBase FindSummaryItems(ResidentRollCall call)
        {
            ResidentYearlyCallSummaryByMonth summary = ResidentCallSummaryListBase.ConvertAll(x=>x as ResidentYearlyCallSummaryByMonth).Find((x => x.MonthNumber == call.MonthNumber && x.YearNumber == call.YearNumber && x.LocationName == call.LocationName));
            return summary;
        }
        
    }
}
