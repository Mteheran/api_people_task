using System.Data;
using Dapper;
using Npgsql;
using People_Task.Common;

public class PostgresqlRepository : IPostgresqlRepository
{
    private readonly IDbConnection _db;
    private readonly PeopleTaskConfiguration _configuration;
    public PostgresqlRepository(PeopleTaskConfiguration configuration)
    {
        _configuration = configuration;
        _db = new NpgsqlConnection(_configuration.ConnectionStrings.PostgresqlConnection);
    }

    public async Task<T> GetAsync<T>(string command, object parms)
    {
        return (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string command, object parms)
    {
        return (await _db.QueryAsync<T>(command, parms)).ToList();
    }

    public async Task<int> ExecuteData(string command, object parms)
    {
        return await _db.ExecuteAsync(command, parms);
    }
}