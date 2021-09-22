using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Events;
using BuildingBlocks.Infrastructure.Configuration;
using BuildingBlocks.Infrastructure.Services;
using Forum.Application.Interfaces;
using Forum.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationAssembly = typeof(ForumContext).Assembly.FullName;

            services.AddDbContext<ForumContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                options => options.MigrationsAssembly(migrationAssembly)));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5000";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ForumScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "forum");
                });
                
                options.AddPolicy("CreatePost", policy => policy.RequireRole("BasicUser"));
                options.AddPolicy("CreateArea", policy => policy.RequireRole("BasicUser"));
                options.AddPolicy("CreateComment", policy => policy.RequireRole("BasicUser"));
            });
            
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                });
            });

            services.AddMassTransitHostedService();
            
            services.AddHttpContextAccessor();

            services.AddSingleton<IHashIdService, HashIdService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IForumRepository, ForumRepository>();

            var hashIdConfiguration = configuration
                .GetSection("HashId")
                .Get<HashIdConfiguration>();

            services.AddSingleton(hashIdConfiguration);

            return services;
        }
    }
}
