using CQIE.LMS.Models;
using CQIE.LMS.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQIE.LMS.Services
{
    public class FinancialStatementServiceImp:IFinancialStatementServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public FinancialStatementServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <returns></returns>
        public int GetOrderNum()
        {
            var query = m_Manager.Ctx.CargoConsignmentsOrders
                    .Where(o => o.DateOfShipment.Month == DateTime.Now.Month && o.DateOfShipment.Year == DateTime.Now.Year)
                    .Count();
            return query;
        }

        /// <summary>
        /// 查询订单数量
        /// </summary>
        /// <returns></returns>
        public int GetDispatchNum()
        {
            var query = m_Manager.Ctx.FreightDispatchOrders
                   .Where(o => o.CreateTime.Month == DateTime.Now.Month && o.CreateTime.Year == DateTime.Now.Year)
                   .Count();
            return query;
        }

        // <summary>
        /// 查询报销单数量
        /// </summary>
        /// <returns></returns>
       public int GetReimbursementNum()
        {
            var query = m_Manager.Ctx.ExpenseReimbursementOrders
                   .Where(o => o.Time.Month == DateTime.Now.Month && o.Time.Year == DateTime.Now.Year)
                   .Count();
            return query;
        }



        /// <summary>
        /// 获取订单收入
        /// </summary>
        /// <returns></returns>
        public List<float> GetIncome()
        {
            List<float> list = new List<float>();
            var query = from co in m_Manager.Ctx.CargoConsignmentsOrders
                        join fr in m_Manager.Ctx.FreightDispatchOrders on co.Id equals fr.CCO_Id
                        join er in m_Manager.Ctx.ExpenseReimbursementOrders on fr.Id equals er.FD_Id
                        group co by new { month = co.DateOfShipment.Month } into g
                        select new
                        {
                            OrderMonth = g.Key.month,
                            TotalRevenue = g.Sum(o => o.TotalAmount)
                        };
            foreach( var o in query )
            {
                list.Add(o.TotalRevenue);
            }
            return list;
        }


        /// <summary>
        /// 获取报销单
        /// </summary>
        /// <returns></returns>
        public List<float> GetExpenditures()
        {
            List<float> list = new List<float>();
            var query = from co in m_Manager.Ctx.CargoConsignmentsOrders
                        join fr in m_Manager.Ctx.FreightDispatchOrders on co.Id equals fr.CCO_Id
                        join er in m_Manager.Ctx.ExpenseReimbursementOrders on fr.Id equals er.FD_Id
                        group er by new { month = co.DateOfShipment.Month } into g
                        select new
                        {
                            OrderMonth = g.Key.month,
                            TotalRevenue = g.Sum(o => o.FeeAmount)
                        };
            foreach (var o in query)
            {
                list.Add(-o.TotalRevenue);
            }
            return list;
        }
        /// <summary>
        /// 获取每个月的利润
        /// </summary>
        /// <returns></returns>
        public List<float> GetProfit()
        {
            List<float> list = new List<float>();
            var query = from co in m_Manager.Ctx.CargoConsignmentsOrders
                         join fr in m_Manager.Ctx.FreightDispatchOrders on co.Id equals fr.CCO_Id
                         join er in m_Manager.Ctx.ExpenseReimbursementOrders on fr.Id equals er.FD_Id
                         group new { co, er } by new { co.DateOfShipment.Month } into g
                         select new
                         {
                             Month = g.Key.Month,
                             Profit = g.Sum(x => x.co.TotalAmount - x.er.FeeAmount)
                         };
            foreach (var o in query)
            {
                list.Add(o.Profit);
            }
            return list;
        }

        /// <summary>
        /// 获取该月份财务报表
        /// </summary>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.Dtos.FinancialStatement> GetFinancialStatement()
        {
            var query = from f in m_Manager.Ctx.Freights
                        join co in m_Manager.Ctx.CargoConsignmentsOrders on f.Order_Id equals co.Id
                        join fr in m_Manager.Ctx.FreightDispatchOrders on co.Id equals fr.CCO_Id
                        join er in m_Manager.Ctx.ExpenseReimbursementOrders on fr.Id equals er.FD_Id
                        where er.Time.Month == DateTime.Now.Month
                        select new FinancialStatement
                        {
                            ProjectName = f.Name,
                            TotalAmount = co.TotalAmount,
                            SourceOfExpensesDetails = er.SourceOfExpensesDetails,
                            FeeAmount = er.FeeAmount,
                            Profit = co.TotalAmount - er.FeeAmount,
                            PaymentMethod = co.PaymentMethod
                        };
       
            return query;
        }
    }
}
