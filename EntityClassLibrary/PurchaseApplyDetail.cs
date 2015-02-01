using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class PurchaseApplyDetail:BaseEntity
    {
        GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }

        PurchaseApply purchaseApplyId;
        public virtual PurchaseApply PurchaseApplyId
        {
            get { return purchaseApplyId; }
            set { purchaseApplyId = value; }
        }
        
        long reportQuanlity;
        public virtual long ReportQuanlity
        {
            get { return reportQuanlity; }
            set { reportQuanlity = value; }
        }

        long planQuanlity;
        public virtual long PlanQuanlity
        {
            get { return planQuanlity; }
            set { planQuanlity = value; }
        }


        PurchaseContract purchaseContractId;
        public virtual PurchaseContract PurchaseContractId
        {
            get { return purchaseContractId; }
            set { purchaseContractId = value; }
        }

       
       
        SupplierInfo supplierInfoId;
        public virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }

        float goodsSingleAmount;
        public virtual float GoodsSingleAmount
        {
            get { return goodsSingleAmount; }
            set { goodsSingleAmount = value; }
        }

        long purchaseApplyDetailState;
        public virtual long PurchaseApplyDetailState
        {
            get { return purchaseApplyDetailState; }
            set { purchaseApplyDetailState = value; }
        }

        string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public enum purchasedeilstate
        {
            /// <summary>
            /// 采购申请等待采购负责任人审核
            /// </summary>
           caigoushenqingdengdaishenheForcaigoufuzeren =0, //
           /// <summary>
           /// 采购申请被采购负责人退回
           /// </summary>
            caigoushenqingbeiTuihuiForcaigouFuzeRen = 1,//
            /// <summary>
            /// 采购申请负责任人通过等待总经理审核
            /// </summary>
            caigoushenqingdengdaishenheForzongjingli = 2,//
            /// <summary>
            /// 总经理退回;
            /// </summary>
            caigoushenqingbeiTuihuiForZongJingLi = 3,//
           /// <summary>
            /// 申请已通过等待比价评审（总经理通过）
           /// </summary>
            shenqingyitonggudengdaibijiapingshen = 4, 
           /// <summary>
            /// 已经生成比价评审等待评审审核
           /// </summary>
            shengchengbijiapingshendengdaiquerenhetong = 5,
            
            /// <summary>
            /// 评审审核通过等待生成合同
            /// </summary>
            pingshenshenheTongguoDengdaiShengchenghetong = 6,
            
            /// <summary>
            /// 评审被退回
            /// </summary>
            pingshenTuihui = 7,

            /// <summary>
            /// 合同已经生成等待审核
            /// </summary>
            hetongyijingshengchengdengdaishenhe = 8,
           /// <summary>
            /// 合同已经通过
           /// </summary>
            hetongweitongguo = 9,// 
            /// <summary>
            /// 合同审核被退回
            /// </summary>
            hetongshenhebeituihui = 10
        }

        public static string[] StateName =
        { 
            "等待采购负责人审核",//0
            "采购负责人退回",//1
            "等待总经理审核",//2
            "总经理退回",//3
            "等待比价评审",//4
            "等待评审审核",//5
            "等待生成合同", //6
            "评审已被退回",//7
            "合同等待审核",//8
            "合同通过",//9
            "合同退回"//10
        };

        public static string[] StateColor = 
        {
            "#e2655f",//红色 0
            "#828081",//灰色 1
            "#e2655f",//红色 2
            "#828081",//灰色 3
            "#df5e3f",//橘黄色 4
            "#41a7be",//蓝色 5
            "#828081",//灰色 6
            "#df5e3f",//橘黄色 7
            "#54badc",//浅蓝色 8
            "#74c6a9",//绿色 9
            "#828081" //灰色 10
        };


    }
}
