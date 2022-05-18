using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakthrough
{
    class Challenge
    {
        protected List<string> Condition;
        protected bool Met;

        public Challenge()
        {
            Met = false;
        }

        public bool GetMet()
        {
            return Met;
        }

        public List<string> GetCondition()
        {
            return Condition;
        }

        public void SetMet(bool newValue)
        {
            Met = newValue;
        }

        public void SetCondition(List<string> newCondition)
        {
            Condition = newCondition;
        }
    }
}
