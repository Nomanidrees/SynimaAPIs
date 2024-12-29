using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;
using SYN.Infrastructure.Data;
using SYN.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SYN.Infrastructure.Repositories
{
    public class UserRepository(SynDBContext dbContext) : IUserRepository
    {
        public async Task<UserEntity> GetUserForLoginAsync(string username)
        {
            return await dbContext.User.FirstOrDefaultAsync(x => x.UserName == username);
            //return Task.FromResult(_users.FirstOrDefault(x => x.UserName == username));
        }
    }
}
