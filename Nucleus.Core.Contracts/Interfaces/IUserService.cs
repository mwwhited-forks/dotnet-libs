﻿using Nucleus.Core.Contracts.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserAction user);
        Task UpdateAsync(UserAction user);
        Task RemoveAsync(string id);

        IQueryable<User> Query();

        Task<User?> GetByUserIdAsync(string userId);
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByEmailAddressAsync(string emailAddress);
    }
}
