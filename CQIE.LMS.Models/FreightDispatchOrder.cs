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
    /// 货运调度单
    /// </summary>
    [Table("Tb_FreightDispatchOrder")]
    public class FreightDispatchOrder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 调度单号
        /// </summary>
        public string DispatchNumber { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 司机电话号码
        /// </summary>
        public string DriverTelephone { get; set; }

        /// <summary>
        /// 车辆
        /// </summary>
        public string Car { get; set; }

        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 调度人员Id
        /// </summary>
        public int FD_Id { get; set; }

        /// <summary>
        /// 状态，1表示已报销，2表示没有报销
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 调度人员
        /// </summary>
        public SysUser DispatchPersonnel { get; set; }

        /// <summary>
        /// 托运单Id
        /// </summary>
        public int CCO_Id { get; set; }

        /// <summary>
        /// 调度单所属的托运单
        /// </summary>
        public CargoConsignmentOrder consignmentOrder { get; set; } 

        public ExpenseReimbursementOrder ExpenseReimbursementOrder { get; set; }

    }
}
