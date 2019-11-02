using RC.KeywordRank.Constants;
using RC.KeywordRank.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.KeywordRank.Helpers
{
    /// <summary>
    /// 네이버 키워드 순위 파서
    /// </summary>
    public interface INaverKeywordRankParser
    {
        Task<IEnumerable<string>> ParseKeywordRankAsync(AgeGroup ageGroup);
    }

    /// <summary>
    /// 네이버 키워드 순위 파서
    /// </summary>
    public class NaverKeywordRankParser : KeywordRankParser, INaverKeywordRankParser
    {
        #region Constructors
        public NaverKeywordRankParser()
        {
            SearchEngine = SearchEngine.Naver;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 키워드 순위를 제공
        /// </summary>
        /// <param name="ageGroup">연령대</param>
        /// <returns>키워드 순위</returns>
        public async Task<IEnumerable<string>> ParseKeywordRankAsync(AgeGroup ageGroup)
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
