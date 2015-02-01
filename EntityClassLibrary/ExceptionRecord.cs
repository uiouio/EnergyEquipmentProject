using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class ExceptionRecord : BaseEntity
    {
        private string exceptionStackTrace;

        public virtual string ExceptionStackTrace
        {
            get { return exceptionStackTrace; }
            set { exceptionStackTrace = value; }
        }
        

        private string exceptionMessage;
        public virtual string ExceptionMessage
        {
            get { return exceptionMessage; }
            set { exceptionMessage = value; }
        }

        private string exceptionTime;
        public virtual string ExceptionTime
        {
            get { return exceptionTime; }
            set { exceptionTime = value; }
        }
    }
}
