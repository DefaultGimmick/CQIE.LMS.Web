using CQIE.LMS.Models;
using CQIE.LMS.Models.Dtos;
using CQIE.LMS.Models.Identity;
using CQIE.LMS.Services;
using CQIE.LMS.Utility;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using static NPOI.HSSF.Util.HSSFColor;

namespace CQIE.LMS.Web.Controllers
{
    public class BusinessController : Controller
    {
        private CQIE.LMS.Services.ICargoConsignmentOrderServices m_CargoConsignmentOrderServices;
        private CQIE.LMS.Services.IFreightDispatchOrderServices m_FreightDispatchServices;
        private CQIE.LMS.Services.IExpenseReimbursementOrderServices m_ExpenseReimbursementDetailsServices;
        private CQIE.LMS.Services.IFinancialStatementServices m_FinancialStatementServices;

        public BusinessController(
            CQIE.LMS.Services.ICargoConsignmentOrderServices cargoConsignmentOrderService, 
            CQIE.LMS.Services.IFreightDispatchOrderServices freightDispatchListService,
            CQIE.LMS.Services.IExpenseReimbursementOrderServices expenseReimbursementDetailsService,
            CQIE.LMS.Services.IFinancialStatementServices financialStatementServices)
        {
            m_CargoConsignmentOrderServices = cargoConsignmentOrderService;
            m_FreightDispatchServices = freightDispatchListService;
            m_ExpenseReimbursementDetailsServices = expenseReimbursementDetailsService;
            m_FinancialStatementServices = financialStatementServices;
        }

        #region 集装箱货运单
        /// <summary>
        /// 货物托运订单列表
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderList()
        {
            var orders = m_CargoConsignmentOrderServices.GetOrders();
            return (View(orders));
        }

        /// <summary>
        /// 获取session中的用户信息
        /// </summary>
        /// <returns></returns>
        public SysUser GetUserInfo()
        {
            string jsonUser = HttpContext.Session.GetString("SessionUser");
            SysUser user = new SysUser();
            SysUser data = JsonConvert.DeserializeObject(jsonUser, user.GetType()) as SysUser;
            return data;
        }

        /// <summary>
        /// 保存货物托运订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveOrder([FromForm] CQIE.LMS.Models.CargoConsignmentOrder order, [FromForm] CQIE.LMS.Models.Freight[] freights) 
        {
            if (this.ModelState.IsValid)
            {
                SysUser user = GetUserInfo();
                order.BP_Id = user.Id;
                m_CargoConsignmentOrderServices.SaveOrder(order, freights);
            }

            return View("EditOrder");
        }

        public IActionResult AddOrder()
        {

            return View();
        }

        /// <summary>
        /// 查询调度单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectOrder(string order)
        {
            var CargoConsignmentOrder = m_CargoConsignmentOrderServices.GetCargoConsignmentOrder(order);
            return View("orderList", CargoConsignmentOrder);
        }

        /// <summary>
        /// 删除货物托运订单
        /// </summary>
        /// <returns></returns>
        public IActionResult RemoveOrder(int id)
        {
            if (m_CargoConsignmentOrderServices.RemoveOrder(id))
            {
                //删除成功
                return Redirect("/Business/OrderList");
            }
            else
            {
                return Content("删除货物托运订单出错，转向到错误信息");
            }
        }

        /// <summary>
        /// 编辑货物托运订单
        /// </summary>
        /// <returns></returns>
        public IActionResult EditOrder(int? id = null)
        {
            CQIE.LMS.Models.CargoConsignmentOrder order = null;
            if (id.HasValue)
            {
                order = m_CargoConsignmentOrderServices.GetOrderById(id.Value);
            }
            return View(order);
        }
        #endregion

        #region 调度单
        /// <summary>
        /// 调度单列表
        /// </summary>
        /// <returns></returns>
        public IActionResult DispatchList()
        {
            var orders = m_FreightDispatchServices.GetFreightDispatchOrderList();
            return (View(orders));
        }

        /// <summary>
        /// 添加调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddDispatch(int id)
        {
            CQIE.LMS.Models.CargoConsignmentOrder order = null;
            order = m_CargoConsignmentOrderServices.GetOrderById(id);
            if(order != null)
            {
                CQIE.LMS.Models.FreightDispatchOrder dispatch = new LMS.Models.FreightDispatchOrder();
                dispatch.CCO_Id = id;
                
                dispatch.Notes = order.Notes;
                dispatch.DispatchNumber = order.ConsignmentNumber;

                dispatch.consignmentOrder = order;
                SysUser user = GetUserInfo();
                dispatch.FD_Id = user.Id;

                return View(dispatch);
            }
 
            return View();
        }

        /// <summary>
        /// 编辑调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditDispatch(int id)
        {
            var orders = m_FreightDispatchServices.GetFreightDispatchOrderById(id);
            return (View("EditDispatch", orders));
        }

        /// <summary>
        /// 查询调度单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectDispatchOrder(string order)
        {
            var cargoConsignment = m_FreightDispatchServices.GetFreightDispatchOrder(order);
            return View("DispatchList", cargoConsignment);
        }

        /// <summary>
        /// 保存调度单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IActionResult SaveDispatch([FromForm] CQIE.LMS.Models.FreightDispatchOrder order)
        {
            if (this.ModelState.IsValid)
            {
                if (m_FreightDispatchServices.SaveFreightDispatchOrder(order))
                {
                    return Redirect("/Business/DispatchList");
                }
                else
                {
                    return View("EditDispatch", order);
                }
            }          

            return Redirect("EditDispatch");
        }

