using Core.ProfilesMapping;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DepartmentMapping));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
