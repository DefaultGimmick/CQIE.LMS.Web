using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 调度单服务实现
    /// </summary>
    public class FreightDispatchOrderServiceImp : IFreightDispatchOrderServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public FreightDispatchOrderServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        /// <summary>
        /// 获取调度列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.FreightDispatchOrder> GetFreightDispatchOrderList()
        {
            var query = from o in m_Manager.Ctx.FreightDispatchOrders.Include(c => c.consignmentOrder)
                        select o;
            return query;
        }

        /// <summary>
        /// 获取单个调度单的运营单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CQIE.LMS.Models.FreightDispatchOrder GetFreightDispatchOrderById(int id)
        {
            var query = (from o in m_Manager.Ctx.FreightDispatchOrders.Include(c => c.consignmentOrder.Freights).Include(c => c.DispatchPersonnel)
                         where o.Id == id
                         select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过单号获取调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.FreightDispatchOrder> GetFreightDispatchOrder(string order)
        {
            var query = (from o in m_Manager.Ctx.FreightDispatchOrders.Include(c => c.consignmentOrder)
                         where o.DispatchNumber == order
                         select o);
            return query;
        }

        /// <summary>
        /// 保存调度单
        /// </summary>
        /// <param name="freightDispatchList"></param>
        /// <returns></returns>
        public bool SaveFreightDispatchOrder(CQIE.LMS.Models.FreightDispatchOrder freightDispatchOrder)
        {
            var item = m_Manager.Ctx.FreightDispatchOrders.Where(c => c.Id == freightDispatchOrder.Id).FirstOrDefault();
            //增加
            if (item == null)
            {
                //修改状态
                freightDispatchOrder.CreateTime = DateTime.Now;
                var query = (from o in m_Manager.Ctx.CargoConsignmentsOrders where o.ConsignmentNumber == freightDispatchOrder.DispatchNumber
                             select o).FirstOrDefault();
                query.Status = 1;
                freightDispatchOrder.Status = 2;
                m_Manager.Ctx.CargoConsignmentsOrders.Update(query);
                m_Manager.Ctx.FreightDispatchOrders.Add(freightDispatchOrder);
            }
            else
            {
                item.DriverName = freightDispatchOrder.DriverName;
                item.DriverTelephone  = freightDispatchOrder.DriverTelephone;
                item.Car = freightDispatchOrder.Car;
                m_Manager.Ctx.FreightDispatchOrders.Update(item);
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// 删除调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveSaveFreightDispatchOrder(int id)
        {
            var item = (from o in m_Manager.Ctx.FreightDispatchOrders where o.Id == id select o).FirstOrDefault();

            if (item != null)
            {
                m_Manager.Ctx.FreightDispatchOrders.Remove(item);
                m_Manager.Ctx.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
