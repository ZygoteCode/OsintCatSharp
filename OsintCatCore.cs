using System.Text;
using System.Text.Encodings.Web;

namespace OsintCatSharp
{
    public class OsintCatCore
    {
        private HttpClient _httpClient;
        private string _baseUri, _osintCatApiKey;

        public OsintCatCore(string osintCatApiKey)
        {
            _osintCatApiKey = osintCatApiKey;
            _baseUri = "https://osintcat.net/api";
            _httpClient = OsintCatUtils.CreateHttpClient();
        }

        private string GetRequest(string url)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"{_baseUri}{url}&id={_osintCatApiKey}").GetAwaiter().GetResult();

            string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            response.Dispose();

            return body;
        }

        private string Query(string queryName, string queryString)
        {
            return GetRequest($"/{queryName}?query={Uri.EscapeDataString(queryString)}");
        }

        public string BreachLookup(string query)
        {
            return Query("breach", query);
        }

        public string DiscordLookup(string query)
        {
            return Query("discord", query);
        }

        public string RedditLookup(string query)
        {
            return Query("reddit", query);
        }

        public string DiscordToRoblox(string query)
        {
            return Query("discord-to-roblox", query);
        }

        public string EmailOSINT(string query)
        {
            return Query("email-osint", query);
        }

        public string PhoneOSINT(string query)
        {
            return Query("phone-osint", query);
        }

        public string Domain(string query)
        {
            return Query("domain", query);
        }

        public string GitHubOSINT(string query)
        {
            return Query("github-osint", query);
        }

        public string DiscordMonitor(string query)
        {
            return Query("discord-stalker", query);
        }

        public string IpInfo(string query)
        {
            return Query("ip", query);
        }

        public string DnsResolver(string query)
        {
            return Query("dns-resolver", query);
        }

        public string Username(string query)
        {
            return Query("username", query);
        }

        public string ChileanName(string query)
        {
            return Query("chilean-name", query);
        }

        public string Minecraft(string query)
        {
            return Query("minecraft", query);
        }
    }
}