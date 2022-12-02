using todoTask.BLL;

namespace todoTask.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<UserDTO> GetUsers();
        public Task<int> CreateUser(UserDTO user);
        public Task<UserDTO> GetUser(long id);
        public Task<int> UpdateUser(long id, UserDTO user);
        public Task<int> DeleteUser(long id);

    }
}
