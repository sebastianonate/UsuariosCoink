using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UsuariosCoink.Infrastructure.Context
{
    public class DbContextBase : DbContext ,IDbContext
    {
        public DbContextBase()
        {
        }
        public DbContextBase(DbConnection connection) : base(connection, true)
        {
        }

        public Task<DbRawSqlQuery<T>> ExecuteSqlQuery<T>(string query, params object[] parameters)
        {
            return Task.FromResult(Database.SqlQuery<T>(query, parameters));
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, CommandType? commandType = null)
        {
            return Database.Connection.QueryAsync<T>(sql, param, commandType: commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", CommandType? commandType = null)
        {
            return Database.Connection.QueryAsync<TFirst, TSecond, TReturn>(sql, map, param, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id", CommandType? commandType = null)
        {
            return Database.Connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(sql, map, param, commandType: commandType, splitOn: splitOn);

        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, string splitOn = "Id", CommandType? commandType = null)
        {
            return Database.Connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(sql, map, param, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, string splitOn = "Id", CommandType? commandType = null)
        {
            return Database.Connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(sql, map, param, commandType: commandType, splitOn: splitOn);
        }
    }
}