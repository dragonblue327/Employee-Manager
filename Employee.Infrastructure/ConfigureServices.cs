using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure
{

	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			// Add DbContext with connection string from configuration
			services.AddDbContext<AppDBContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ConStr") ??
				throw new InvalidOperationException("Connection String 'ConStr' Not Found")));


			return services;
		}
	}


}
