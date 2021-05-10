using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Affair
    {
        public bool done;
        public string task;
        public DateTime date;
        public IdInfo IdInfo;

        public Affair ShallowCopy()
        {
            return (Affair)this.MemberwiseClone();
        }

        public Affair DeepCopy()
        {
            Affair clone = (Affair)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.task = String.Copy(task);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

}
