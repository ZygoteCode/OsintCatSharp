using System;

namespace OsintCatSharp
{
    public class OsintCatCore
    {
        private HttpClient _httpClient;
        private string _baseUri;

        public OsintCatCore(string osintCatApiKey)
        {
            _baseUri = "https://osintcat.net/api";
            _httpClient = OsintCatUtils.CreateHttpClient(osintCatApiKey);
        }

        private string GetRequest(string url)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"{_baseUri}{url}").GetAwaiter().GetResult();

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

        public string RobloxLookup(string query)
        {
            return Query("roblox", query);
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

        public string GitHubUserInfo(string query)
        {
            return Query("github-userinfo", query);
        }

        public string Minecraft(string query)
        {
            return Query("minecraft", query);
        }

        public string MinecraftLookup(string query, string type)
        {
            return GetRequest($"/minecraft?query={Uri.EscapeDataString(query)}&type={type}");
        }

        public string TwitterOSINT(string query)
        {
            return Query("twitter-osint", query);
        }

        public string UsernameLookup(string query)
        {
            return Query("user-osint", query);
        }

        public string DatabaseSearch(string query)
        {
            return Query("database-search", query);
        }

        public string IpInfo(string query)
        {
            return Query("ip", query);
        }

        public string DnsResolver(string query)
        {
            return Query("dns-resolver", query);
        }

        public string DomainLookup(string query)
        {
            return Query("domain", query);
        }

        public string ChileanName(string query)
        {
            return Query("chilean-name", query);
        }

        public string DiscordMonitor(string query)
        {
            return Query("discord-stalker", query);
        }
    }
}