using Application.Extensions;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Presistence.Extensions;
using Respawn;

namespace eShopUnitTests.Tests
{
    [SetUpFixture]
    public class Testing
    {
        private static IServiceScopeFactory _scopeFactory;
        private static IConfiguration _configuration;
        private static Respawner _respawner ;
        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, false)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var service = new ServiceCollection();
            service.AddApplications();
            service.AddPresistence(_configuration);
            service.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.ApplicationName == "API" &&
                w.EnvironmentName == "Development"));
            _scopeFactory = service.BuildServiceProvider().GetService<IServiceScopeFactory>();
            _respawner = await Respawner.CreateAsync(_configuration.GetConnectionString("constr"),new RespawnerOptions
            {
                DbAdapter = DbAdapter.SqlServer,
                SchemasToExclude = new[] {"public"}
            });
            
        }
        public static async Task ResetState()
        {
            await _respawner.ResetAsync(_configuration.GetConnectionString("constr"));
        }
        public static async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<EShopDbContext>();
            return await context.FindAsync<TEntity>(id);
        }
        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<EShopDbContext>();
            context.Add(entity);
            await context.SaveChangesAsync();
        }
        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            return await mediator.Send(request);
        }

    }
}
