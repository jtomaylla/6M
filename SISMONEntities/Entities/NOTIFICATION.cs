using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISMONRules.Entities
{
   public class NOTIFICATION
    {
        public int NotificationType { get; set; }
        public decimal Cost_Percent { get; set; }
        public int Days_From_Start { get; set; }
        public string TaskName { get; set; }
        public int Id_Project { get; set; }
        public string ProjectName { get; set; }
    }
}
