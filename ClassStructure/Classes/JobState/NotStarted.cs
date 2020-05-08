using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class NotStarted : JobState
    {
        public NotStarted(Job job)
            : base(job)
        {}
        //    CurrentJob = job;
        //}
    
        public override void Update()
        {
          
        }

        public override DataTable GetTasks()
        {
            return base.GetTasks();
        }

    }
    
}
