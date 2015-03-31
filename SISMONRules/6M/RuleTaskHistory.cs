using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleTaskHistory : Cooperator.Framework.Data.BaseRule
    {
        public static void Insert(TASK_HISTORY item)
        {
            TASK_HISTORYMapper.Instance().Insert(item);
        }
    }
}
