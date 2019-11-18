using System;
using System.Collections.Generic;
using RC.KeywordRank.Constants;

namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 네이버 키워드 순위 결과
    /// </summary>
    public class NaverKeywordRankResult : IKeywordRankResult<string>
    {
        /// <summary>
        /// 검색 엔진
        /// </summary>
        public SearchEngineInfo SearchEngineInfo { get; set; }

        /// <summary>
        /// 집계 일시
        /// </summary>
        public DateTime AggragationDateTime { get; set; }

        /// <summary>
        /// 키워드 순위
        /// </summary>
        public IEnumerable<string> KeywordRank { get; set; }

        /// <summary>
        /// 연령대
        /// </summary>
        public NaverSearchAgeGroup AgeGroup { get; set; }
    }
}
