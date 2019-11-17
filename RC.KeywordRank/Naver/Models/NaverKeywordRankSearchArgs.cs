using RC.KeywordRank.Constants;
using RC.KeywordRank.Interface;

namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 네이버 실시간 검색어 검색 인자
    /// </summary>
    public class NaverKeywordRankSearchArgs : IKeywordRankSearchArgs
    {
        public NaverKeywordRankSearchArgs()
        {
            SearchEngine = SearchEngine.Naver;
        }

        /// <summary>
        /// 검색 엔진
        /// </summary>
        public SearchEngine SearchEngine { get; set; }

        /// <summary>
        /// 연령대
        /// </summary>
        public NaverSearchAgeGroup AgeGroup { get; set; }
    }
}
