using RC.KeywordRank.Models;
using System;

namespace RC.KeywordRank.Attributes
{
    public class SearchEngineInfoAttribute : Attribute
    {
        public SearchEngineInfoAttribute(string title, string url, string keywordRankTitle, string keywordRankUrl)
        {
            SearchEngineInfo = new SearchEngineInfo
            {
                Name = title,
                Url = url,
                KeywordRankInfo = new KeywordRankInfo()
                {
                    Title = keywordRankTitle,
                    Url = keywordRankUrl
                }
            };
        }

        /// <summary>
        /// 검색 엔진 정보
        /// </summary>
        public SearchEngineInfo SearchEngineInfo { get; }
    }
}
