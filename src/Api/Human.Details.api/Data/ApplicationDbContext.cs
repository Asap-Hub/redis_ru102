using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design; 

namespace Human.Details.api.Data;

    public class ApplicationDbContext:DbContext
    {
           
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
                :base (option)
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            }

            public DbSet<Employee> Employees => Set<Employee>();
            public DbSet<Sale> Sales => Set<Sale>();
            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            { 
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                base.OnModelCreating(modelBuilder);
            }
    }

    // public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    // {
    //     public ApplicationDbContext CreateDbContext(string[] args)
    //     {
    //         var configuration = new ConfigurationBuilder()
    //             .SetBasePath(Directory.GetCurrentDirectory())
    //             .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")).Build();
    //
    //         var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //
    //         builder.UseNpgsql(configuration.GetConnectionString("DbConnection"));
    //
    //         return new ApplicationDbContext(builder.Options);
    //     }
    // }

 