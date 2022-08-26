using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using BrunSker.Infra.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Fixture
{
    public abstract class HttpClientFixture
    {
        protected readonly HttpClient _httpClient;

        protected HttpClientFixture()
        {
            var root = new InMemoryDatabaseRoot();

            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                typeof(DbContextOptions<BrunSkerDbContext>));

                        services.Remove(descriptor);

                        services.AddDbContext<BrunSkerDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("DbForTests", root);
                        });
                    });
                });

            _httpClient = appFactory.CreateClient();
        }

        protected async Task<HttpStatusCode> CreatePostAsync<TEntity>(string route, TEntity entity) where TEntity : class
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(route, entity);
            return httpResponse.StatusCode;
        }

        protected async Task<HttpStatusCode> CreatePutAsync<TEntity>(string route, TEntity entity) where TEntity : class
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(route, entity);
            return httpResponse.StatusCode;
        }

        protected async Task<HttpStatusCode> CreateDeleteAsync(string route)
        {
            var httpResponse = await _httpClient.DeleteAsync(route);
            return httpResponse.StatusCode;
        }

        protected async Task<TEntity> CreateGetAsync<TEntity>(string route) where TEntity : class =>
            await _httpClient.GetFromJsonAsync<TEntity>(route);

        protected async Task<List<TEntity>> CreateGetAllAsync<TEntity>(string route) where TEntity : class =>
            await _httpClient.GetFromJsonAsync<List<TEntity>>(route);
    }
}
