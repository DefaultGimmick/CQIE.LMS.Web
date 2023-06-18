using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQIE.LMS.Services
{
    public class RoleMenuServiceImp:IRoleMenuServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public RoleMenuServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {

            m_Manager = manager;
        }

        ///<summary>
        ///获取角色菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public List<int> GetRoleMenu(int menuId)
        {
            var query = (from o in m_Manager.Ctx.SysRoleMenus
                        where o.MenuId == menuId
                        select o.RoleId).ToList();
            return query;
        }

        ///<summary>
        /// 获取角色具有的菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public List<CQIE.LMS.Models.SystemMenu> GetRoleMenuList(int roleId)
        {
            var query = (from o in m_Manager.Ctx.SysRoleMenus
                        join j in m_Manager.Ctx.SystemMenus on o.MenuId equals j.Id
                        where o.RoleId == roleId
                        select j).ToList();
            return query;
        }

        ///<summary>
        ///保存角色-菜单关系
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        public bool SaveRoleMenu(CQIE.LMS.Models.SysRoleMenu roleMenu)
        {
            var exisRoleMenu = (from o in m_Manager.Ctx.SysRoleMenus
                                where o.MenuId == roleMenu.MenuId && o.RoleId == roleMenu.RoleId

                                select o
                         ).FirstOrDefault();

            if( exisRoleMenu == null )
            {
                m_Manager.Ctx.SysRoleMenus.Add(roleMenu);
                m_Manager.Ctx.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
