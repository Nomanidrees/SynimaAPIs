using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;

namespace SYN.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserForLoginAsync(string username);

        //Task<UserEntity> GetUserByIdAsync(long id);
        //Task<IEnumerable<UserEntity>> GetUsers();
        //Task<UserEntity> AddUserAsync(UserEntity userEntity);
        //Task<UserEntity> UpdateUserAsync(long userId, UserEntity userEntity);
        //Task<bool> DeleteUserAsync(long userId);
    }
}
