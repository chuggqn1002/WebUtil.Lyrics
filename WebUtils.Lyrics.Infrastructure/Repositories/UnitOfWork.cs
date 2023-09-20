using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            Users = userRepository;
            Profiles = profileRepository;

        }
        public IUserRepository Users { get; }
        public IProfileRepository Profiles { get; }
    }
}
