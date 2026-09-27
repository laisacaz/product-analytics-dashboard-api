using Project.Analytics.Dashboard.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Application.Auth.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByGoogleIdAsync(
            string googleId,
            CancellationToken cancellationToken);

        Task InsertAsync(
            User user,
            CancellationToken cancellationToken);
    }
}
