using TravelAPI.Contracts;
using TravelAPI.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TravelAPI.Repository
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly TravelPlannerDbContext _context;

		public RepositoryBase(TravelPlannerDbContext context, CancellationToken cancellationToken = default)
		{
			this._context = context;
		}

		public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
		{
			return (await _context.Set<T>().AddAsync(entity, cancellationToken)).Entity;
		}

		public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
		{
			_context.Remove(entity);
			await Task.CompletedTask;
		}

		public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Set<T>().ToListAsync(cancellationToken);
		}

		public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> condition, 
			CancellationToken cancellationToken = default)
		{
			return await _context.Set<T>().Where(condition).FirstOrDefaultAsync(cancellationToken);
		}

		public async Task SaveAsync(CancellationToken cancellationToken = default)
		{
			await _context.SaveChangesAsync();
		}

		public async Task<T> UpdateAsync(int Id, T entity, CancellationToken cancellationToken = default)
		{
			_context.Set<T>().Update(entity);
			return await Task.FromResult(entity);
		}
	}
}
