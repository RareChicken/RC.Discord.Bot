using HtmlAgilityPack;
using RC.KeywordRank.Constants;
using RC.KeywordRank.Extensions;
using RC.KeywordRank.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank.Services
{
    /// <summary>
    /// 네이버 키워드 순위 제공자
    /// </summary>
    public interface INaverKeywordRankProvider : IKeywordRankProvider<NaverSearchAgeGroup>
    {
    }

    /// <summary>
    /// 네이버 키워드 순위 제공자
    /// </summary>
    internal class NaverKeywordRankProvider : INaverKeywordRankProvider
    {
        #region Constructors
        public NaverKeywordRankProvider()
        {
            var keywordRankInfo = new KeywordRankInfo("급상승 검색어", "https://datalab.naver.com/keyword/realtimeList.naver");
            var searchEngineInfo = new SearchEngineInfo("네이버", "https://www.naver.com/", keywordRankInfo);

            SearchEngineInfo = searchEngineInfo;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 검색 엔진 정보
        /// </summary>
        public SearchEngineInfo SearchEngineInfo { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 키워드 순위를 제공
        /// </summary>
        /// <param name="ageGroup">연령대</param>
        /// <param name="cancellationToken"></param>
        /// <returns>키워드 순위</returns>
        public async Task<IEnumerable<string>> GetKeywordRankAsync(NaverSearchAgeGroup ageGroup, CancellationToken cancellationToken = default)
        {
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(SearchEngineInfo.KeywordRankInfo.Url);

            var keywordNodes = document
                .DocumentNode
                .SelectNodes($"//div[@class='keyword_carousel']//div[@data-age='{ageGroup.GetDataAge()}']//ul[@class='rank_list v2']//span[@class='title']");

            return keywordNodes.Select(n => n.InnerText).ToList();
        }
        #endregion
    }
}
