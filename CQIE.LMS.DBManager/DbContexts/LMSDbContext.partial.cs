using Microsoft.EntityFrameworkCore;
using System;

namespace CQIE.LMS.DBManager.DbContexts
{
    public partial class LMSDbContext
    {
        public DbSet<CQIE.LMS.Models.SystemMenu> SystemMenus { get; set; }

        public DbSet<CQIE.LMS.Models.SysOperation> SysOperations { get; set; }
        public DbSet<CQIE.LMS.Models.SysMenuOperation> SysMenuOperations { get; set; }
        public DbSet<CQIE.LMS.Models.SysRoleMenu> SysRoleMenus { get; set; }


        public DbSet<CQIE.LMS.Models.Identity.SysUserRole> SysUserRoles { get; set; }
        public DbSet<CQIE.LMS.Models.Freight> Freights { get; set; }
        public DbSet<CQIE.LMS.Models.SysRoleMenuOperation> SysRoleMenuOperations { get; set; }
        public DbSet<CQIE.LMS.Models.CargoConsignmentOrder> CargoConsignmentsOrders { get; set; }
        public DbSet<CQIE.LMS.Models.FreightDispatchOrder> FreightDispatchOrders { get; set; }
        public DbSet<CQIE.LMS.Models.ExpenseReimbursementOrder> ExpenseReimbursementOrders { get; set; }
        
    }
}
