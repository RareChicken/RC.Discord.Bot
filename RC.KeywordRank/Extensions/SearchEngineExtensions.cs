using RC.KeywordRank.Attributes;
using RC.KeywordRank.Constants;
using RC.KeywordRank.Models;

namespace RC.KeywordRank.Extensions
{
    public static class SearchEngineExtensions
    {
        /// <summary>
        /// <see cref="SearchEngine"/>의 <see cref="SearchEngineInfo"/>를 제공
        /// </summary>
        /// <param name="searchEngine">검색 엔진</param>
        /// <returns>검색 엔진 정보</returns>
        public static SearchEngineInfo GetSearchEngineInfo(this SearchEngine searchEngine)
        {
            return searchEngine.GetAttributeProperty<SearchEngineInfoAttribute, SearchEngineInfo>((a) => a.SearchEngineInfo);
        }
    }
}
