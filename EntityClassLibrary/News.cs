using System;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class News : BaseEntity
    {
        private UserInfo publishUser;

        public virtual UserInfo PublishUser
        {
            get { return publishUser; }
            set { publishUser = value; }
        }
        private long publishTime;

        public virtual long PublishTime
        {
            get { return publishTime; }
            set { publishTime = value; }
        }
        private string newsContent;

        public virtual string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }
        private string newsTitle;

        public virtual string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }
        private string fileName;

        public virtual string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string filePath;

        public virtual string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

    }
}
