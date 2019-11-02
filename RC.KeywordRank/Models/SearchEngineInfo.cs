namespace RC.KeywordRank.Models
{
    public class SearchEngineInfo
    {
        /// <summary>
        /// 검색 엔진 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 검색 엔진 Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 검색 엔진의 키워드 랭크 정보
        /// </summary>
        public KeywordRankInfo KeywordRankInfo { get; set; }
    }
}
