using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns>用户列表</returns>
        IQueryable<CQIE.LMS.Models.Identity.SysUser> GetUsers();

        ///<summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        CQIE.LMS.Models.Identity.SysUser GetUserById(int id);

        ///<summary>
        /// 通过名称获取用户
        /// </summary>
        /// <param name="name"></param>
        IQueryable<CQIE.LMS.Models.Identity.SysUser> GetUserByName(string Name);

        ///<summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        Task<bool> SaveUser(CQIE.LMS.Models.Identity.SysUser user);

        ///<summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        bool RemoveUser(int id);

        ///<summary>
        /// 重置密码
        /// </summary>
        Task<bool> ResetPwd(int id);
    }
}
