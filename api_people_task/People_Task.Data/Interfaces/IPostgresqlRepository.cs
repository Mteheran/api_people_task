public interface IPostgresqlRepository
{
    Task<T> GetAsync<T>(string command, object parms);
    Task<IEnumerable<T>> GetAllAsync<T>(string command, object parms);
    Task<int> ExecuteData(string command, object parms);
}