using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class Resource : BaseEntity
    {

        private string resourceName;

        public virtual string ResourceName
        {
            get { return resourceName; }
            set { resourceName = value; }
        }
        private long parentId;

        public virtual long ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        private int resourceOrder;

        public virtual int ResourceOrder
        {
            get { return resourceOrder; }
            set { resourceOrder = value; }
        }
        private string typeFullName;

        public virtual string TypeFullName
        {
            get { return typeFullName; }
            set { typeFullName = value; }
        }
        private int isDisplay;

        public virtual int IsDisplay
        {
            get { return isDisplay; }
            set { isDisplay = value; }
        }
        private int resourceLevel;

        public virtual int ResourceLevel
        {
            get { return resourceLevel; }
            set { resourceLevel = value; }
        }
        private string description;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string picturePath;
        
        public virtual string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value; }
        }
        private string selectedPicturePath;

        public virtual string SelectedPicturePath
        {
            get { return selectedPicturePath; }
            set { selectedPicturePath = value; }
        }
        private IList<UserRole> userRoles;

        public virtual IList<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }
    }
}
