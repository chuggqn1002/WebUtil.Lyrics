using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByEmail(string Email);
    }

}
