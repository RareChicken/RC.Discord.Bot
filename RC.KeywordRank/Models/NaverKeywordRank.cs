using RC.KeywordRank.Constants;

namespace RC.KeywordRank.Models
{
    public class NaverKeywordRank : KeywordRankResult
    {
        public NaverKeywordRank()
        {
            SearchEngine = SearchEngine.Naver;
        }

        /// <summary>
        /// 연령대
        /// </summary>
        public AgeGroup AgeGroup { get; set; }
    }
}
