using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voting_Library;
using VotingLibrary;

namespace Voting_App
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new frmLogin());
        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
