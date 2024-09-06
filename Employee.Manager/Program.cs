using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Employee.Infrastructure;
using System;
using System.Windows.Forms;
using Employee.Application.IServices;
using Employee.Application.Services;
using Employee.Domain.Repository;
using Employee.Infrastructure.Repository;
using Employee.Application.Interfaces;

namespace Employee.Manager
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			var host = CreateHostBuilder().Build();
			var serviceProvider = host.Services;

			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<Form1>());
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
					services.AddTransient<IEmployeeService, EmployeeService>();
					services.AddTransient<IEmployeeRepository, EmployeeRepository>();
					services.AddTransient<IDepartmentService, DepartmentService>();
					services.AddTransient<IDepartmentRepository, DepartmentRepository>();
				});
		}
	}
}
