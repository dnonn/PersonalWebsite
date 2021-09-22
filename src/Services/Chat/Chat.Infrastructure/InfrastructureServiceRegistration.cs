using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Events;
using BuildingBlocks.Infrastructure.Services;
using Chat.Application.Events;
using Chat.Application.Interfaces;
using Chat.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Chat.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationAssembly = typeof(ChatContext).Assembly.FullName;

            services.AddDbContext<ChatContext>(
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
                options.AddPolicy("ChatScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "chat");
                });
                
                options.AddPolicy("CreateMessage", policy => policy.RequireRole("BasicUser"));
                options.AddPolicy("DeleteMessage", policy => policy.RequireRole("Administrator"));
            });
            
            services.AddMassTransit(config => {
                config.AddConsumer<PostCreatedEventConsumer>();
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint("post-created-queue", c => {
                        c.ConfigureConsumer<PostCreatedEventConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddHttpContextAccessor();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
