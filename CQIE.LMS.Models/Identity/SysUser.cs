using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Models.Identity
{
    [Table("Tb_SysUser")]
    public class SysUser : Microsoft.AspNetCore.Identity.IdentityUser<int>
    {
        /// <summary>
        /// 支持登录时输入密码
        /// </summary>
        public string LoginPassword { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();

        /// <summary>
        /// 托运单
        /// </summary>
        public ICollection<CargoConsignmentOrder> BP_CargoConsignmentOrders { get; set; } = new HashSet<CargoConsignmentOrder>();

        /// <summary>
        /// 调度单
        /// </summary>
        public ICollection<FreightDispatchOrder> BP_FreightDispatchOrders { get; set; } = new HashSet<FreightDispatchOrder>();

        /// <summary>
        /// 报销单
        /// </summary>
        public ICollection<ExpenseReimbursementOrder> BP_ExpenseReimbursementOrders { get; set; } = new HashSet<ExpenseReimbursementOrder>();



    }
}
