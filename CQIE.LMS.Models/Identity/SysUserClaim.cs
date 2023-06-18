using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models.Identity
{
    [Table("TB_SysUserClaim")]
    public class SysUserClaim: Microsoft.AspNetCore.Identity.IdentityUserClaim<int>
    {
    }
}
