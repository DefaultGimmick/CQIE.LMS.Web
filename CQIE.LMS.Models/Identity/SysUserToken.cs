using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    [Table("TB_SysUserToken")]
    public class SysUserToken : Microsoft.AspNetCore.Identity.IdentityUserToken<int>
    {
        public int Id { get; set; }

    }
}
