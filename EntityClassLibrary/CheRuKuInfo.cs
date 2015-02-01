using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class CheRuKuInfo:BaseEntity
    {
        private long modificationOfContractId;
        public virtual long ModificationOfContractId
        {
            get { return modificationOfContractId; }
            set { modificationOfContractId = value; }
        }

        private long actualCompletionDate;
        public virtual long ActualCompletionDate
        {
            get { return actualCompletionDate; }
            set { actualCompletionDate = value; }
        }

        private string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string confirmor;
        public virtual string Confirmor
        {
            get { return confirmor; }
            set { confirmor = value; }
        }

        private RefitWork refitWork;
        public virtual RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }

        private WorkingGroup workingGroup;
        public virtual WorkingGroup WorkingGroup
        {
            get { return workingGroup; }
            set { workingGroup = value; }
        }



        private string specification;
        public virtual string Specification
        {
            get { return specification; }
            set { specification = value; }
        }

        private string workContent;
        public virtual string WorkContent
        {
            get { return workContent; }
            set { workContent = value; }
        }

        private int status;
        public virtual int Status
        {
            get { return status; }
            set { status = value; }
        }

        public enum savecheck
        {
            save=0,
            check=1
        }

        private TiaoShiBaoGao tiaoShiBaoGao;
        public virtual TiaoShiBaoGao TiaoShiBaoGao
        {
            get { return tiaoShiBaoGao; }
            set { tiaoShiBaoGao = value; }
        }



        //private IList<>

    }
}
