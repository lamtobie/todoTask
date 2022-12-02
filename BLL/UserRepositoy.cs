using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using todoTask.BLL;
using todoTask.Interface;
using todoTask.Models;

namespace todoTask.BLL
{
    public class UserRepository:IUserRepository
    {
        TodoContext context = new TodoContext();
        public IEnumerable<UserDTO> GetUsers()
        {
            List<UserDTO> UserList = null;

            var users = context.Users.ToList();
            if (users != null)
            {
                UserList = new List<UserDTO>();

                foreach (var user in users)
                {
                    UserDTO temp = new UserDTO();
                    temp.Id= user.Id;
                    temp.Phone= user.Phone;
                    temp.Name = user.Name;
                    UserList.Add(temp);
                }
            }
            return UserList;
        }
        public async Task<int> CreateUser(UserDTO user)
        {
            User addUser = new User();
            addUser.Id= user.Id;
            addUser.Name= user.Name;
            addUser.Phone= user.Phone;
            context.Users.Add(addUser);
           return await context.SaveChangesAsync();
        }
        public async Task<UserDTO> GetUser(long id)
        {
            var user= await context.Users.FindAsync(id);
            UserDTO userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Name = user.Name;
            userDTO.Phone= user.Phone;
            return userDTO;
        }
        public async Task<int> UpdateUser(long id,UserDTO user)
        {
            User updateUser=new User();
            updateUser.Id = user.Id;
            updateUser.Name=user.Name;
            updateUser.Phone= user.Phone;
            context.Entry(updateUser).State = EntityState.Modified;

            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<int> DeleteUser(long id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return 0;
            }

            context.Users.Remove(user);
            return await context.SaveChangesAsync();
        }
        private bool UserExists(long id)
        {
            return context.Users.Any(e => e.Id == id);
        }
    }
}
