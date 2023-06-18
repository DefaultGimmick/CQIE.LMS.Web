using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Services
{
    public class UserServiceImp:IUserServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<CQIE.LMS.Models.Identity.SysUser> m_UserManager;

        public UserServiceImp(CQIE.LMS.DBManager.IDbManager manager, UserManager<Models.Identity.SysUser> userManager)
        {
            m_Manager = manager;
            m_UserManager = userManager;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns>用户列表</returns>
        public IQueryable<CQIE.LMS.Models.Identity.SysUser> GetUsers()
        {
            var query = from o in m_Manager.Ctx.Users select o;
            return query;
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CQIE.LMS.Models.Identity.SysUser GetUserById(int id)
        {
            var query = (from o in m_Manager.Ctx.Users where o.Id == id select o).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过Name获取用户
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.Identity.SysUser> GetUserByName(string Name)
        {
            var query = from o in m_Manager.Ctx.Users where o.UserName.Contains(Name) select o;
            return query;
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> SaveUser(CQIE.LMS.Models.Identity.SysUser user)
        {
            var item = (from o in m_Manager.Ctx.Users where o.Id == user.Id select o).FirstOrDefault();
            if (item == null)
           {
              await m_UserManager.CreateAsync(user, user.LoginPassword);
           }
           else
           {             
                item.PasswordHash = m_UserManager.PasswordHasher.HashPassword(user, user.LoginPassword);
                item.UserName = user.UserName;
                item.Email = user.Email;
                item.PhoneNumber = user.PhoneNumber;
                await m_UserManager.UpdateAsync(item);
           }
            return true; 
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveUser(int id)
        {
            var item = (from o in m_Manager.Ctx.Users.Include(c => c.SysUserRoles) // 删除用户时联带其角色关系表的数据一起删除
                        where o.Id == id
                        select o).FirstOrDefault();

            if (item != null)
            {
                m_Manager.Ctx.Users.Remove(item);
                m_Manager.Ctx.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ResetPwd(int id)
        {
            var item = (from o in m_Manager.Ctx.Users where o.Id == id select o).FirstOrDefault();
            if (item != null)
            {
                item.PasswordHash = m_UserManager.PasswordHasher.HashPassword(item, "123456");
                await m_UserManager.UpdateAsync(item);
                return true;
            }
            return false;
        }

    }
}
