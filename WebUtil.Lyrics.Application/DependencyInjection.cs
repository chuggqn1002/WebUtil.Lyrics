using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebUtil.Lyrics.Application.Services.Commands.Register;
using WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile;
using WebUtil.Lyrics.Application.Validation.Authentication.Register;
using WebUtil.Lyrics.Application.Validation.Profile.AddProfile;

namespace WebUtil.Lyrics.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IValidator<AddProfileCommand>, AddProfileValidator>();
            services.AddScoped<IValidator<RegisterCommand>, RegisterValidator>();

            return services;
        }
    }

}
