using Microsoft.Extensions.DependencyInjection;
using Nexos.Entities.Interface.BusinessRules;

namespace Nexos.BusinessRules
{
    public static class StartupBusiness
    {

        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IEditorialBusiness, EditorialBusiness>();
            services.AddTransient<IAutorBusiness, AuthorBusiness>();

        }
    }
}
