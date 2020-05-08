using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class FieldNameMapper
    {
        public string PropertyName {get;set;}
        public string PrintName { get; set; }
        public bool Selected { get; set; }
        public int? ColumnPosition { get; set; }

        public FieldNameMapper()
        {
            Selected = true;
        }
    }
}
