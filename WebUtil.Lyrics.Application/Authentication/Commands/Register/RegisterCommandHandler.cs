using WebUtil.Lyrics.Application.Authentication.Common;
using WebUtil.Lyrics.Application.Common.Errors;
using WebUtil.Lyrics.Application.Common.Interfaces;
using WebUtil.Lyrics.Domain.Entities;
using MediatR;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Domain.Enums;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace WebUtil.Lyrics.Application.Services.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private IValidator<RegisterCommand> _validator;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<RegisterCommandHandler> _logger;
    public RegisterCommandHandler(IValidator<RegisterCommand> validator, IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator,
        ILogger<RegisterCommandHandler> logger)
    {
        _validator = validator;
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Register command: {command}");
        //validate so that user doesn't exists
        if (await _userRepository.GetUserByEmail(command.Email) is not null)
        {
            _logger.LogTrace("Existed user");
            throw new DuplicateEmailException();
        }

        ValidationResult validationResult = await _validator.ValidateAsync(command);

        if (validationResult == null || !validationResult.IsValid)
        {
            //foreach (ValidationFailure failure in validationResult.Errors)
            //{
            //    throw new InvalidRegisterData();
            //}
            throw new InvalidRegisterData();
        }


        var user = new User
        {
            Uuid = Guid.NewGuid(),
            Username = command.Username,
            Email = command.Email,
            Password = command.Password,
            Role = (Role)int.Parse(command.Role)
        };

       long result = await _userRepository.AddAsync(user);
       user.Userid = result;
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}

