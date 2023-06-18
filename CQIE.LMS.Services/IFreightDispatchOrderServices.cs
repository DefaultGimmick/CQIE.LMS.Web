using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 调度单服务
    /// </summary>
    public interface IFreightDispatchOrderServices
    {
        /// <summary>
        /// 获取调度列表
        /// </summary>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.FreightDispatchOrder> GetFreightDispatchOrderList();

        /// <summary>
        /// 获取单个调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CQIE.LMS.Models.FreightDispatchOrder GetFreightDispatchOrderById(int id);

        /// <summary>
        /// 通过单号获取调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.FreightDispatchOrder> GetFreightDispatchOrder(string order);

        /// <summary>
        /// 保存调度单
        /// </summary>
        /// <param name="freightDispatchList"></param>
        /// <returns></returns>
        bool SaveFreightDispatchOrder(CQIE.LMS.Models.FreightDispatchOrder freightDispatchOrder);

        /// <summary>
        /// 删除调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveSaveFreightDispatchOrder(int id);
    }
}
