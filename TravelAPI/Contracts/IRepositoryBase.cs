using System.Linq.Expressions;

namespace TravelAPI.Contracts
{
	public interface IRepositoryBase<TEntity> where TEntity : class // ovaj genericki parametar
		// mora biti klasa
	{

		Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default); // da li treba prekinuti ashinrhonu operaciju
		Task<TEntity> UpdateAsync(int Id, TEntity entity, CancellationToken cancellationToken = default);
		Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
		Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> condition,
			CancellationToken cancellationToken = default);
		Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

		Task SaveAsync( CancellationToken cancellationToken = default);
	}
}
