using CQIE.LMS.Models.Identity;
using CQIE.LMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LMS.Web.Controllers
{
    [Authorize]
    public class SystemsController : Controller
    {
        private CQIE.LMS.Services.IRoleServices m_RoleServices;
        private CQIE.LMS.Services.IUserServices m_UserServices;
        private CQIE.LMS.Services.ISystemMenuServices m_SysMenuServices;
        private CQIE.LMS.Services.ISysOperationServices m_SysOperationServices;
        private CQIE.LMS.Services.IRoleMenuServices m_RoleMenuServices;
        private CQIE.LMS.Services.IUserRoleServices m_UserRoleServices;

        public SystemsController(
            CQIE.LMS.Services.IRoleServices roleService, 
            CQIE.LMS.Services.IUserServices userService, 
            Services.ISystemMenuServices menuService,
            CQIE.LMS.Services.ISysOperationServices 
            sysOperation, CQIE.LMS.Services.IRoleMenuServices roleMenu, 
            CQIE.LMS.Services.IUserRoleServices userRole)
        {
            m_RoleServices = roleService;
            m_UserServices = userService;
            m_SysMenuServices = menuService;
            m_SysOperationServices = sysOperation;
            m_RoleMenuServices = roleMenu;
            m_UserRoleServices = userRole;
        }
        #region 用户管理
        /// <summary>
        /// 用户展示
        /// </summary>
        /// <returns></returns>
        [CQIE.LMS.Web.Filters.ActionFilter]
        public IActionResult UsersList()
        {
            var users = m_UserServices.GetUsers();
            return( View(users));
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IActionResult EditUser(int? id = null)
        {
            CQIE.LMS.Models.Identity.SysUser user = null;
            if (id.HasValue)
            {
                user = m_UserServices.GetUserById(id.Value);
            }

            return View(user);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveUser([FromForm] CQIE.LMS.Models.Identity.SysUser user)
        {
            if (this.ModelState.IsValid)
            {
                user.NormalizedUserName = (user.UserName == null ? "" : user.UserName.ToUpper());
                user.NormalizedEmail = (user.Email == null ? "" : user.Email.ToUpper());

                if (await m_UserServices.SaveUser(user))
                {
                    return Redirect("/Systems/UsersList");
                }
                else
                {
                    return View("EditUser", user);
                }
            }

            return View("EditUser");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IActionResult RemoveUser(int id)
        {

            if (m_UserServices.RemoveUser(id))
            {
                //删除成功
                return Redirect("/Systems/UsersList");
            }
            else
            {
                return Content("删除用户出错，转向到错误信息");
            }
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <returns></returns>
        public IActionResult SelectUser(string name)
        {
            var users = m_UserServices.GetUserByName(name);
            return View("UsersList", users);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="name">用户id</param>
        /// <returns></returns>
        public async Task<IActionResult> ResetUserPwd(int id)
        {
            if (await m_UserServices.ResetPwd(id))
            {
                //重置成功
                return Redirect("/Systems/UsersList");
            }
            else
            {
                return Content("重置密码出错，转向到错误信息");
            }

        }
        #endregion

        #region 角色管理
        /// <summary>
        /// 角色展示
        /// </summary>
        /// <returns></returns>
        [CQIE.LMS.Web.Filters.ActionFilter(Operation = CQIE.LMS.Models.Enums.OperationEnum.ADD)]
        public IActionResult RolesList()
        {
            var roles = m_RoleServices.GetRoles();

            return View(roles);
        }

        /// <summary>
        /// 编辑角色信息
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        public IActionResult EditRole(int? id = null)
        {
            CQIE.LMS.Models.Identity.SysRole role = null;
            if (id.HasValue)
            {
                role = m_RoleServices.GetRoleById(id.Value);
            }

            return View(role);
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveRole([FromForm] CQIE.LMS.Models.Identity.SysRole role)
        {
            if (this.ModelState.IsValid)
            {
                if (m_RoleServices.SaveRole(role))
                {
                    return Redirect("/Systems/RolesList");
                }
                else
                {
                    return View("EditRole", role);
                }
            }

            return View("EditRole");
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        public IActionResult RemoveRole(int id)
        {

            if (m_RoleServices.RemoveRole(id))
            {
                
                return Redirect("/Systems/RolesList");
            }
            else
            {
                return Content("删除角色出错，转向到错误信息");
            }
        }

        /// <summary>
        /// 查找角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <returns></returns>
        public IActionResult SelectRole(string  name)
        {
            var role = m_RoleServices.GetRoleByName(name);
            return View("RolesList", role);
        }
        #endregion

        #region 菜单管理
        /// <summary>
        /// 菜单展示
        /// </summary>
        /// <returns></returns>
        public IActionResult MenusList()
        {
            var menus = m_SysMenuServices.GetMenus();
            return (View("MenusList", menus));
        }

        /// <summary>
        /// 编辑菜单信息
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <returns></returns>
        public IActionResult EditMenu(int? id = null)
        {
            CQIE.LMS.Models.SystemMenu menu = null;
            if (id.HasValue)
            {
                menu = m_SysMenuServices.GetMenuById(id.Value);
            }

            return View(menu);
        }

        /// <summary>
        /// 保存菜单信息
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <returns></returns>
        public IActionResult SaveMenu([FromForm] CQIE.LMS.Models.SystemMenu menu)
        {
            if (this.ModelState.IsValid)
            {
                if (m_SysMenuServices.SaveSystemMenu(menu))
                {
                    return Redirect("/Systems/MenusList");
                }
                else
                {
                    return View("EditMenu", menu);
                }
            }

            return View("EditMenu");
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <returns></returns>
        public IActionResult RemoveMenu(int id)
        {

            if (m_SysMenuServices.RemoveMenu(id))
            {

                return Redirect("/Systems/MenusList");
            }
            else
            {
                return Content("删除菜单出错，转向到错误信息");
            }
        }

        /// <summary>
        /// 查找菜单
        /// </summary>
        /// <param name="name">菜单名称</param>
        /// <returns></returns>
        public IActionResult SelectMenu(string name)
        {
            var menu = m_SysMenuServices.GetMenuByName(name);
            return View("MenusList", menu);
        }

        #endregion

        #region 分配菜单
        /// <summary>
        /// 显示菜单添加角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IActionResult ConfigRoleMenu(int id)
        {
            var role = m_RoleServices.GetRoleById(id);
            return View(role);
        }

        /// <summary>
        /// 操作列表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetOperation()
        {
            var operation = m_SysOperationServices.GetSysOperations();
            return View(operation);
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <param name="optionId"></param>
        /// <returns></returns>
        public IActionResult SaveRoleMenuOption(int roleId, int menuId, int optionId)
        {
            var roleMenu = new CQIE.LMS.Models.SysRoleMenu()
            {
                RoleId = roleId,
                MenuId = menuId,
            };

            roleMenu.SysRoleMenuOperations.Add(new LMS.Models.SysRoleMenuOperation()
            {
                OperationID = optionId,
            });
            if(m_RoleMenuServices.SaveRoleMenu(roleMenu))
            {
                return Redirect("~/Systems/RolesList");
            }
            return RedirectToAction("~/Systems/EditMenu", roleId);
        }
        #endregion

        #region 分配角色
        /// <summary>
        /// 显示分配角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ConfigUserRole(int id)
        {
            var user = m_UserServices.GetUserById(id);
            return View(user);
        }
        /// <summary>
        /// 保存角色-菜单-操作关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IActionResult SaveUserRole(int userId, int roleId)
        {
            var userRole = new SysUserRole
            {
                UserId = userId,
                RoleId = roleId
            };
            if(m_UserRoleServices.SaveUserRoles(userRole))
            {
                return Redirect("~/Systems/UsersList");
            }
            return RedirectToAction("~/Systems/ConfigUserRole", userId);
        }

        #endregion
    }
}
