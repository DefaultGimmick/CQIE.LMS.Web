using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 操作服务
    /// </summary>
    public interface ISysOperationServices
    {
        ///<summary>
        /// 获取菜单操作
        /// </summary>
        /// <returns></returns>
        IQueryable<CQIE.LMS.Models.SysOperation> GetSysOperations();


        ///<summary>
        /// 查找角色id和菜单id查找操作表
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        List<CQIE.LMS.Models.SysOperation> GetOperationByUserIdAndRoleId(int roleId, int menuId);

    }
}
