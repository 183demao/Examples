using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

using Riven;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 添加应用模块
            IocManager.Services.AddRivenModule<MainAppModule>(IocManager.Configuration);

            // 构建注入容器
            IocManager.Build();

            // 进入应用模块初始化周期
            IocManager.Instance.UseRivenModule();


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(
                IocManager.Instance.GetService<FormMain>()
                );
        }
    }
}
