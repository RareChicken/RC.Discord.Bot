using JetBrains.Annotations;

namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 검색 엔진 정보
    /// </summary>
    public class SearchEngineInfo
    {
        /// <summary>
        /// <see cref="SearchEngineInfo" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <param name="keywordRankInfo"></param>
        public SearchEngineInfo(string name, string url, KeywordRankInfo keywordRankInfo)
        {
            Name = name;
            Url = url;
            KeywordRankInfo = keywordRankInfo;
        }

        /// <summary>
        /// 검색 엔진 이름
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 검색 엔진 Url
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// 검색 엔진의 키워드 랭크 정보
        /// </summary>
        public KeywordRankInfo KeywordRankInfo { get; }
    }
}
