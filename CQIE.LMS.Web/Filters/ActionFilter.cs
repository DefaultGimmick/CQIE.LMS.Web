using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CQIE.LMS.Models.Enums;

namespace CQIE.LMS.Web.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 默认的操作级别
        /// </summary>
        public int Operation { get; set; } = OperationEnum.VIEW;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 屏蔽不合法的参数
            if (this.Operation <= 0)
            {
                this.Operation = OperationEnum.VIEW;
            }

            //检查是否已登录
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var session = context.HttpContext.RequestServices.GetService(typeof(CQIE.LMS.Web.Models.SessionService)) as CQIE.LMS.Web.Models.SessionService;
                var roleIds = session.GetRoleIds(); //获取当前用户的角色信息
                if (roleIds == null)
                {
                    NotRightAccess(context);
                }
                else
                {
                    var userRoleService = context.HttpContext.RequestServices.GetService(typeof(CQIE.LMS.Services.IUserRoleServices)) as CQIE.LMS.Services.IUserRoleServices;
                    var roleMenus = userRoleService.GetRoleMenus(roleIds); //查询当前用户的角色所包含的功能菜单
                    if (roleMenus != null)
                    {
                        var actionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
                        var queryPath = $"/{actionDescriptor.ControllerName}/{actionDescriptor.ActionName}";


                        // 查询是否有权限
                        var menus = roleMenus.Where(c => c.Menu.Url.Contains(queryPath) &&
                                                         c.SysRoleMenuOperations.Where(p => p.OperationID == Operation).Count() > 0);
                        if (menus.Count() > 0) // 判断是否有权限
                        {
                            base.OnActionExecuting(context);
                        }
                        else
                        {
                            NotRightAccess(context);
                        }
                    }
                    else
                    {
                        NotRightAccess(context);
                    }
                }
            }
            else
            {
                NotRightAccess(context);
            }
        }

        /// <summary>
        /// 无权限访问
        /// </summary>
        /// <param name="context"></param>
        private void NotRightAccess(ActionExecutingContext context)
        {
            // 实现过滤器短路，在管道中不再继续处理
            context.Result = new RedirectResult("~/Account/AccessDenied");
        }

    }

}
