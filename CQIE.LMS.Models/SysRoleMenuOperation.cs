using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    [Table("TB_SysRoleMenuOperation")]
    public class SysRoleMenuOperation
    {
        public int Id { get; set; }

        /// <summary>
        /// 角色与菜单的关系ID
        /// </summary>
        public int SysRoleMenuID { get; set; }


        /// <summary>
        /// 功能项目ID
        /// </summary>
        public int OperationID { get; set; }

        public SysRoleMenu RoleMenu { get; set; }

        public SysOperation Operation { get; set; }

    }
}
