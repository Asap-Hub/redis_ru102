using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Details.api.Data;

public class Configuration:IEntityTypeConfiguration<Employee>
{
    private IEntityTypeConfiguration<Employee> _entityTypeConfigurationImplementation;
    
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        _entityTypeConfigurationImplementation.Configure(builder);
    }
}