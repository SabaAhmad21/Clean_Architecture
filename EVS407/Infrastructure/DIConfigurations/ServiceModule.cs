using Infrastructure.Implementation;
using Infrastructure.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DIConfigurations
{
    public class ServiceModule
    {
        public static void Regsiter(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISetupRepository, SetupRepository>();

            
        }
    }
}
