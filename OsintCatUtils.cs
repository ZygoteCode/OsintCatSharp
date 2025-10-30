using System.Net;
using System.Net.Sockets;

namespace OsintCatSharp
{
    internal class OsintCatUtils
    {
        public static HttpClient CreateHttpClient()
        {
            SocketsHttpHandler handler = new SocketsHttpHandler
            {
                ConnectCallback = async (ctx, ct) =>
                {
                    Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp)
                    {
                        NoDelay = true,
                        DualMode = true,
                    };

                    await socket.ConnectAsync(ctx.DnsEndPoint, ct).ConfigureAwait(false);
                    return new NetworkStream(socket, ownsSocket: true);
                },

                UseProxy = false,
                Proxy = null,
                UseCookies = false,
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.None,

                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(10),
                PooledConnectionLifetime = Timeout.InfiniteTimeSpan,
                MaxConnectionsPerServer = int.MaxValue,

                EnableMultipleHttp2Connections = true
            };

            HttpClient client = new HttpClient(handler, disposeHandler: true)
            {
                Timeout = TimeSpan.FromSeconds(99999),
                DefaultRequestVersion = HttpVersion.Version30,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher
            };

            return client;
        }
    }
}