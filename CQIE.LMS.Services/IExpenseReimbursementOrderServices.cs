using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 报销单服务
    /// </summary>
    public interface IExpenseReimbursementOrderServices
    {
        /// <summary>
        /// 获取报销单列表
        /// </summary>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.ExpenseReimbursementOrder> GetReimbursementList();

        /// <summary>
        /// 获取单个报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CQIE.LMS.Models.ExpenseReimbursementOrder GetReimbursementById(int id);

        /// <summary>
        /// 通过单号获取报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.ExpenseReimbursementOrder> GetReimbursementByOrder(string  order);

        /// <summary>
        /// 保存报销单
        /// </summary>
        /// <param name="reimbursement"></param>
        /// <returns></returns>
        bool SaveReimbursement(CQIE.LMS.Models.ExpenseReimbursementOrder reimbursement);

        /// <summary>
        /// 修改报销单
        /// </summary>
        /// <param name="reimbursement"></param>
        /// <returns></returns>
        bool ModifyReimbursement(CQIE.LMS.Models.ExpenseReimbursementOrder reimbursement);

        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        bool RemoveReimbursement(int OrderId);
    }
}
