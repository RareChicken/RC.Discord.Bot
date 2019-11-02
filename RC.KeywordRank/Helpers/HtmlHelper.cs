using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace RC.KeywordRank.Helpers
{
    internal class HtmlHelper
    {
        /// <summary>
        /// Url의 Html을 제공 (비동기)
        /// </summary>
        /// <param name="url">주소</param>
        /// <param name="cancellationToken">스레드 취소 토큰</param>
        /// <returns>Html source</returns>
        public static async Task<string> GetHtmlAsync(string url)
        {
            using var client = new HttpClient();

            return await client.GetStringAsync(url);
        }

        public static async Task<HtmlDocument> GetHtmlDocumentAsync(string url)
        {
            var web = new HtmlWeb();

            return await web.LoadFromWebAsync(url);
        }
    }
}
