using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile;
using WebUtil.Lyrics.Contracts.Profile;
using WebUtil.Lyrics.Contracts.UserProfile.AddProfile;
using WebUtil.Lyrics.Service;
using WebUtil.Lyrics.Application.UserProfile.Queries.GetProfile;
using WebUtil.Lyrics.Contracts.UserProfile.GetProfile;
using System.Security.Claims;
using WebUtil.Lyrics.Application.Profile.Commands.UploadAvatar;
using WebUtil.Lyrics.Contracts.UserProfile.UploadAvatar;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("profile")]
    [ApiController]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly JwtService _jwtService;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ProfileController(ISender mediator, IMapper mapper, JwtService jwtService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> AddProfile(AddProfileRequest request)
        {
            //handle the image upload?
            Guid Uuid = _jwtService.ExtractJwt();
            var requestData = new AddProfileRequestData(Uuid,
                    request.FirstName,
                    request.LastName,
                    request.Middle,
                    request.Title,
                    request.Address,
                    request.Ward,
                    request.District,
                    request.City,
                    request.Country,
                    request.ZipCode,
                    request.Birthdate,
                    request.Avatar,
                    request.Gender,
                    request.TelNum,
                    request.Description,
                    request.Status,
                    request.Created,
                    request.Updated);
            var command = _mapper.Map<AddProfileCommand>(requestData);
            var addProfileResult = await _mediator.Send(command);

            var profileResponse = _mapper.Map<ProfileResponse>(addProfileResult.profile.ProfileId);

            return Ok(profileResponse);

        }

        [HttpPost("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProfile()
        {
            Guid Uuid = _jwtService.ExtractJwt();
            IEnumerable<Claim> claims = _jwtService.getTokenClaim();
            string Email = claims.First(c => c.Type == ClaimTypes.Email).Value;
            string Username = claims.First(c => c.Type == ClaimTypes.Name).Value;
            //Console.WriteLine(Uuid);
            var requestData = new GetProfileQuery(Uuid, Email, Username);
            var getProfileResult = await _mediator.Send(requestData);

            var getProfileResponse = _mapper.Map<GetProfileResponse>(getProfileResult);

            return Ok(getProfileResponse);
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadAvatar(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

           UploadAvatarCommand uploadAvatarCommand = 
                new UploadAvatarCommand(formFile.FileName, formFile.OpenReadStream());
            var uploadAvatarResult = await _mediator.Send(uploadAvatarCommand);

            var uploadAvatarResponse = _mapper.Map<UploadAvatarResponse>(uploadAvatarResult);

            return Ok(uploadAvatarResult);

        }
    }

}
