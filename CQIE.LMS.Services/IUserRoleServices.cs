using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 用户角色服务
    /// </summary>
    public interface IUserRoleServices
    {
        ///<summary>
        /// 获取用户的角色
        /// </summary>
        List<int> GetRoleIds(int roleId);

        ///<summary>
        /// 获取角色的资源
        /// </summary>
        IQueryable<CQIE.LMS.Models.SysRoleMenu> GetRoleMenus(List<int> roleIds);

        /// <summary>
        /// 保存用户-角色的关系
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        bool SaveUserRoles(CQIE.LMS.Models.Identity.SysUserRole userRole);

        /// <summary>
        /// 获取用户所具有的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<CQIE.LMS.Models.Identity.SysRole> GetUserRoleList(int userId);
    }
}
