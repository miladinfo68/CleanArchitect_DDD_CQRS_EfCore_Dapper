using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _1_App.Core.Domain.Abstracts.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper
{
    public class DapperBaseRepository<TContext> : IDapperBaseRepository where TContext : DbContext
    {
        //share connection between efcore and dapper write stage
        private readonly BaseDbContext _context;
        public DapperBaseRepository(BaseDbContext context)
        {
            _context = context;
        }

        //=========== READ
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _context.Connection.QueryAsync<T>(sql, param, transaction);
            return result.ToList();
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _context.Connection.QuerySingleAsync<T>(sql, param, transaction);
            return result;
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
            return result;
        }


        //=========== WRITE
        public async Task<T> ExecuteAddCommandAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _context.Connection.ExecuteReaderAsync(sql, parameters, transaction);
            return result.Parse<T>().FirstOrDefault();
        }

        public async Task<T> ExecuteUpdateCommandAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _context.Connection.ExecuteReaderAsync(sql, parameters, transaction);
            return result.Parse<T>().FirstOrDefault();
        }

        public async ValueTask<bool> ExecuteDeleteCommandAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = (decimal)await _context.Connection.ExecuteScalarAsync(sql, parameters, transaction);
            return result > 0 ? true : false;
        }
    }
}