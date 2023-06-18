using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    [Table("TB_SysUserRole")]
    public class SysUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public int Id { get; set; }

        public SysRole Role { get; set; }

        public SysUser User { get; set; }
    }
}
