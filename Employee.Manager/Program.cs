using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Employee.Infrastructure;
using System;
using System.Windows.Forms;

namespace Employee.Manager
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			var host = CreateHostBuilder().Build();
			var serviceProvider = host.Services;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(serviceProvider.GetRequiredService<Form1>());
		}

		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureAppConfiguration((context, config) =>
				{
					config.AddJsonFile("C:\\Users\\drago\\source\\repos\\Employee.Manager.App\\Employee.Manager\\appsettings.json", optional: false, reloadOnChange: true);
				})
				.ConfigureServices((context, services) =>
				{
					services.AddInfrastructureServices(context.Configuration);
					services.AddTransient<Form1>();
				});
		}
	}
}
