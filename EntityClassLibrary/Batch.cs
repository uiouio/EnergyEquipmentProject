using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class Batch:BaseEntity
    {
        private UserInfo supervisory;
        public virtual UserInfo Supervisory
        {
            get { return supervisory; }
            set { supervisory = value; }
        }

        private string number;
        public virtual string Number
        {
            get { return number; }
            set { number = value; }
        }

        private long date;
        public virtual long Date
        {
            get { return date; }
            set { date = value; }
        }


    }
}
