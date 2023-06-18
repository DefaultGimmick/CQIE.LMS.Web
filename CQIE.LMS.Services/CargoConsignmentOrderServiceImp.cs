using CQIE.LMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 货物托运订单服务实现
    /// </summary>
    public class CargoConsignmentOrderServiceImp : ICargoConsignmentOrderServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public CargoConsignmentOrderServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }
        /// <summary>
        /// 获取集装箱货运单列表
        /// </summary>
        /// <returns>集装箱货运单列表</returns>
        public IQueryable<CQIE.LMS.Models.CargoConsignmentOrder> GetOrders()
        {
            var query = from o in m_Manager.Ctx.CargoConsignmentsOrders select o;
            return query;
        }

        /// <summary>
        /// 获取单个集装箱货运单
        /// </summary>
        /// <returns>单个集装箱货运单</returns>
        public CQIE.LMS.Models.CargoConsignmentOrder GetOrderById(int id)
        {
            var query = (from o in m_Manager.Ctx.CargoConsignmentsOrders.Include(c => c.Freights)
                         where o.Id == id select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过单号获取报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.CargoConsignmentOrder> GetCargoConsignmentOrder(string order)
        {
            var query = (from o in m_Manager.Ctx.CargoConsignmentsOrders.Include(c => c.Freights).Include(c => c.FreightDispatOrder)
                         where o.ConsignmentNumber.Contains(order)
                         select o);
            return query;
        }

        /// <summary>
        /// 保存集装箱货运单
        /// </summary>
        /// <param name="order"></param>
        /// <returns>保存成功返回true,否则返回false</returns>
        public bool SaveOrder(CQIE.LMS.Models.CargoConsignmentOrder order, CQIE.LMS.Models.Freight[] freights)
        {
            var item = m_Manager.Ctx.CargoConsignmentsOrders.Where(c => c.Id == order.Id).Include(c => c.Freights).FirstOrDefault();
            if (item == null)
            {
                order.ConsignmentNumber = "LMS30" + DateTime.Now.ToString("yyyyMMddHHmmss");
                order.Status = 2;
                foreach (Freight freight in freights)
                {
                    order.Freights.Add(freight);
                    order.TotalAmount += freight.TotalCost;
                }

                //order.Freights.Add(freights);
                //order.TotalAmount = freights.TotalCost;
                m_Manager.Ctx.CargoConsignmentsOrders.Add(order);
            }
            else
            {
                item.ShippingLocation = order.ShippingLocation;
                item.ReceivingLocation = order.ReceivingLocation;
                item.Notes = order.Notes;
                item.Carrier = order.Carrier;
                item.Telephone = order.Telephone;
                item.PaymentMethod = order.PaymentMethod;
                item.ReceivingMethod = order.ReceivingMethod;
                item.SenderName = order.SenderName;
                item.SenderTelephone = order.SenderTelephone;
                item.SenderEmail = order.SenderEmail;
                item.SenderAddress = order.SenderAddress;
                item.ConsigneeName = order.ConsigneeName;
                item.ConsigneeTelephone = order.ConsigneeTelephone;
                item.ConsigneeEmail = order.ConsigneeEmail;
                item.ConsigneeAddress = order.ConsigneeAddress;
                item.DateOfShipment = order.DateOfShipment;
                
                
                m_Manager.Ctx.CargoConsignmentsOrders.Update(item);
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// 删除集装箱货运单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveOrder(int id)
        {
            var item = (from o in m_Manager.Ctx.CargoConsignmentsOrders.Include(c => c.Freights)
                        where o.Id == id select o).FirstOrDefault();

            if (item != null)
            {
                m_Manager.Ctx.CargoConsignmentsOrders.Remove(item);
                m_Manager.Ctx.SaveChanges();

                return true;
            }
            return false;
        }


    }
}
