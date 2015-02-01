using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class PurchaseContract:BaseEntity
    {
        string purchaseContractCode;
        public virtual  string PurchaseContractCode
        {
            get { return purchaseContractCode; }
            set { purchaseContractCode = value; }
        }

        SupplierInfo supplierInfoId;
        public virtual  SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }

        string purchaseContractAddress;
        public virtual  string PurchaseContractAddress
        {
            get { return purchaseContractAddress; }
            set { purchaseContractAddress = value; }
        }
        
        long purchaseContractTime;
        public virtual  long PurchaseContractTime
        {
            get { return purchaseContractTime; }
            set { purchaseContractTime = value; }
        }
        
        long handleTime;
        public virtual  long HandleTime
        {
            get { return handleTime; }
            set { handleTime = value; }
        }
        
        string handlePerson;
        public virtual  string HandlePerson
        {
            get { return handlePerson; }
            set { handlePerson = value; }
        }
        
        string handleOffice;
        public virtual  string HandleOffice
        {
            get { return handleOffice; }
            set { handleOffice = value; }
        }
        
        string supName;
        public virtual  string SupName
        {
            get { return supName; }
            set { supName = value; }
        }
        
        string supAddress;
        public virtual  string SupAddress
        {
            get { return supAddress; }
            set { supAddress = value; }
        }
        
        string supPersonName;
        public virtual  string SupPersonName
        {
            get { return supPersonName; }
            set { supPersonName = value; }
        }
        
        string supEntrustPersonName;
        public virtual  string SupEntrustPersonName
        {
            get { return supEntrustPersonName; }
            set { supEntrustPersonName = value; }
        }
        
        string supPhone;
        public virtual  string SupPhone
        {
            get { return supPhone; }
            set { supPhone = value; }
        }
        
        string supTaxCode;
        public virtual  string SupTaxCode
        {
            get { return supTaxCode; }
            set { supTaxCode = value; }
        }
        
        string supBankName;
        public virtual  string SupBankName
        {
            get { return supBankName; }
            set { supBankName = value; }
        }
        
        string supBankCode;
        public virtual  string SupBankCode
        {
            get { return supBankCode; }
            set { supBankCode = value; }
        }
        
        string supZioCode;
        public virtual  string SupZioCode
        {
            get { return supZioCode; }
            set { supZioCode = value; }
        }
        
        string recName;
        public virtual  string RecName
        {
            get { return recName; }
            set { recName = value; }
        }
        
        string recAddress;
        public virtual  string RecAddress
        {
            get { return recAddress; }
            set { recAddress = value; }
        }
        
        string recPersonName;
        public virtual  string RecPersonName
        {
            get { return recPersonName; }
            set { recPersonName = value; }
        }
        
        string recEntrustPersonName;
        public virtual  string RecEntrustPersonName
        {
            get { return recEntrustPersonName; }
            set { recEntrustPersonName = value; }
        }
        
        string recPhone;
        public virtual  string RecPhone
        {
            get { return recPhone; }
            set { recPhone = value; }
        }
        
        string recTaxCode;
        public virtual  string RecTaxCode
        {
            get { return recTaxCode; }
            set { recTaxCode = value; }
        }
        
        string recBankName;
        public virtual  string RecBankName
        {
            get { return recBankName; }
            set { recBankName = value; }
        }
        
        string recBankCode;
        public virtual  string RecBankCode
        {
            get { return recBankCode; }
            set { recBankCode = value; }
        }
        
        string recZioCode;
        public virtual  string RecZioCode
        {
            get { return recZioCode; }
            set { recZioCode = value; }
        }

        long purchaseContractState;

        public virtual long PurchaseContractState
        {
            get { return purchaseContractState; }
            set { purchaseContractState = value; }
        }

        public enum PurConState 
        {
            daishenhe = 0,tongguo = 1, tuihi = 2
        }
        
        public static string[] StateName = 
        {
            "合同待批准",
            "合同已通过",
            "合同被退回"
        };

        public static string[] StateColor = 
        {
            "#e2655f",
            "#74c6a9",
            "#62767d"
        };

    }
}
