using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    [Table("TB_SysUserLogin")]
    public class SysUserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}
