using CQIE.LMS.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 费用报销详细信息
    /// </summary>
    [Table("Tb_ExpenseReimbursementOrder")]
    public class ExpenseReimbursementOrder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 明细编号
        /// </summary>
        public string DetailsNumber { get; set; }

        /// <summary>
        /// 费用来源明细
        /// </summary>
        public string SourceOfExpensesDetails { get; set; }

        /// <summary>
        /// 费用总金额
        /// </summary>
        public float FeeAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 费用产生时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 状态，1表示通过，2表示不通过，3表示审核中
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 不通过说明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 财务人员Id(包含司机)
        /// </summary>
        public int FAD_Id { get; set; }
        public SysUser FinanceStaffAndDriver { get; set; }

        /// <summary>
        /// 调度单Id
        /// </summary>
        public int FD_Id { get; set; }
        public FreightDispatchOrder FreightDispatOrder { get; set; }
    }
}
