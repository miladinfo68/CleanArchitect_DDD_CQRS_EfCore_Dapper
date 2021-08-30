using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.EfCore
{
    public interface IEfCoreBaseRepository <TEntity > :
        IEfCoreBaseRepositoryOnlyRead<TEntity > , IEfCoreBaseRepositoryOnlyWrite<TEntity >
        where TEntity : IEntity
    {
    }

    public interface IEfCoreBaseRepositoryOnlyRead<TEntity > where TEntity :  IEntity
    {
        Task<TEntity > GetByIdAsync(decimal id, CancellationToken cancellationToken = default);
        Task<List<TEntity >> GetListByAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<TEntity > FindByAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);

        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<bool> IsExistAsync(decimal id, CancellationToken cancellationToken = default);
    }

    public interface IEfCoreBaseRepositoryOnlyWrite<TEntity > where TEntity :  IEntity
    {
        Task<TEntity > AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity > UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(decimal id, CancellationToken cancellationToken = default);
    }
}
