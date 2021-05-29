namespace Tranzact.SeachFight.SearchEngine.Infraestructure.Configuration
{
    public class ExternalClientConfiguration
    {
        public static string GoogleApiSearch => "GoogleApiSearch";
        public static string BingApiSearch => "BingApiSearch";
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string ApiKeyName { get; set; }
        public string SearchEngineId { get; set; }
        
    }
}