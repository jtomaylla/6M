using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.UI;
using Telerik.Web.UI.Gantt;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Web;
using System.Web.SessionState;

namespace SISMONRules.Provider
{
    public class GanttCustomProvider : GanttProviderBase
    {

        public override ITaskFactory TaskFactory
        {
            get
            {
                return new CustomGanttTaskFactory();
            }
        }

        #region Properties

        const string id_Project = "Id_Project";
        const string id_Status = "Id_Status";
        const string modifytask = "ModifyTask";

        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public static Int32 Id_Project
        {
            get { return Convert.ToInt32(Session[id_Project]); }
            set { Session[id_Project] = value; }
        }

        public static byte Id_Status
        {
            get { if (Session[id_Status] == null) return Convert.ToByte(eStatus.Open.GetHashCode()); else return Convert.ToByte(Session[id_Status]); }
            set { Session[id_Status] = value; }
        }

        public static bool ModifyTask
        {
            get
            {
                bool ReturnValue = true;
                if (Session[modifytask] != null) ReturnValue = Convert.ToBoolean(Session[modifytask]);
                return ReturnValue;
            }
            set { Session[modifytask] = value; }
        }

        #endregion

        #region Tasks

        public override List<ITask> GetTasks()
        {
            var tasks = new List<ITask>();
            TASKList list = RuleTask.GetAllByProject(GanttCustomProvider.Id_Project);
            list.SetSemaphore();
            tasks.AddRange(list.Select(task => new CustomTask
            {
                ID = task.Id_Task,
                ParentID = task.Id_Task_Parent,
                OrderID = task.Order,
                Start = task.Start,
                End = task.End,
                PercentComplete = task.Percent_Complete,
                Summary = task.Summary,
                Title = task.Title,
                Expanded = task.Expanded.HasValue && task.Expanded.Value,
                Initial_Cost = Convert.ToDecimal(task.Initial_Cost),
                Final_Cost = Convert.ToDecimal(task.Final_Cost),
                Indicator = task.Indicator,
                Relative_Cost = Helper.CalculateRelativeCost(task)
            }));
            return tasks;
        }

        public override ITask UpdateTask(ITask task)
        {
            if (ModifyTask)
            {
                TASK entityTask = ToEntityTask(task);
                RuleTask.Update(entityTask);
            }
            else
            {
                task = GetTasks().First(x => Convert.ToInt32(x.ID) == Convert.ToInt32(task.ID));
            }
            return task;
        }

        public override ITask DeleteTask(ITask task)
        {
            if (ModifyTask)
            {
                TASK entityTask = ToEntityTask(task);
                RuleTask.Delete(entityTask.Id_Task);
            }
            else
            {
                task = InsertTask(task);
            }
            return task;
        }

        public override ITask InsertTask(ITask task)
        {
            if (ModifyTask)
            {
                task.ID = 0; // Value will be updated from DB
                TASK entityTask = ToEntityTask(task);
                RuleTask.Insert(entityTask);
                task.ID = entityTask.Id_Task;
            }
            return task;
        }

        #endregion

        #region Dependencies

        public override List<IDependency> GetDependencies()
        {
            var dependencies = new List<IDependency>();
            DEPENDENCYList list = RuleDependency.GetAllByProject(GanttCustomProvider.Id_Project);
            dependencies.AddRange(list.Select(dependency => new Dependency()
            {
                ID = dependency.Id_Dependency,
                PredecessorID = dependency.Id_Predecessor,
                SuccessorID = dependency.Id_Successor,
                Type = (DependencyType)dependency.Type
            }));
            return dependencies;
        }

        public override IDependency DeleteDependency(IDependency dependency)
        {
            if (ModifyTask)
            {
                DEPENDENCY entityDependency = ToEntityDependency(dependency);
                RuleDependency.Delete(entityDependency.Id_Dependency);
            }
            else
            {
                //dependency = InsertDependency(dependency);
            }
            return dependency;
        }

