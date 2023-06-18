using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Table("TB_SysRole")]
    public class SysRole : Microsoft.AspNetCore.Identity.IdentityRole<int>
    {
        public ICollection<SysRoleMenu> SysRoleMenus { get; set; } = new HashSet<SysRoleMenu>();

        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();

    }
}
