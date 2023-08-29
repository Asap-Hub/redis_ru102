using System.Reflection;
using Human.Details.api.DTOs;
using Mapster;

namespace Human.Details.api.Extension;

public static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<Sale, CreateSaleDto>.NewConfig();
        TypeAdapterConfig<Employee, CreateEmployeeDto>.NewConfig();
    }
}