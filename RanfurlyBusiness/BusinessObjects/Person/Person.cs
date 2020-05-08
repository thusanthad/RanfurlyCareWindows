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
        public int ProfessionalServiceProviderTypeId { get; set; }
        public string PreferredName { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        //public string Title { get; set; }   
        public DateTime? DateOfBirth { get; set; }
        public string HomePhone { get; set; }
        public string Phone { get; set; }
        public string FullAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        //public List<Address> Addresses { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string Postcode { get; set; }
        //public string SpecialistType { get; set; }

        public Person()
        {
            Addr1 = string.Empty;
            Addr2 = string.Empty;
            Addr3 = string.Empty;
            Addr4 = string.Empty;
            Postcode = string.Empty;
            Phone = string.Empty;
            MobilePhone = string.Empty;
            HomePhone = string.Empty;
            Email = string.Empty;
        }

        public virtual string GetFullAddress()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Addr1 != string.Empty)
                sb.Append(this.Addr1);
            if (this.Addr2 != string.Empty)
                sb.Append(", " + this.Addr2);
            if (this.Addr3 != string.Empty)
                sb.Append(", " + this.Addr3);
            if (this.Addr4 != string.Empty)
                sb.Append(", " + this.Addr4);
            if (this.Postcode != string.Empty)
                sb.Append(" " + this.Postcode);
            return sb.ToString();
        }

        public virtual string GetFullName()
        {
            StringBuilder sb = new StringBuilder();           
                sb.Append(this.FirstName);
            if (this.MiddleName != string.Empty)
                sb.Append(" " + this.MiddleName);
            if (this.LastName != string.Empty)
                sb.Append(" " + this.LastName);
            return sb.ToString();
        }
    }
    }

