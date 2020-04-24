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
            // ���Ӧ��ģ��
            IocManager.Services.AddRivenModule<MainAppModule>(IocManager.Configuration);

            // ����ע������
            IocManager.Build();

            // ����Ӧ��ģ���ʼ������
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
