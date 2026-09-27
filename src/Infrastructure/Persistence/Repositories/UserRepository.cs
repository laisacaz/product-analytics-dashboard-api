using Microsoft.EntityFrameworkCore;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using Project.Analytics.Dashboard.Domain.Entities.User;

namespace Project.Analytics.Dashboard.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByGoogleIdAsync(
        string googleId,
        CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(
                user => user.GoogleId == googleId,
                cancellationToken);
    }

    public async Task InsertAsync(
        User user,
        CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(
            user,
            cancellationToken);

        await _context.SaveChangesAsync(
            cancellationToken);
    }
}