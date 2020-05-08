using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.ComponentModel;

namespace RanfurlyBusiness
{
    public static class CommonFunctions
    {

        public static void TransferPropertyValues(object FromObject, object ToObject)
        {
            Type aType = FromObject.GetType();
            Type bType = ToObject.GetType();

            foreach (PropertyInfo sourceProperty in aType.GetProperties())
            {
                PropertyInfo destinationProperty = bType.GetProperty(sourceProperty.Name);
                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(ToObject, sourceProperty.GetValue(FromObject, null), null);
                }
            }
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                //table.Columns.Add(prop.Name, prop.PropertyType);
                table.Columns.Add(prop.Name);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if(props[i].GetValue(item) !=null)
                        values[i] = props[i].GetValue(item).ToString().Replace("12:00:00 a.m.", "").Trim();
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static List<string> GetAllPropertiesFromType(object atype)
        {
            //if (atype == null) return new string[] { };
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            List<string> propNames = new List<string>();
            foreach (PropertyInfo prp in props)
            {
                propNames.Add(prp.Name);
            }
            return propNames;
        }

        public static List<string> TableCoulumnsToList(DataTable dt,int index)
        {
             List<string> s = dt.AsEnumerable().Select(x => x[index].ToString()).ToList();
            return s;
        }

        public static List<FieldNameMapper> TableToFieldMapping(DataTable dt, object atype)
        {
            List<string> propertyNames = GetAllPropertiesFromType(atype);
            List<FieldNameMapper> fileMapper = new List<FieldNameMapper>();
            List<string> list1 = TableCoulumnsToList(dt, 0);
            List<string> list2 = TableCoulumnsToList(dt, 1);
            int i = 1;
            foreach (string str in list1)
            {
                if (propertyNames.Contains(str))
                {
                    int index = list1.IndexOf(str);
                    string mappedPrintyName = list2[index];
                    FieldNameMapper fm = new FieldNameMapper();
                    fm.PropertyName = str;
                    fm.PrintName = mappedPrintyName;
                    fm.ColumnPosition = i;
                    fileMapper.Add(fm);
                    i += 1;
                }
            }

            return fileMapper;
        }

        public static void PlayFailSound()
        {
            //string SoundFile = DataAccess.Ap.ResourceFileLocation + DataAccess.Ap.WaveFileName;
            ///System.Media.SoundPlayer player = new System.Media.SoundPlayer(SoundFile);
            //player.Play();
        }

        public static string GetMonthName(int monthNumber)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
        }

        public static bool IsNumeric(string str)
        {
            Int64 i = 0;
            bool result = Int64.TryParse(str, out i);
            return result;
        }

        public static bool IsDate(int year, int month, int day)
        {
            bool rtn;
            try
            {
                DateTime dateTime = new DateTime(year, month, day);
                rtn = true;
            }
            catch
            {
                rtn = false;
            }
            return rtn;
            
        }

        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public static void UpdateApostrophe<T>(T obj)
        {
            foreach (PropertyInfo propertyInfo in GetProperties(obj))
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    var rollValue = obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                    if (rollValue != null && rollValue.ToString() != string.Empty && rollValue.ToString().Contains("'"))
                    {
                        propertyInfo.SetValue(obj, rollValue.ToString().Replace("'", "''"), null);
                    }
                }
            }
        }

        public static PropertyInfo[] GetProperties<T>(T obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            return properties;
        }
    }
}
