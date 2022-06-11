using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafisistHelperCMD.Database;
using CafisistHelperCMD.Database.Repository;
using CafisistHelperCMD.Domain.Interfaces.Infra;
using CafisistHelperCMD.Domain.Interfaces.Repository;
using CafisistHelperCMD.Domain.Interfaces.Services;
using CafisistHelperCMD.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafisistHelperCMD.CrossCutting
{
    public class ConfigureDI
    {
        public static void Config(IServiceCollection services)
        {
            services.AddDbContext<FirebirdContext>(options => options.UseFirebird(@"database=localhost:C:\Cafiwin\CafiWin\CAFIWIN.fdb;user=sysdba;password=masterkey"));

            services.AddScoped<IDuprecRepository, DuprecRepository>();
            services.AddScoped<IDuprecService, DuprecService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}