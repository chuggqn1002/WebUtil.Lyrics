namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IProfileRepository Profiles { get; }
    }
}
