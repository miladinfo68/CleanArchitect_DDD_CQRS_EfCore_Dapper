using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper
{
    public class DapperBaseRepositoryOnlyRead : DapperCustomReadRepository, IDisposable
    {
        //contex not used in read stage
        private readonly IDbConnection _cnn;
        public DapperBaseRepositoryOnlyRead(IConfiguration configuration)
        {
            _cnn ??= new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _cnn.QueryAsync<T>(sql, param, transaction);
            return result.ToList();
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result = await _cnn.QuerySingleAsync<T>(sql, param, transaction);
            return result;
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var result= await _cnn.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
            return result;
        }

        public void Dispose()
        {
            _cnn.Dispose();
        }
    }
}