using System.Reflection;
using Microsoft.EntityFrameworkCore;

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
 