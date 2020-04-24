using Riven.Modular;
using System;
using System.Collections.Generic;
using System.Text;
using Riven.Extensions;
using Riven.Uow;
using Riven;
using Microsoft.Extensions.DependencyInjection;
using WindowsFormsApp.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace WindowsFormsApp
{
    [DependsOn(

        )]
    public class MainAppModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {

            #region 添加默认的数据库连接字符串

            context.Services.AddDefaultConnectionString(
                    context.Configuration["ConnectionStrings:Default"]
                );

            #endregion


            #region 添加 efcore 工作单元和仓储实现

            context.Services.AddUnitOfWorkWithEntityFrameworkCore();
            context.Services.AddUnitOfWorkWithEntityFrameworkCoreRepository();

            #endregion



            #region 添加默认DbContext

            context.Services.AddUnitOfWorkWithEntityFrameworkCoreDefaultDbContext<AppDbContext>((config) =>
            {
                // 这个在每次需要创建DbContext的时候执行
                if (config.ExistingConnection != null)
                {
                    // 已存在的连接
                    config.DbContextOptions.Configure(config.ExistingConnection);
                }
                else
                {
                    // 使用连接字符串
                    config.DbContextOptions.Configure(config.ConnectionString);
                }
            });

            #endregion
        }

        public override void OnPostConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<FormMain>();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
