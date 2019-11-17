using HtmlAgilityPack;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank.Helpers
{
    /// <summary>
    /// HTML 헬퍼
    /// </summary>
    internal class HtmlHelper
    {
        /// <summary>
        /// HttpClient로 html 문자열 제공
        /// </summary>
        /// <param name="url">주소</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Html source</returns>
        public static async Task<string> GetHtmlAsync(string url, CancellationToken cancellationToken = default)
        {
            using var client = new HttpClient();

            return await client.GetStringAsync(url);
        }

        /// <summary>
        /// HtmlWeb으로 HtmlDocument 제공
        /// </summary>
        /// <param name="url">주소</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<HtmlDocument> GetHtmlDocumentAsync(string url, CancellationToken cancellationToken = default)
        {
            var web = new HtmlWeb();

            return await web.LoadFromWebAsync(url);
        }
    }
}
