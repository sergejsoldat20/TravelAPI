using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Contracts;
using TravelAPI.Data;
using TravelAPI.Repository;

namespace TravelAPI.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection RegisterDb(this IServiceCollection services,
			IConfiguration configuration) 
		{
			services.AddDbContext<TravelPlannerDbContext>(opt =>
			opt.UseNpgsql(configuration.GetConnectionString("Db")));

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IDestinationRepository, DestinationRepository>();
			return services;
		}
	}
}
