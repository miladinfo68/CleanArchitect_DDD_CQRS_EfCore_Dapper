using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper
{
    public interface IDapperBaseRepository :
          DapperReadRepositoryByDirectDbConnection
        , DapperWriteRepositoryBySharedContextDbConnection
    {
    }


    public interface DapperReadRepositoryByDirectDbConnection
    {
        Task<IReadOnlyList<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<TEntity> QueryFirstOrDefaultAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<TEntity> QuerySingleAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }

    public interface DapperWriteRepositoryBySharedContextDbConnection
    {
        Task<TEntity> ExecuteAddCommandAsync<TEntity>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<TEntity> ExecuteUpdateCommandAsync<TEntity>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        ValueTask<bool> ExecuteDeleteCommandAsync<TEntity>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }



    public interface DapperCustomReadRepository
    {
        Task<IReadOnlyList<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<TEntity> QueryFirstOrDefaultAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<TEntity> QuerySingleAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }



}
