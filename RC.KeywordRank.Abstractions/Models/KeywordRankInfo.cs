namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 키워드 순위 정보
    /// </summary>
    public class KeywordRankInfo
    {
        /// <summary>
        /// <see cref="KeywordRankInfo" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="title"></param>
        /// <param name="url"></param>
        public KeywordRankInfo(string title, string url)
        {
            Title = title;
            Url = url;
        }

        /// <summary>
        /// 제목
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; }
    }
}
