using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Authentication.Common;
using WebUtil.Lyrics.Application.Common.Errors;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces;
using WebUtil.Lyrics.Domain.Entities;
using WebUtil.Lyrics.Domain.Enums;
using FluentValidation;
using FluentValidation.Results;

namespace WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile
{
    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, AddProfileResult>
    {
        private IValidator<AddProfileCommand> _validator;
        private readonly IProfileRepository _profileRepository;

        public AddProfileCommandHandler(IValidator<AddProfileCommand> validator, IProfileRepository profileRepository)
        {
            _validator = validator;
            _profileRepository = profileRepository;
        }



        public async Task<AddProfileResult> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            //validate so that user doesn't exists
            if (await _profileRepository.GetByGuidAsync(request.Uuid) is not null)
            {
                throw new DuplicateEmailException();
            }


            ValidationResult validationResult = await _validator.ValidateAsync(request);

            if (validationResult == null || !validationResult.IsValid)
            {
                //foreach (ValidationFailure failure in validationResult.Errors)
                //{
                //    throw new InvalidProfileData();
                //}
                throw new InvalidProfileData();
            }

            var profile = new User_Profile
            {
                    Uuid = request.Uuid,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Middle = request.Middle,
                    Title = request.Title,
                    Address = request.Address,
                    Ward = request.Ward,
                    District = request.District,
                    City = request.City,
                    Country = request.Country,
                    ZipCode = request.ZipCode,
                    Birthdate =request.Birthdate,
                    Avatar = request.Avatar,
                    Gender = request.Gender,
                    TelNum = request.TelNum,
                    Description = request.Description,
                    Status = request.Status,
                    Created = request.Created,
                    Updated = request.Updated
        };

            long result = await _profileRepository.AddAsync(profile);
            return new AddProfileResult(
                profile);
        }
    }
    
}
