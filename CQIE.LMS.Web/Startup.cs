using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CQIE.LMS.Services;

namespace CQIE.LMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddDbContext<CQIE.LMS.DBManager.DbContexts.LMSDbContext>(options => 
                                                                              options.UseSqlServer(Configuration.GetConnectionString("LMSDB")));

            services.AddDefaultIdentity<CQIE.LMS.Models.Identity.SysUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<CQIE.LMS.DBManager.DbContexts.LMSDbContext>();

            #region ע��ORM�����
            services.AddSingleton(typeof(CQIE.LMS.Utility.ConfigService));
            services.AddScoped(typeof(CQIE.LMS.DBManager.DbContexts.LMSDbContext));
            services.AddScoped<CQIE.LMS.DBManager.IDbManager, CQIE.LMS.DBManager.DbManagerImp>();
            #endregion

            // ע��ҵ���ܲ˵�����
            services.AddScoped<CQIE.LMS.Services.ISystemMenuServices, CQIE.LMS.Services.SystemMenuServiceImp>();

            // ע���û���ɫ����
            services.AddScoped<CQIE.LMS.Services.IUserRoleServices, CQIE.LMS.Services.UserRoleServiceImp>();
            services.AddScoped<CQIE.LMS.Services.IUserServices, CQIE.LMS.Services.UserServiceImp>();
            services.AddScoped<CQIE.LMS.Services.IRoleServices, CQIE.LMS.Services.RoleServiceImp>();
            
            services.AddScoped<CQIE.LMS.Services.IRoleMenuServices, CQIE.LMS.Services.RoleMenuServiceImp>();
            services.AddScoped<CQIE.LMS.Services.ISysOperationServices,CQIE.LMS.Services.SysOperationServiceImp>();

            services.AddScoped<CQIE.LMS.Services.ICargoConsignmentOrderServices, CQIE.LMS.Services.CargoConsignmentOrderServiceImp>();
            services.AddScoped<CQIE.LMS.Services.IFreightDispatchOrderServices, CQIE.LMS.Services.FreightDispatchOrderServiceImp>();
            services.AddScoped<CQIE.LMS.Services.IExpenseReimbursementOrderServices,CQIE.LMS.Services.ExpenseReimbursementOrderServiceImp>();
            services.AddScoped<CQIE.LMS.Services.IFinancialStatementServices, CQIE.LMS.Services.FinancialStatementServiceImp>();
            // ��� Session����
            //�����ڴ滺��
            services.AddDistributedMemoryCache();

            #region �������ݿ⻺��
            //�������ݿ⻺��
            //Ҫ���������а�װ��
            // 1. dotnet tool install --global dotnet-sql-cache
            // 2. dotnet sql-cache create "���ݿ������ַ���" dbo TB_SessionCache
            // 3. ���ð���Microsoft.Extensions.Caching.SqlServer
            /*
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("LMSDB");
                options.SchemaName = "dbo";
                options.TableName = "TB_SessionCache";
            });
            //*/
            #endregion

            services.AddSession(config =>
            {
                config.Cookie.IsEssential = true;
                config.Cookie.Name = ".CQIE.LMS.Web.session";
                config.Cookie.HttpOnly = true;
                config.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddScoped(typeof(CQIE.LMS.Web.Models.SessionService)); // ע���Զ����Session����

            #region ����Redis����
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = Configuration.GetConnectionString("Redis");
                opt.InstanceName = "SampleInstance";
            });
            #endregion


            /** ȫ�ֹ�����
            services.AddControllersWithViews(options=> {
                options.Filters.Add(typeof(CQIE.LMS.Web.Filters.GlobalLoginFilter));
            });
            //*/
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
