using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 功能菜单服务实现
    /// </summary>
    public class SystemMenuServiceImp : ISystemMenuServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public SystemMenuServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        /// <summary>
        /// 获取功能菜单内容
        /// </summary>
        /// <returns>功能菜单列表</returns>
        public IQueryable<CQIE.LMS.Models.SystemMenu> GetSystemMenus()
        {
            var query = from o in m_Manager.Ctx.SystemMenus.Include(c=>c.SubMenus)
                        where o.Parent == null
                        select o;

            return query;
        }

        /// <summary>
        /// 获取功能菜单内容
        /// </summary>
        /// <returns>功能菜单列表</returns>
        public IQueryable<CQIE.LMS.Models.SystemMenu> GetMenus()
        {
            var query = from o in m_Manager.Ctx.SystemMenus
                        select o;

            return query;
        }

        /// <summary>
        /// 查询单个菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CQIE.LMS.Models.SystemMenu GetMenuById(int id)
        {
            var query = (from o in m_Manager.Ctx.SystemMenus where o.Id == id select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 根据名称查询菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.SystemMenu> GetMenuByName(string Name)
        {
            var query = from o in m_Manager.Ctx.SystemMenus where o.Name.Contains(Name) select o;
            return query;
        }

        /// <summary>
        /// 保存功能菜单
        /// </summary>
        /// <param name="menu">功能菜单对象</param>
        /// <returns>保存成功返回true,否则返回false</returns>
        public bool SaveSystemMenu(CQIE.LMS.Models.SystemMenu menu)
        {
            var item = m_Manager.Ctx.SystemMenus.Where(c => c.Id == menu.Id).FirstOrDefault();
            if (item == null)
            {
                m_Manager.Ctx.SystemMenus.Add(menu);
            }
            else
            {
                item.Name = menu.Name;
                item.Url = menu.Url;
                item.SortOrder = menu.SortOrder;
                item.ParentID = menu.ParentID;
                item.IconClassName = menu.IconClassName;
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        ///<summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        public bool RemoveMenu(int id)
        {
            var query = (from o in m_Manager.Ctx.SystemMenus where o.Id == id select o).FirstOrDefault();

            if (query != null)
            {
                m_Manager.Ctx.SystemMenus.Remove(query);
                m_Manager.Ctx.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
