using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Analysis
{
    static class Program
    {
        public static ILogger<MenuForm> logger;
        public static JsonSerializer serializer;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            serializer = new JsonSerializer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var menuForm = serviceProvider.GetRequiredService<MenuForm>();
                Application.Run(menuForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MenuForm>()
                    .AddLogging(configure => configure.AddConsole());
        }
    }
}
