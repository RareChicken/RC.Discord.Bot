using RC.KeywordRank.Constants;

namespace RC.KeywordRank.Interface
{
    /// <summary>
    /// 키워드 순위 검색 인자들
    /// </summary>
    public interface IKeywordRankSearchArgs
    {
        SearchEngine SearchEngine { get; }
    }
}
