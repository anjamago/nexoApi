using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexos.Entities.Interface.Repository;
using Nexos.Repositories.Base;
using Nexos.Repositories.Context;
using Nexos.Utilities;
using System;

namespace Nexos.Repositories
{
    public static class StartupRepositories
    {

        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration, bool isDev)
        {
            services.AddDbContext<APINEXOSContext>(options =>
            {
                options.UseSqlServer(HelperConnection.GetConnectionSQL(configuration, isDev), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
                    sqlOptions.CommandTimeout(60);
                });
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        }
    }
}
