using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMFileManager
{
    public interface Interface2
    {
        void ProcessData();
        void ImportData();
        void ImportData(string TableName);
        void SaveData();
        //void Update();
        //void Delete();
    }
}
