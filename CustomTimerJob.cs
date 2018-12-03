using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace TimerJobExample
{

    public class CustomTimerJob : SPJobDefinition
    {
        public CustomTimerJob() : base() { }
        public CustomTimerJob(string jobName, SPService service)
            : base(jobName, service, null, SPJobLockType.None)
        {
            this.Title = "Task Complete Timer";
        }
        public CustomTimerJob(string jobName, SPWebApplication webapp)
            : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
        {
            this.Title = "Task Complete Timer";
        }
        public override void Execute(Guid targetInstanceId)
        {
            SPWebApplication webApp = this.Parent as SPWebApplication;
            SPList taskList = webApp.Sites["sites/OnlineExam"].RootWeb.Lists["Tasks"];
            SPListItem newTask = taskList.Items.Add();
            newTask["Title"] = "New Task" + DateTime.Now.ToString();
            newTask.Update();
        }
    }
}
