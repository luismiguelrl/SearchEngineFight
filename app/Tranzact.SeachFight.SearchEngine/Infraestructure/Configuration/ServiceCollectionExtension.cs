namespace Tranzact.SeachFight.SearchEngine.Infraestructure.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tranzact.SeachFight.SearchEngine.Application.Contracts;
    using Tranzact.SeachFight.SearchEngine.Application.Services;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Clients;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts;

    public static class ServiceCollectionExtension
    {
        public static void AddSearchFightDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<IExternalSearchClient, GoogleClient>();
            services.AddHttpClient<IExternalSearchClient, BingClient>();

            services.Configure<ExternalClientConfiguration>(ExternalClientConfiguration.GoogleApiSearch,
                Configuration.GetSection("ExternalClientConfiguration:GoogleApiSearch"));

            services.Configure<ExternalClientConfiguration>(ExternalClientConfiguration.BingApiSearch,
                Configuration.GetSection("ExternalClientConfiguration:BingApiSearch"));

            services.AddTransient<ISearchAplication, SearchAplication>();
        }
    }
}