using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

using Riven.Repositories;
using Riven.Uow;
using WindowsFormsApp.Entitys.Samples;

namespace WindowsFormsApp
{
    public partial class FormMain : Form
    {
        readonly IServiceProvider _serviceProvider;
        readonly IRepository<SampleEntity> _sampleEntityRepo;

        public FormMain(IServiceProvider serviceProvider, IRepository<SampleEntity> sampleEntityRepo)
        {
            _serviceProvider = serviceProvider;
            _sampleEntityRepo = sampleEntityRepo;


            InitializeComponent();

            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var scope = _serviceProvider.CreateScope();
            var serviceProvider = scope.ServiceProvider;


            try
            {
                var unitOfWorkManager = serviceProvider.GetService<IUnitOfWorkManager>();
                using (var uow = unitOfWorkManager.Begin())
                {
                    var result = _sampleEntityRepo.GetAll().ToList();


                    uow.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                scope?.Dispose();
            }

        }
    }
}
