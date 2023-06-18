using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    public class RoleServiceImp:IRoleServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public RoleServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.Identity.SysRole> GetRoles()
        {
            var query = from o in m_Manager.Ctx.Roles select o;
            return query;
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CQIE.LMS.Models.Identity.SysRole GetRoleById(int id)
        {
            var query = (from o in m_Manager.Ctx.Roles where o.Id == id select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过Name获取角色
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.Identity.SysRole> GetRoleByName(string Name)
        {
            var query = from o in m_Manager.Ctx.Roles where o.Name.Contains(Name) select o ;
            return query;
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool SaveRole(CQIE.LMS.Models.Identity.SysRole role)
        {
            var item = m_Manager.Ctx.Roles.Where(c => c.Id == role.Id).FirstOrDefault();
            if (item == null)
            {
                m_Manager.Ctx.Roles.Add(role);
            }
            else
            {
                item.Name = role.Name;
                item.NormalizedName = role.NormalizedName;
            }
            m_Manager.Ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveRole(int id)
        {
            var item = (from o in m_Manager.Ctx.Roles where o.Id == id select o).FirstOrDefault();

            if(item != null)
            {
                m_Manager.Ctx.Roles.Remove(item);
                m_Manager.Ctx.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
