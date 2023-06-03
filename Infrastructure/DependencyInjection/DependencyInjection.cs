using Application.Interfaces;
using Core.ProfilesMapping;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectInfrastructureServices(this IServiceCollection Services)
        {
            Services.AddTransient<ITenantService, TenantService>();
            Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Services.AddTransient<IUnitOfWork, UnitOfWork>();
            Services.AddTransient<IProductService, ProductService>();
            return Services;
        }
    }
}
