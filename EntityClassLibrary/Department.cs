using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class Department : BaseEntity
    {
        public Department()
        {
            itself = this;
        }
        private Department itself;
        public virtual Department Itself
        {
            get { return itself; }
        }
        private string departmentName;
        
        public virtual string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        private long parentId;
        public virtual long ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private int deptOrder;
        public virtual int DeptOrder
        {
            get { return deptOrder; }
            set { deptOrder = value; }
        }

        private string description;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int deptLevel;
        public virtual int DeptLevel
        {
            get { return deptLevel; }
            set { deptLevel = value; }
        }
    }
}
