namespace Tranzact.SeachFight.SearchEngine.Infraestructure.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Clients;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts;
    using Tranzact.SearchFight.SearchEngine.Application.Contracts;
    using Tranzact.SearchFight.SearchEngine.Application.Services;
    using Tranzact.SearchFight.SearchEngine.Domain.Contracts;
    using Tranzact.SearchFight.SearchEngine.Domain.Services;

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
            services.AddTransient<ISearchDomain, SearchDomain>();
        }
    }
}