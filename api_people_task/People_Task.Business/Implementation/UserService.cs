namespace People_Task.Business
{
    public class UserService : IUserService
    {
        private readonly IPostgresqlRepository _dbPostgresqlService;

        public UserService(IPostgresqlRepository dbPostgresqlService)
        {
            _dbPostgresqlService = dbPostgresqlService;
        }
        public async Task<bool> CreateUser(User user)
        {
            var result = await _dbPostgresqlService.ExecuteData(
                "INSERT INTO public.users(user_name, password, last_login, status) VALUES (@UserName, @Password, @LastLogin, @Status)", user
            );
            return true;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _dbPostgresqlService.GetAllAsync<User>(
                "SELECT * FROM public.users", new { }
            );
            return result;
        }

        public async Task<User> GetUser(int userId)
        {
            var result = await _dbPostgresqlService.GetAsync<User>(
                "SELECT * FROM public.users WHERE id=@userId", new { userId }
            );
            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _dbPostgresqlService.ExecuteData(
                "UPDATE public.users SET user_name=@UserName, password=@Password, last_login=@LastLogin, status=@Status WHERE id=@Id", user
            );
            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var result = await _dbPostgresqlService.ExecuteData(
                "DELETE FROM public.users WHERE id=@userId", new { userId }
            );
            return true;
        }
    }
}