        /// <summary>
        /// 删除调度单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RemoveDispatch(int id)
        {
            if (m_FreightDispatchServices.RemoveSaveFreightDispatchOrder(id))
            {
                //删除成功
                return Redirect("/Business/DispatchList");
            }
            else
            {
                return Content("删除调度单出错，转向到错误信息");
            }
        }
        #endregion

        #region 报销单
        /// <summary>
        /// 展示报销单在财务管理
        /// </summary>
        /// <returns></returns>
        public IActionResult ReimbursementList()
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementList();
            return (View(reimbursement));
        }

        /// <summary>
        /// 展示报销单在调度管理
        /// </summary>
        /// <returns></returns>
        public IActionResult ShowReimbursementList(int id)
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementList();
            return (View(reimbursement));
        }

        /// <summary>
        /// 审核报销单
        /// </summary>
        /// <returns></returns>
        public IActionResult AuditReimbursement(int id)
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementById(id);
            return View("AuditReimbursement", reimbursement);
        }

        /// <summary>
        /// 编辑报销单
        /// </summary>
        /// <returns></returns>
        public IActionResult EditReimbursement(int id)
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementById(id);
            return View("EditReimbursement", reimbursement);
        }

        /// <summary>
        /// 查询报销单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectReimbursementOrder(string order)
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementByOrder(order);
            return View("ReimbursementList", reimbursement);
        }

        /// <summary>
        /// 查询报销单(司机)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectShowReimbursementOrder(string order)
        {
            var reimbursement = m_ExpenseReimbursementDetailsServices.GetReimbursementByOrder(order);
            return View("ShowReimbursementList", reimbursement);
        }

        /// <summary>
        /// 添加报销单
        /// </summary>
        /// <returns></returns>
        public IActionResult AddReimbursement(int id)
        {
            CQIE.LMS.Models.FreightDispatchOrder order = null;
            order = m_FreightDispatchServices.GetFreightDispatchOrderById(id);
            if (order != null)
            {
                CQIE.LMS.Models.ExpenseReimbursementOrder reimbursement = new LMS.Models.ExpenseReimbursementOrder();
                reimbursement.FD_Id = id;
                reimbursement.DetailsNumber = order.DispatchNumber;

                reimbursement.FreightDispatOrder = order;

                SysUser user = GetUserInfo();
                reimbursement.FAD_Id = user.Id;
                return View(reimbursement);
            }
            return View();
        }

        /// <summary>
        /// 保存报销单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IActionResult SaveReimbursement([FromForm] CQIE.LMS.Models.ExpenseReimbursementOrder order)
        {
            if (this.ModelState.IsValid)
            {
                if (m_ExpenseReimbursementDetailsServices.SaveReimbursement(order))
                {
                    return Redirect("/Business/ShowReimbursementList");
                }
                else
                {
                    return View("AddReimbursement", order);
                }
            }

            return Redirect("AddReimbursement");
        }

        /// <summary>
        /// 查询报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowReimbursement(int id)
        {
            var orders = m_ExpenseReimbursementDetailsServices.GetReimbursementById(id);
            return (View(orders));
        }
        
        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RemoveReimbursement(int id)
        {
            if (m_ExpenseReimbursementDetailsServices.RemoveReimbursement(id))
            {
                //删除成功
                return Redirect("/Business/ReimbursementList");
            }
            else
            {
                return Content("删除货物托运订单出错，转向到错误信息");
            }
        }
        #endregion

        #region 报表 

        public IActionResult FinancialStatement()
        {
            var financialStatement = m_FinancialStatementServices.GetFinancialStatement();
            return View(financialStatement);
        }

        public IActionResult GetPieChart()
        {
            int number1 = new int();
            number1 = m_FinancialStatementServices.GetOrderNum();

            int number2 = new int();
            number2 = m_FinancialStatementServices.GetDispatchNum();

            int number3 = new int();
            number3 = m_FinancialStatementServices.GetReimbursementNum();
            return Json(new { order = number1, dispatch = number2, reimbursement = number3});
        }
        
        public IActionResult GetBarChart()
        {
            List<float> value1 = new List<float>();
            value1 = m_FinancialStatementServices.GetIncome();

            List<float> value2 = new List<float>();
            value2 = m_FinancialStatementServices.GetExpenditures();

            List<float> value3 = new List<float>();
            value3 = m_FinancialStatementServices.GetProfit();
            
            return Json(new { income = value1, expenditures =  value2, profit = value3});
        }

        public IActionResult OutExcel()
        {
            var financialStatement = m_FinancialStatementServices.GetFinancialStatement();
            List<CQIE.LMS.Models.Dtos.FinancialStatement> financialStatements = new List<FinancialStatement>();
            foreach (var item in financialStatement)
            {
                if(item.PaymentMethod == "0")
                {
                    item.PaymentMethod = "现金支付";
                    financialStatements.Add(item);
                }else
                {
                    item.PaymentMethod = "银行支付";
                    financialStatements.Add(item);
                }
                
            }
            var FileName = "test.xls";
            ExcelHelper<FinancialStatement>.SaveXlsChangeds(FileName, financialStatements);
            return View("FinancialStatement", financialStatement);
        }
        #endregion 
    }
}
