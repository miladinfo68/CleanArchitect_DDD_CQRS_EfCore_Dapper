using _1_App.Core.Domain.Abstracts.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IRepositories
{
    public abstract class ApplicationBaseRepository<TEntity> :
    IApplicationBaseRepository<TEntity>, IDisposable
    where TEntity : class, IEntity
    {
        private readonly BaseDbContext _context;
        private readonly IDbConnection _cnn;
        public void Dispose()
        {
            if (_cnn.State == ConnectionState.Open)
            {
                _cnn.Close();
                _cnn.Dispose();
            }

            if (!string.IsNullOrEmpty(_context?.Database?.GetConnectionString()))
            {
                _context.Dispose();
            }
        }
        public ApplicationBaseRepository(BaseDbContext context, IConfiguration config)
        {
            _context ??= context;
            _cnn ??= new SqlConnection(config.GetConnectionString("DefaultConnection"));
            if (string.IsNullOrEmpty(_cnn?.ConnectionString)) _cnn = _context.Connection;
        }

        public async Task<TEntity> GetByIdAsync(decimal id, CancellationToken cancellationToken = default)
        {
            //var item = await _context.Set<TEntity>().FindAsync(id, cancellationToken);
            var item = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
            return item;

        }

        public async Task<List<TEntity>> GetListByAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return filter == null
                ? await _context.Set<TEntity>().ToListAsync(cancellationToken)
                : await _context.Set<TEntity>().Where(filter).ToListAsync(cancellationToken);

        }

        public async Task<bool> IsExistAsync(decimal id, CancellationToken cancellationToken = default)
        {
            var item = await _context.Set<TEntity>().FindAsync(id, cancellationToken);
            return item != null ? true : false;
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            var item = await _context.Set<TEntity>().FirstOrDefaultAsync(filter, cancellationToken);
            return item != null ? true : false;

        }

        public async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            var item = await _context.Set<TEntity>().FirstOrDefaultAsync(filter, cancellationToken);
            return item;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;

            //await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            //await context.SaveChangesAsync();
            //return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var updateEntity = _context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

            //context.Update(entity);
            //await _context.Set<TEntity>().SaveChangesAsync(cancellationToken);
            //return entity;
        }

        public async Task<bool> DeleteAsync(decimal id, CancellationToken cancellationToken = default)
        {
            var itemToDelete = await _context.Set<TEntity>().FindAsync(id, cancellationToken);
            //var itemToDelete = await _context.FindAsync(new object[] { id }, cancellationToken);
            if (itemToDelete is null) return false;
            _context.Remove(itemToDelete);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0 ? true : false;
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@  Dapper  @@@@@@@@@@@@@@@@@@@@@@@@@@
        //@@@@@@@@@@@@@@@@@@@@@@@@@@  Dapper  @@@@@@@@@@@@@@@@@@@@@@@@@@
        //@@@@@@@@@@@@@@@@@@@@@@@@@@  Dapper  @@@@@@@@@@@@@@@@@@@@@@@@@@
        public async Task<IReadOnlyList<TEntity>> QueryAsync<TEntity>(string sql, object param, IDbTransaction transaction, CancellationToken cancellationToken)
        {

            using var connection = _cnn; //_context.Connection;
            var result = await connection.QueryAsync<TEntity>(sql, param, transaction);
            return result.ToList();
        }

        public async Task<TEntity> QuerySingleAsync<TEntity>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            using var connection = _cnn; //_context.Connection;
            var result = await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction);
            return result;
        }
        public async Task<TEntity> QueryFirstOrDefaultAsync<TEntity>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            using var connection = _cnn; //_context.Connection;
            var result = await connection.QueryFirstOrDefaultAsync<TEntity>(sql, parameters, transaction);
            return result;
        }

        public async Task<TEntity> ExecuteAddCommandAsync<TEntity>(string sql, object parameters, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            using var connection = _cnn; //_context.Connection;
            var result = await connection.ExecuteReaderAsync(sql, parameters, transaction);
            return result.Parse<TEntity>().FirstOrDefault();
        }

        public async Task<TEntity> ExecuteUpdateCommandAsync<TEntity>(string sql, object parameters = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            using var connection = _cnn; //_context.Connection;
            var result = await connection.ExecuteReaderAsync(sql, parameters, transaction);
            return result.Parse<TEntity>().FirstOrDefault();
        }

        public async ValueTask<bool> ExecuteDeleteCommandAsync<TEntity>(string sql, object parameters, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            using var connection = _cnn; //_context.Connection;
            var result = (decimal)await connection.ExecuteAsync(sql, parameters, transaction);
            return result > 0 ? true : false;
        }


    }
}
