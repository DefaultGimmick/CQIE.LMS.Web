using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 系统功能所具有的操作项
    /// </summary>
    [Table("TB_SysMenuOperation")]
    public class SysMenuOperation
    {
        public int Id { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuID { get; set; }


        /// <summary>
        /// 操作编号
        /// </summary>
        public int OperationID { get; set; }

        public SystemMenu Menu { get; set; }

        public SysOperation Operation { get; set; }

    }
}
