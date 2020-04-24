using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp.Entitys.Samples;

namespace WindowsFormsApp.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SampleEntity> Samples { get; set; }
    }
}
