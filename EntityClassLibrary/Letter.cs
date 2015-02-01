using System;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class Letter : BaseEntity
    {
        private UserInfo senderUser;

        public virtual UserInfo SenderUser
        {
            get { return senderUser; }
            set { senderUser = value; }
        }
        private long senderTime;

        public virtual long SenderTime
        {
            get { return senderTime; }
            set { senderTime = value; }
        }
        private string letterContent;

        public virtual string LetterContent
        {
            get { return letterContent; }
            set { letterContent = value; }
        }
        private string letterTitle;

        public virtual string LetterTitle
        {
            get { return letterTitle; }
            set { letterTitle = value; }
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

        private IList<UserInfo> users;

        public virtual IList<UserInfo> Users
        {
            get { return users; }
            set { users = value; }
        }

    }
}
