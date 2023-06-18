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
    public class AdminController : Controller
    {
        private static System.Text.StringBuilder m_Resp = new System.Text.StringBuilder();
        private Microsoft.AspNetCore.Identity.UserManager<CQIE.LMS.Models.Identity.SysUser> m_UserManager;

        public AdminController(Microsoft.AspNetCore.Identity.UserManager<CQIE.LMS.Models.Identity.SysUser> userManager)
        {
            m_UserManager = userManager;
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbManager"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateDB([FromServices]CQIE.LMS.DBManager.IDbManager dbManager)
        {
            m_Resp.AppendLine("开始创建数据库......");

            dbManager.Ctx.Database.EnsureDeleted();
            dbManager.Ctx.Database.EnsureCreated();
                m_Resp.AppendLine("................................数据库创建成功.");

            await InitData(dbManager);

            return Content(m_Resp.ToString());
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dbManager"></param>
        private async Task InitData(CQIE.LMS.DBManager.IDbManager dbManager)
        {
            #region 初始化系统账户
            m_Resp.AppendLine("开始初始化系统账户.......");
            var administrator = new CQIE.LMS.Models.Identity.SysUser()
            {
                UserName = "Administrator",
                Email = "admin@lms.com",
                PhoneNumber = "13800138000",
            };
            var result = await m_UserManager.CreateAsync(administrator, "123456");

            if (result.Succeeded)
            {
                m_Resp.AppendLine("................................初始化系统账户完成.");
            }
            else
            {
                m_Resp.AppendLine("................................初始化系统账户失败");
                foreach (var e in result.Errors)
                {
                    m_Resp.AppendLine(e.Description);
                }
            }
            #endregion

            #region 初始化普通账户
            m_Resp.AppendLine("开始初始化普通账户.......");
            var normalUser = new CQIE.LMS.Models.Identity.SysUser()
            {
                UserName = "Normal",
                Email = "normal@lms.com",
                PhoneNumber = "13800138002",
            };
            var result2 = await m_UserManager.CreateAsync(normalUser, "123456");

            if (result2.Succeeded)
            {
                m_Resp.AppendLine("................................初始化普通账户完成.");
            }
            else
            {
                m_Resp.AppendLine("................................初始化普通账户失败");
                foreach (var e in result.Errors)
                {
                    m_Resp.AppendLine(e.Description);
                }
            }
            #endregion

            #region 初始化角色
            var adminRole = new CQIE.LMS.Models.Identity.SysRole()
            {
                Name = "系统管理员",
                NormalizedName = "系统管理员"
            };

            var viewerRole = new CQIE.LMS.Models.Identity.SysRole()
            {
                Name = "只能查看权限",
                NormalizedName = "只能查看权限"
            };

            dbManager.Ctx.Roles.AddRange(adminRole, viewerRole);
            dbManager.Ctx.SaveChanges();
            #endregion

            #region 角色与用户的关系
            m_Resp.AppendLine("开始初始化账户与角色关系.......");
            administrator = dbManager.Ctx.Users.Where(c => c.UserName == "Administrator").FirstOrDefault();
            normalUser = dbManager.Ctx.Users.Where(c => c.UserName == "Normal").FirstOrDefault();

            dbManager.Ctx.Set<CQIE.LMS.Models.Identity.SysUserRole>().Add(new CQIE.LMS.Models.Identity.SysUserRole()
            {
                User = administrator,
                Role = adminRole
            });

            dbManager.Ctx.Set<CQIE.LMS.Models.Identity.SysUserRole>().Add(new CQIE.LMS.Models.Identity.SysUserRole()
            {
                User = normalUser,
                Role = viewerRole
            });
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化账户与角色关系完成.");
            #endregion

            #region 操作项目
            m_Resp.AppendLine("开始初始化操作项目.......");
            var view = new CQIE.LMS.Models.SysOperation()
            {
                Id = 1,
                Code = "VIEW",
                Name = "查看",
            };

            var add = new CQIE.LMS.Models.SysOperation()
            {
                Id = 2,
                Code = "ADD",
                Name= "新增",
            };

            var edit = new CQIE.LMS.Models.SysOperation()
            {
                Id = 3,
                Code = "EDIT",
                Name = "修改",
            };

            var delete = new CQIE.LMS.Models.SysOperation()
            {
                Id = 4,
                Code = "DELETE",
                Name = "删除",
            };
            dbManager.Ctx.SysOperations.AddRange(view, add, edit, delete);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化操作项目完成.");
            #endregion

            #region 主菜单
            m_Resp.AppendLine("开始初始化菜单.......");
            var system = new CQIE.LMS.Models.SystemMenu()
            {
                Name = "系统管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = null,
            };
            system.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation() { 
                Operation = view
            });

            dbManager.Ctx.SystemMenus.Add(system);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化主功能菜单完成.");
            #endregion

            #region 子功能菜单
            //用户管理
            var userManager = new CQIE.LMS.Models.SystemMenu()
            {
                Name = "人员管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Systems/UsersList",
            };
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = view
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = add
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = edit
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = delete
            });


            //角色管理
            var roleManager = new CQIE.LMS.Models.SystemMenu()
            {
                Name = "角色管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Systems/RolesList",
            };
            roleManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = view
            });
            roleManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = add
            });
            roleManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = edit
            });
            roleManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //菜单管理
            var menuManager = new CQIE.LMS.Models.SystemMenu()
            {
                Name = "菜单管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Systems/MenusList",
            };
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = view
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = add
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = edit
            });
            userManager.SysMenuOperations.Add(new CQIE.LMS.Models.SysMenuOperation()
            {
                Operation = delete
            });

            system.SubMenus.Add(userManager);
            system.SubMenus.Add(roleManager);
            system.SubMenus.Add(menuManager);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化子功能菜单完成.");
            #endregion

            #region 功能菜单与角色的关系
            m_Resp.AppendLine("开始初始化功能菜单与角色的关系.......");

            #region 初始化 adminRole 角色的功能菜单
            // 系统管理
            var adminRoleMenu1 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = system
            };
            adminRoleMenu1.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation() { 
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu1);



            ///用户管理 --------------------
            var adminRoleMenu2 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = userManager
            };
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = add
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = edit
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = delete
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu2);

            ///角色管理 ------------------------------
            var adminRoleMenu3 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = roleManager
            };
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = add
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = edit
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = delete
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu3);


            ///菜单管理 ------------------------------
            var adminRoleMenu4 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = menuManager
            };
            adminRoleMenu4.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            adminRoleMenu4.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = add
            });
            adminRoleMenu4.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = edit
            });
            adminRoleMenu4.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = delete
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu4);
            #endregion


            #region 初始化 viewerRole 角色的功能菜单
            // 系统管理
            var viewerRoleMenu1 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = viewerRole,
                Menu = system
            };
            viewerRoleMenu1.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(viewerRoleMenu1);


            ///用户管理 --------------------
            var viewerRoleMenu2 = new CQIE.LMS.Models.SysRoleMenu()
            {
                Role = viewerRole,
                Menu = userManager
            };
            viewerRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LMS.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(viewerRoleMenu2);
            #endregion 


            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化功能菜单与角色的关系完成");
            #endregion
        }


    }
}
