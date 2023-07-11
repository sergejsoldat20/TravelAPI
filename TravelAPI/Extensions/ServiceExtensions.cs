using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Data;

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
	}
}