        public override IDependency InsertDependency(IDependency dependency)
        {
            if (ModifyTask)
            {
                dependency.ID = 0; // Value will be updated from DB
                DEPENDENCY entityDependency = ToEntityDependency(dependency);
                RuleDependency.Insert(entityDependency);
                dependency.ID = entityDependency.Id_Dependency;
            }
            return dependency;
        }

        #endregion

        #region Helpers

        private TASK ToEntityTask(ITask srcTask)
        {
            decimal ic = 0, fc = 0, rc = 0;
            if (!string.IsNullOrEmpty(((CustomTask)srcTask).Initial_Cost.ToString())) ic = Convert.ToDecimal(((CustomTask)srcTask).Initial_Cost);
            if (!string.IsNullOrEmpty(((CustomTask)srcTask).Final_Cost.ToString())) fc = Convert.ToDecimal(((CustomTask)srcTask).Final_Cost);
            if (!string.IsNullOrEmpty(((CustomTask)srcTask).Relative_Cost.ToString())) rc = Convert.ToDecimal(((CustomTask)srcTask).Relative_Cost);

            return new TASK((int)srcTask.ID)
            {
                Id_Task_Parent = (int?)srcTask.ParentID,
                Order = (int)srcTask.OrderID,
                Start = srcTask.Start,
                End = srcTask.End,
                Percent_Complete = srcTask.PercentComplete,
                Summary = srcTask.Summary,
                Title = srcTask.Title,
                Expanded = srcTask.Expanded,
                Initial_Cost = ic,
                Final_Cost = fc,
                Relative_Cost = rc,
                Id_Project = GanttCustomProvider.Id_Project,
                Id_Status = GanttCustomProvider.Id_Status
            };
        }

        private DEPENDENCY ToEntityDependency(IDependency srcDependency)
        {
            return new DEPENDENCY((int)srcDependency.ID)
            {
                Id_Predecessor = (int)srcDependency.PredecessorID,
                Id_Successor = (int)srcDependency.SuccessorID,
                Type = (int)srcDependency.Type,
                Id_Project = GanttCustomProvider.Id_Project
            };
        }

        #endregion

    }

    public class CustomGanttTaskFactory : ITaskFactory
    {
        Task ITaskFactory.CreateTask()
        {
            return new CustomTask();
        }
    }

    public class CustomTask : Task
    {
        public CustomTask()
            : base()
        {
        }

        public decimal Initial_Cost
        {
            get { return (decimal)(ViewState["Initial_Cost"] ?? 0); }
            set { ViewState["Initial_Cost"] = value; }
        }

        public decimal Final_Cost
        {
            get { return (decimal)(ViewState["Final_Cost"] ?? 0); }
            set { ViewState["Final_Cost"] = value; }
        }

        public string Indicator
        {
            get { return (string)(ViewState["Indicator"] ?? ""); }
            set { ViewState["Indicator"] = value; }
        }

        public string Relative_Cost
        {
            get { return (string)(ViewState["Relative_Cost"] ?? ""); }
            set { ViewState["Relative_Cost"] = value; }
        }

        protected override IDictionary<string, object> GetSerializationData()
        {
            var dict = base.GetSerializationData();
            dict["Initial_Cost"] = Initial_Cost;
            dict["Final_Cost"] = Final_Cost;
            dict["Indicator"] = Indicator;
            dict["Relative_Cost"] = Relative_Cost;
            return dict;
        }

        public override void LoadFromDictionary(System.Collections.IDictionary values)
        {
            base.LoadFromDictionary(values);
            Initial_Cost = Convert.ToDecimal(values["Initial_Cost"]);
            Final_Cost = Convert.ToDecimal(values["Final_Cost"]);
            Indicator = Convert.ToString(values["Indicator"]);
            Relative_Cost = Convert.ToString(values["Relative_Cost"]);
        }
    }
}
