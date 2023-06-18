using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LMS.Services
{
    public class SysOperationServiceImp:ISysOperationServices
    {
        private readonly CQIE.LMS.DBManager.IDbManager m_Manager;

        public SysOperationServiceImp(CQIE.LMS.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }
        /// <summary>
        /// 获取操作菜单
        /// </summary>
        /// <returns></returns>
        public IQueryable<CQIE.LMS.Models.SysOperation> GetSysOperations()
        {
            var query = from o in m_Manager.Ctx.SysOperations
                        select o;

            return query;

        }

        ///<summary>
        /// 查找角色菜单操作表
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public List<CQIE.LMS.Models.SysOperation> GetOperationByUserIdAndRoleId(int roleId, int menuId)
        {
            var exisRoleMenu = (from o in m_Manager.Ctx.SysRoleMenus
                                where o.RoleId == roleId && o.MenuId == menuId
                                select o
                    ).FirstOrDefault();

            var existSysRoleMenuOperation = (from o in m_Manager.Ctx.SysRoleMenuOperations
                                            where o.SysRoleMenuID == exisRoleMenu.Id
                                            select o).ToList();

            var query = (from o in existSysRoleMenuOperation
                        join j in m_Manager.Ctx.SysOperations on o.OperationID equals j.Id
                        select j).ToList();
            return query;
        }
    }
}
