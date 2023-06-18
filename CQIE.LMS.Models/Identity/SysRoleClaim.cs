using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    [Table("TB_SysRoleClaim")]
    public class SysRoleClaim : Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>
    {
    }
}
