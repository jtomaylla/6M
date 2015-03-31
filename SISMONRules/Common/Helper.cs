using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Entities;

namespace SISMONRules
{
    public static class Helper
    {
        /// <summary>
        /// Set the semaphore to TaskList
        /// </summary>
        /// <param name="list">It's the Task List</param>
        public static void SetSemaphore(this TASKList list)
        {
            //Semaphore
            foreach (var item in list)
            {
                //Green
                // if ((Initial_Cost > FinalCost) && ( StatusNotClosed ? Date.Now < End - Alert_Days_From_End : Final_End < End - Alert_Days_From_End) )
                if ((Convert.ToDecimal(item.Initial_Cost) > Convert.ToDecimal(item.Final_Cost)) && (item.Id_Status.Equals(3)? DateTime.Now.CompareTo(item.End.AddDays(-Convert.ToInt32(item.Alert_Days_From_End))) <0 : Convert.ToDateTime(item.Final_End).CompareTo(item.End.AddDays(Convert.ToInt32(item.Alert_Days_From_End)) ) < 0))
                {
                    item.Indicator = "clsGreenSemaphore";
                }
                //Red
                //else if ((Initial_Cost < Final_Cost) || (StatusNotClosed ? Date.Now > End : Final_End > End))
                else if ((Convert.ToDecimal(item.Initial_Cost) < Convert.ToDecimal(item.Final_Cost)) || (item.Id_Status.Equals(3) ? DateTime.Now.CompareTo(item.End) > 0 : Convert.ToDateTime(item.Final_End).CompareTo(item.End) > 0))
                {
                    item.Indicator = "clsRedSemaphore";
                }
                //Orange
                else
                {
                    item.Indicator = "clsOrangeSemaphore";
                }
            }
        }

        public static string CalculateRelativeCost(TASK item)
        {
            if (!item.Initial_Cost.HasValue || !item.Final_Cost.HasValue) return "0";
            if (item.Initial_Cost.Value == 0) return "0";

            return string.Format("{0}", Math.Round((item.Final_Cost.Value / item.Initial_Cost.Value) * 100).ToString());
        }
    }
}
