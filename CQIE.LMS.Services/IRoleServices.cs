using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleServices
    {
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns>角色列表</returns>
        IQueryable<CQIE.LMS.Models.Identity.SysRole> GetRoles();

        ///<summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="id"></param>
        CQIE.LMS.Models.Identity.SysRole GetRoleById(int id);

        ///<summary>
        /// 通过名称获取角色
        /// </summary>
        /// <param name="name"></param>
        IQueryable<CQIE.LMS.Models.Identity.SysRole> GetRoleByName(string Name);

        ///<summary>
        /// 保存角色
        /// </summary>
        /// <param name="role"></param>
        bool SaveRole(CQIE.LMS.Models.Identity.SysRole role);

        ///<summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        bool RemoveRole(int id);
    }
}
