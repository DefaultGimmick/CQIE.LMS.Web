using CQIE.LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    public class ExpenseReimbursementOrderServiceImp:IExpenseReimbursementOrderServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public ExpenseReimbursementOrderServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        /// <summary>
        /// 获取报销单列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.ExpenseReimbursementOrder> GetReimbursementList()
        {
            var query = from o in m_Manager.Ctx.ExpenseReimbursementOrders.Include(c => c.FinanceStaffAndDriver) select o;
            return query;
        }

        /// <summary>
        /// 获取单个报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CQIE.LMS.Models.ExpenseReimbursementOrder GetReimbursementById(int id)
        {
            var query = (from o in m_Manager.Ctx.ExpenseReimbursementOrders.Include(c => c.FreightDispatOrder)
                         where o.Id == id select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过单号获取单个报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.ExpenseReimbursementOrder> GetReimbursementByOrder(string order)
        {
            var query = (from o in m_Manager.Ctx.ExpenseReimbursementOrders.Include(c => c.FreightDispatOrder).Include(c => c.FinanceStaffAndDriver)
                         where o.DetailsNumber.Contains(order)
                         select o);
            return query;
        }

        /// <summary>
        /// 保存报销单
        /// </summary>
        /// <param name="reimbursement"></param>
        /// <returns></returns>
        public bool SaveReimbursement(CQIE.LMS.Models.ExpenseReimbursementOrder reimbursement)
        {
            var item = m_Manager.Ctx.ExpenseReimbursementOrders.Where(c => c.Id == reimbursement.Id).FirstOrDefault();
            if (item == null)
            {
                //修改调度状态
                var query = (from o in m_Manager.Ctx.FreightDispatchOrders
                             where o.DispatchNumber == reimbursement.DetailsNumber
                             select o).FirstOrDefault();
                query.Status = 1;
                reimbursement.Status = 3;
                reimbursement.Time = DateTime.Now;
                m_Manager.Ctx.FreightDispatchOrders.Update(query);
                m_Manager.Ctx.ExpenseReimbursementOrders.Add(reimbursement);
            }
            else
            {
                item.FeeAmount = reimbursement.FeeAmount;
                item.Notes = reimbursement.Notes;
                item.Status = reimbursement.Status;
                item.Explain = reimbursement.Explain;
                item.SourceOfExpensesDetails = reimbursement.SourceOfExpensesDetails;
                item.FeeAmount = reimbursement.FeeAmount;
                m_Manager.Ctx.ExpenseReimbursementOrders.Update(item);
                
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// 修改报销单
        /// </summary>
        /// <param name="reimbursement"></param>
        /// <returns></returns>
        public bool ModifyReimbursement(CQIE.LMS.Models.ExpenseReimbursementOrder reimbursement)
        {
            var item = m_Manager.Ctx.ExpenseReimbursementOrders.Where(c => c.Id == reimbursement.Id).FirstOrDefault();
            if (item != null)
            {
                item.SourceOfExpensesDetails = reimbursement.SourceOfExpensesDetails;
                item.FeeAmount = reimbursement.FeeAmount;
                item.Explain = reimbursement.Explain;
                item.Status = reimbursement.Status; 
                item.Time = DateTime.Now;
                m_Manager.Ctx.ExpenseReimbursementOrders.Update(item);
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public bool RemoveReimbursement(int id)
        {
            var item = (from o in m_Manager.Ctx.ExpenseReimbursementOrders where o.Id == id select o).FirstOrDefault();

            if (item != null)
            {
                m_Manager.Ctx.ExpenseReimbursementOrders.Remove(item);
                m_Manager.Ctx.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
