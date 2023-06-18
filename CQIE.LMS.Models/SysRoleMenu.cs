using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    [Table("TB_SysRoleMenu")]
    public class SysRoleMenu
    {
        public int Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }


        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }

        public CQIE.LMS.Models.Identity.SysRole Role { get; set; }

        public SystemMenu Menu { get; set; }


        public ICollection<SysRoleMenuOperation> SysRoleMenuOperations { get; set; } = new HashSet<SysRoleMenuOperation>();
    }
}
