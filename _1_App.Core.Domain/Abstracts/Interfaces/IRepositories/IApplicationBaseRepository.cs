using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.EfCore;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories
{
    public interface IApplicationBaseRepository<TEntity> :
    IEfCoreBaseRepository<TEntity>, IDapperBaseRepository
    where TEntity : class ,IEntity
    {
    }
}
