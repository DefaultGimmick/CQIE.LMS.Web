﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CQIE.LMS.Models.Identity;
using CQIE.LMS.Models;

namespace CQIE.LMS.DBManager.DbContexts
{
    public partial class LMSDbContext : IdentityDbContext<SysUser, SysRole, int,
                                                          SysUserClaim, SysUserRole, SysUserLogin,
                                                          SysRoleClaim, SysUserToken>
    {
        private string m_ConnectionString;
        public LMSDbContext(CQIE.LMS.Utility.ConfigService config) {
            m_ConnectionString = config.GetConnectionString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(m_ConnectionString);
            optionsBuilder.UseSqlServer(m_ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CQIE.LMS.Models.SysOperation>();
            modelBuilder.Entity<CQIE.LMS.Models.SystemMenu>(entity => {
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                //映射父子结构
                entity.HasMany(c => c.SubMenus).WithOne(c => c.Parent).HasForeignKey(c => c.ParentID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CQIE.LMS.Models.SysMenuOperation>(entity =>
            {
                entity.HasOne(c => c.Menu).WithMany(c => c.SysMenuOperations).HasForeignKey(c => c.MenuID);
                entity.HasOne(c => c.Operation).WithMany(c => c.SysMenuOperations).HasForeignKey(c => c.OperationID);
            });

            modelBuilder.Entity<CQIE.LMS.Models.SysRoleMenu>(entity =>
            {
                entity.HasOne(c => c.Role).WithMany(c => c.SysRoleMenus).HasForeignKey(c => c.RoleId);
                entity.HasOne(c => c.Menu).WithMany(c => c.SysRoleMenus).HasForeignKey(c => c.MenuId);
            });

            modelBuilder.Entity<CQIE.LMS.Models.SysRoleMenuOperation>(entity =>
            {
                entity.HasOne(c => c.RoleMenu).WithMany(c => c.SysRoleMenuOperations).HasForeignKey(c => c.SysRoleMenuID);
                entity.HasOne(c => c.Operation).WithMany(c => c.SysRoleMenuOperations).HasForeignKey(c => c.OperationID);
            });



            modelBuilder.Entity<CQIE.LMS.Models.SessionCache>(entity => {
                entity.HasKey(c=>c.nid);
                entity.Property(c => c.Id).HasMaxLength(449);
            });


            #region 托运单
            modelBuilder.Entity<CargoConsignmentOrder>(entity =>
            {
                //用户与托运单的关系一对多
                entity.HasOne(c => c.BusinessPersonnel).WithMany(c => c.BP_CargoConsignmentOrders).HasForeignKey(c => c.BP_Id);
                //托运单与调度单的关系一对一
                entity.HasOne(c => c.FreightDispatOrder).WithOne(c => c.consignmentOrder).HasForeignKey<FreightDispatchOrder>(c => c.CCO_Id).OnDelete(DeleteBehavior.Restrict); ;
            });
            #endregion

            #region 调度单
            modelBuilder.Entity<FreightDispatchOrder>(entity =>
            {
                //用户与调度单的关系一对多
                entity.HasOne(c => c.DispatchPersonnel).WithMany(c => c.BP_FreightDispatchOrders).HasForeignKey(c => c.FD_Id);
                //托运单与调度单的关系一对一
                entity.HasOne(c => c.ExpenseReimbursementOrder).WithOne(c => c.FreightDispatOrder).HasForeignKey<ExpenseReimbursementOrder>(c => c.FD_Id).OnDelete(DeleteBehavior.Restrict); ;
            });
            #endregion

            #region 报销单
            modelBuilder.Entity<ExpenseReimbursementOrder>(entity =>
            {
                //财务人员与报销单一对多关系
                entity.HasOne(c => c.FinanceStaffAndDriver).WithMany(c => c.BP_ExpenseReimbursementOrders).HasForeignKey(c => c.FAD_Id).OnDelete(DeleteBehavior.Restrict); ;
            });
            #endregion

            #region 货物
            modelBuilder.Entity<Freight>(entity =>
            {
                //托运单与货物的一对多
                entity.HasOne(c => c.Order).WithMany(c => c.Freights).HasForeignKey(c => c.Order_Id);
            });
            #endregion
            this.IdentityModelCreating(modelBuilder);
        }

        private void IdentityModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUser>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique(); 
                //SQL Server下正常，MySQL下报错，如果使用索引，MYSQL下字段长度最大可设置为191
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(128);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(128);
                b.Ignore(u => u.LockoutEnd);
                b.Ignore(c => c.LoginPassword);

                b.HasMany<SysUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<SysUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<SysUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            modelBuilder.Entity<SysRole>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(128);

                b.HasMany<SysRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });


            modelBuilder.Entity<SysUserClaim>(b =>
            {
                b.HasKey(uc => uc.Id);
            });

            modelBuilder.Entity<SysUserRole>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.HasOne(c => c.Role).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.RoleId);
                b.HasOne(c => c.User).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<SysUserLogin>(b =>
            {
                b.HasKey(c => c.Id);
            });

            modelBuilder.Entity<SysUserToken>(b =>
            {
                b.HasKey(c => c.Id);
            });

            modelBuilder.Entity<SysRoleClaim>(b =>
            {
                b.HasKey(rc => rc.Id);
            });
        }
    }
}
