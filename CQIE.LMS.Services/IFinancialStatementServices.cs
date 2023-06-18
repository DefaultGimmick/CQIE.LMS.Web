using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    public interface IFinancialStatementServices
    {
        /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <returns></returns>
        int GetOrderNum();

        /// <summary>
        /// 查询各业务人员所完成的业务量
        /// </summary>
        /// <returns></returns>
        // public int GetBusinessNum();

        /// <summary>
        /// 查询调度单数量
        /// </summary>
        /// <returns></returns>
        int GetDispatchNum();

        // <summary>
        /// 查询报销单数量
        /// </summary>
        /// <returns></returns>
        int GetReimbursementNum();

        /// <summary>
        /// 获取订单收入
        /// </summary>
        /// <returns></returns>
        List<float> GetIncome();


        /// <summary>
        /// 获取报销单的支出
        /// </summary>
        /// <returns></returns>
        List<float> GetExpenditures();

        /// <summary>
        /// 获取每个月的利润
        /// </summary>
        /// <returns></returns>
        List<float> GetProfit();


        /// <summary>
        /// 获取该月份财务报表
        /// </summary>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.Dtos.FinancialStatement> GetFinancialStatement();

    }
}
