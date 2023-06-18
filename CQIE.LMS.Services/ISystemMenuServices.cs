using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 功能菜单服务
    /// </summary>
    public interface ISystemMenuServices
    {
        /// <summary>
        /// 获取功能菜单内容
        /// </summary>
        /// <returns>功能菜单列表</returns>
        IQueryable<CQIE.LMS.Models.SystemMenu> GetSystemMenus();

        /// <summary>
        /// 获取功能菜单内容
        /// </summary>
        /// <returns>功能菜单列表</returns>
        IQueryable<CQIE.LMS.Models.SystemMenu> GetMenus();

        ///<summary>
        /// 获取单个菜单
        /// </summary>
        /// <param name="id"></param>
        CQIE.LMS.Models.SystemMenu GetMenuById(int id);

        ///<summary>
        /// 通过名称获取菜单
        /// </summary>
        /// <param name="name"></param>
        IQueryable<CQIE.LMS.Models.SystemMenu> GetMenuByName(string Name);

        /// <summary>
        /// 保存功能菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>保存成功返回true,否则返回false</returns>
        bool SaveSystemMenu(CQIE.LMS.Models.SystemMenu menu);

        ///<summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        bool RemoveMenu(int id);
    }
}
