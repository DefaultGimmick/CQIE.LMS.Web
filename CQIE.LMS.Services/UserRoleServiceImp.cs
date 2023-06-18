using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQIE.LMS.Services
{
    public class UserRoleServiceImp : IUserRoleServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public UserRoleServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        ///<summary>
        /// 获取用户的角色
        /// </summary>
        public List<int> GetRoleIds(int Id)
        {
           var query = (from o in m_Manager.Ctx.UserRoles 
                       where o.UserId == Id
                       select o.RoleId).ToList();
            return query;
        }

        ///<summary>
        /// 获取角色的资源
        /// </summary>
        public IQueryable<CQIE.LMS.Models.SysRoleMenu> GetRoleMenus(List<int> roleIds)
        {
            if (roleIds != null)
            {
                var roleMenus = from o in m_Manager.Ctx.SysRoleMenus.Include(c => c.SysRoleMenuOperations).Include(c => c.Menu)
                                where roleIds.Contains(o.RoleId)
                                select o;

                return roleMenus;
            }
            return null;
        }


        /// <summary>
        /// 保存用户-角色的关系
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public bool SaveUserRoles(CQIE.LMS.Models.Identity.SysUserRole userRole)
        {
            var existUserRole = (from o in m_Manager.Ctx.UserRoles
                                 where o.UserId == userRole.UserId && o.RoleId == userRole.RoleId
                                 select o).FirstOrDefault();

            if (existUserRole == null)
            {
                m_Manager.Ctx.UserRoles.Add(userRole);
                m_Manager.Ctx.SaveChanges();
            }

            return true;
        }


        /// <summary>
        /// 获取用户所具有的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<CQIE.LMS.Models.Identity.SysRole> GetUserRoleList(int userId)
        {
            var query = from o in m_Manager.Ctx.UserRoles
                        join j in m_Manager.Ctx.Roles on o.RoleId equals j.Id
                        where o.UserId == userId
                        select j;

            return query.ToList();

        }
    }
}
