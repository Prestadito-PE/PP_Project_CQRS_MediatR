using Prestadito.Menu.API.Features.Queries.GetWeatherForecast;

namespace Prestadito.Menu.API.Configuration
{
    using Flurl.Http.Configuration;
    using FluentValidation;
    using MediatR;
    using IdentityServer4.AccessTokenValidation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Prestadito.Menu.API.Features.Behavior;
    using Prestadito.Menu.API.Infrastructure.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration.GetValue<string>("");
                options.RequireHttpsMetadata = false;
                options.NameClaimType = "name";
                options.RoleClaimType = "role";
            });
            service.AddAuthorization(options =>
            {
                var authorizationPolicy =
                    new AuthorizationPolicyBuilder(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                options.AddPolicy("RequireAuthenticatedUser", authorizationPolicy);
            });
            return service;
            
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
        {
            serviceCollection.AddTransient<IValidator<GetWeatherForecastQuery>, GetWeatherForecastValidator>();

            serviceCollection.AddValidatorsFromAssemblyContaining(typeof(Program));
            serviceCollection.AddMediatR(typeof(Program));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            serviceCollection.AddScoped<IWeatherForecastService, WeatherForecastService>();
            

            return serviceCollection;
        }
    }
}