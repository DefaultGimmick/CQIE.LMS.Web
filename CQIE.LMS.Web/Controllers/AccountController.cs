using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CQIE.LMS.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CQIE.LMS.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private Microsoft.AspNetCore.Identity.SignInManager<CQIE.LMS.Models.Identity.SysUser> m_SignInManager;
        private Microsoft.AspNetCore.Identity.UserManager<CQIE.LMS.Models.Identity.SysUser> m_UserManager;

        public AccountController(Microsoft.AspNetCore.Identity.SignInManager<CQIE.LMS.Models.Identity.SysUser> signInManager,
                                 Microsoft.AspNetCore.Identity.UserManager<CQIE.LMS.Models.Identity.SysUser> userManager)
        {
            m_SignInManager = signInManager;
            m_UserManager = userManager;
        }

        /// <summary>
        /// 登录视图
        /// </summary>
        /// <param name="dbManager"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm]CQIE.LMS.Models.Identity.SysUser loginUser, [FromServices] CQIE.LMS.Services.IUserRoleServices userRoleService)
        {
            var result = await this.m_SignInManager.PasswordSignInAsync(loginUser.UserName, loginUser.LoginPassword, false, true);
            if (result.Succeeded)
            {
                var user = await m_UserManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    // 设置 session
                    var userJson = System.Text.Json.JsonSerializer.Serialize(user);
                    this.HttpContext.Session.Set("SessionUser", System.Text.Encoding.UTF8.GetBytes(userJson));

                    var roleIds = userRoleService.GetRoleIds(user.Id);
                    this.HttpContext.Session.Set("UserRoleIds", System.Text.Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(roleIds)));
                }

                return Redirect("~/Home/Index");
            }
            else if (result.IsLockedOut)
            {
                ViewBag.Msg = "用户被锁定";
            }
            else if (result.IsNotAllowed)
            {
                ViewBag.Msg = "用户未验证，不能登录";
            }
            else
            {
                ViewBag.Msg = "错误的用户名或密码";
            }

            return View(loginUser);
        }

        /// <summary>
        /// 退出登录状态
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public async Task<IActionResult> Logout([FromServices] CQIE.LMS.Web.Models.SessionService session)
        {
            session.Clear();

            await m_SignInManager.SignOutAsync();

            return Redirect("~/Account/Login");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
