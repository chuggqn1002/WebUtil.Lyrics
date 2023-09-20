using FluentValidation;
using MediatR;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces;
using WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile;
using WebUtil.Lyrics.Application.Common.Errors;

namespace WebUtil.Lyrics.Application.UserProfile.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResult>
    {

        private IValidator<AddProfileCommand> _validator;
        private readonly IProfileRepository _profileRepository;


        public GetProfileQueryHandler(IValidator<AddProfileCommand> validator, IProfileRepository profileRepository)
        {
            _validator = validator;
            _profileRepository = profileRepository;
        }

        public async Task<GetProfileResult> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var profileQuery = await _profileRepository.GetByGuidAsync(request.Uuid);
            if (profileQuery is null)
            {
                throw new NotProfileExisted();
            }

            return new GetProfileResult(
                request.Email, 
                request.Username,
                profileQuery);
            
        }
    }
}
