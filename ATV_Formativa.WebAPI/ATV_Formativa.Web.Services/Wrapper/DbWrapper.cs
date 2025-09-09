using ATV_Formativa.WebAPI.Utils;
using ATV_Formativa.WebAPI.Wrapper.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Connections;
using System.Data;
using static ATV_Formativa.WebAPI.Wrapper.DbWrapper;

namespace ATV_Formativa.WebAPI.Wrapper
{
    public class DbWrapper : IDbWrapper
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed = false;

        public DbWrapper(IDbConnectionFactory dbConnectionFactory, Common.DataBase database)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _connection = _dbConnectionFactory.CreateConnection(database);
        }
        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Já existe uma transação ativa.");
            }
            _transaction = _connection.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Nenhuma transação ativa para commit.");
            }
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Nenhuma transação ativa para rollback.");
            }
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _connection.ExecuteAsync(sql, param, _transaction, commandTimeout, commandType);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _connection.QueryAsync<T>(sql, param, _transaction, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _connection.QueryFirstAsync<T>(sql, param, _transaction, commandTimeout, commandType);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction, commandTimeout, commandType);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _connection.QueryMultipleAsync(sql, param, _transaction, commandTimeout, commandType);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction?.Dispose();
                _transaction = null;

                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection?.Dispose();
                _connection = null;

                _disposed = true;
            }
        }
    }
}
