// See https://aka.ms/new-console-template for more information
using CafisistHelperCMD.CrossCutting;
using CafisistHelperCMD.Domain.Interfaces.Repository;
using CafisistHelperCMD.Domain.Interfaces.Services;
using CafisistHelperCMD.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CafisistHelperCMD
{
    class Program
    {


        // private IDuprecService duprecService;

        static void Main(string[] args)
        {
            #region Dependency Injection
            var services = new ServiceCollection();
            ConfigureDI.Config(services);
            var serviceProvider = services.BuildServiceProvider();
            #endregion


            var duprecService = serviceProvider.GetService<IDuprecService>();
            duprecService!.AjustaDuplicatasSmartSist();
        }
    }
}

// using (var db = new FirebirdContext())
// {
//     var teste = db.Database.GetDbConnection();
//     var cnpj = teste.Query<Teste>("SELECT CLICGC FROM CADCLI WHERE CLICOD = @CLICOD", new { CLICOD = 1 }).FirstOrDefault();

//     Console.WriteLine($"{cnpj!.CLICGC}");


// }
