using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 货物托运订单服务
    /// </summary>
    public interface  ICargoConsignmentOrderServices
    {

        /// <summary>
        /// 获取集装箱货运单列表
        /// </summary>
        /// <returns>集装箱货运单列表</returns>
        IQueryable<CQIE.LMS.Models.CargoConsignmentOrder> GetOrders();

        /// <summary>
        /// 获取单个集装箱货运单
        /// </summary>
        /// <returns>单个集装箱货运单</returns>
        CQIE.LMS.Models.CargoConsignmentOrder GetOrderById(int id);

        /// <summary>
        /// 通过单号获取报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.CargoConsignmentOrder> GetCargoConsignmentOrder(string order);

        /// <summary>
        /// 保存功能菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>保存成功返回true,否则返回false</returns>
        bool SaveOrder(CQIE.LMS.Models.CargoConsignmentOrder order, CQIE.LMS.Models.Freight[] freight);

        /// <summary>
        /// 删除集装箱货运单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveOrder(int id);
    }
}
