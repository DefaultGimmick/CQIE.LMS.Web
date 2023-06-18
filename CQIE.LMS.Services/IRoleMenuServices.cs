using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 角色菜单服务
    /// </summary>
    public interface IRoleMenuServices
    {
        ///<summary>
        ///获取角色菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        List<int> GetRoleMenu(int menuId);

        ///<summary>
        /// 获取角色具有的菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        List<CQIE.LMS.Models.SystemMenu> GetRoleMenuList(int roleId);


        ///<summary>
        ///保存角色-菜单关系
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        bool SaveRoleMenu(CQIE.LMS.Models.SysRoleMenu roleMenu);
    }
}
