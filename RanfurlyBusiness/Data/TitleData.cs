using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class TitleData
    {
        public List<Title> GetList()
        {
            List<Title> list = new List<Title>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_Title");

            foreach (DataRow dr in dt.Rows)
            {
                Title title = new Title
                {
                    TitleId = (int)dr["TitleId"],
                    TitleName = dr["Title"].ToString()
                };
                list.Add(title);
            }
            return list;
        }
    }
}
