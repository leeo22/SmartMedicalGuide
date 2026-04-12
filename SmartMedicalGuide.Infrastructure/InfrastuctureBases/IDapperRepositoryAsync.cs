using System.Data;

namespace SmartMedicalGuide.Infrastructure.InfrastuctureBases
{
    public interface IDapperRepositoryAsync
    {
        IDbConnection GetConnection();
        Task<T?> GetDataAsync<T>(string sql, object? param = null, CommandType? commandType = null);
        Task<IEnumerable<T>?> GetAllDataAsync<T>(string sql, object? param = null, CommandType? commandType = null);
        Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null);
    }
}
