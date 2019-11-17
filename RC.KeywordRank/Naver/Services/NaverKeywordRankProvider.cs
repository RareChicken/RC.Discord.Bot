using RC.KeywordRank.Constants;
using RC.KeywordRank.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank.Services
{
    /// <summary>
    /// 네이버 키워드 순위 제공자
    /// </summary>
    public interface INaverKeywordRankProvider
    {
        Task<IEnumerable<string>> GetKeywordRankAsync(NaverSearchAgeGroup ageGroup, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// 네이버 키워드 순위 제공자
    /// </summary>
    internal class NaverKeywordRankProvider : INaverKeywordRankProvider
    {
        #region Fields
        private readonly IKeywordRankParser _keywordRankParser;
        #endregion

        #region Constructors
        public NaverKeywordRankProvider()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 키워드 순위를 제공
        /// </summary>
        /// <param name="ageGroup">연령대</param>
        /// <returns>키워드 순위</returns>
        public async Task<IEnumerable<string>> GetKeywordRankAsync(NaverSearchAgeGroup ageGroup, CancellationToken cancellationToken = default)
        {
            var document = await GetHtmlDocumentAsync();

            var keywordNodes = document
                .DocumentNode
                .SelectNodes($"//div[@class='keyword_carousel']//div[@data-age='{ageGroup.GetDataAge()}']//ul[@class='rank_list v2']//span[@class='title']");

            return keywordNodes.Select(n => n.InnerText).ToList();
        }
        #endregion
    }
}
