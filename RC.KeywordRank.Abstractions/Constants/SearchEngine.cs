namespace RC.KeywordRank.Constants
{
    /// <summary>
    /// 검색 엔진
    /// </summary>
    public enum SearchEngine
    {
        /// <summary>
        /// 네이버
        /// </summary>
        [SearchEngineInfo("네이버", "https://www.naver.com/", "급상승 검색어", "https://datalab.naver.com/keyword/realtimeList.naver")]
        Naver,

        /// <summary>
        /// 다음
        /// </summary>
        [SearchEngineInfo("다음", "https://www.daum.net/", "실시간 이슈 검색어", "https://www.daum.net/")]
        Daum
    }
}
