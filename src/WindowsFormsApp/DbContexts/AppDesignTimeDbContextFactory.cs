using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp.DbContexts
{
    public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = IocManager.Configuration["ConnectionStrings:Default"];

            Console.WriteLine($"当前使用连接字符串  {connectionString}");
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseSqlServer(connectionString, (options) =>
            {

            });

            return new AppDbContext(builder.Options);
        }
    }
}
