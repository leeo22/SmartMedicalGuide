//using Dapper;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System.Data;

//namespace SmartMedicalGuide.Infrastructure.InfrastuctureBases
//{
//    internal class DapperRepositoryAsync : IDapperRepositoryAsync
//    {
//        #region Vars / Props


//        private readonly IConfiguration _config;

//        #endregion
//        #region Constructor(s)
//        public DapperRepositoryAsync(IConfiguration config)
//        {

//            _config = config;
//        }
//        #endregion
//        #region Methods
//        public IDbConnection GetConnection()
//        {
//            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
//        }

//        public async Task<T> GetDataAsync<T>(string sql, object? param = null, CommandType? commandType = null)
//        {
//            using var connection = GetConnection();
//            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);
//        }

//        public async Task<IEnumerable<T>?> GetAllDataAsync<T>(string sql, object? param = null, CommandType? commandType = null)
//        {
//            using var connection = GetConnection();
//            return (IEnumerable<T>?)await connection.QueryAsync<T>(sql, param, commandType: commandType);
//        }

//        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null)
//        {
//            using var connection = GetConnection();
//            return await connection.ExecuteAsync(sql, param, commandType: commandType);
//        }
//        #endregion

//    }
//}
