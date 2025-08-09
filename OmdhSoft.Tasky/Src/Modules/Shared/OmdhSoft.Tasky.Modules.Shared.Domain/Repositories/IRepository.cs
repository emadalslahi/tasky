using OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Repositories;

public interface IRepository<TEntity,Tkey> : IAuditable<Tkey>
{
   
        Task<TEntity?> GetAsync(Tkey id, CancellationToken cancellationToken = default);
        void Insert(TEntity entity);
        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        void Delete(Tkey id);
        Task DeleteAsync(Tkey id, CancellationToken cancellationToken = default);
        void DeleteAll();
        Task DeleteAllAsync( CancellationToken cancellationToken = default);
        
        Task ActivateAsync(Tkey id, CancellationToken cancellationToken = default);
        Task DeactivateAsync(Tkey id, CancellationToken cancellationToken = default);
}