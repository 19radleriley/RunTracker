using System;
using Microsoft.EntityFrameworkCore;
using RunTracker.Models;

namespace RunTracker
{
    public class RunsDbContext : DbContext
    {
        public RunsDbContext() : base()
        {

        }

        public RunsDbContext(DbContextOptions<RunsDbContext> options) : base(options)
        {
            // TODO
        }

        public virtual DbSet<RunModel> Runs { get; set; }

        // TODO

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql()
        //    }
        //    else
        //    {
        //        base.OnConfiguring(optionsBuilder);
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    base.ConfigureConventions(configurationBuilder);
        //}
    }
}

