using System;
using System.Collections.Generic;

namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 키워드 랭크 검색 결과
    /// </summary>
    public interface IKeywordRankResult<TItem> where TItem : class
    {
        /// <summary>
        /// 검색 엔진 정보
        /// </summary>
        SearchEngineInfo SearchEngineInfo { get; set; }

        /// <summary>
        /// 집계 일시
        /// </summary>
        DateTime AggragationDateTime { get; set; }

        /// <summary>
        /// 키워드 순위
        /// </summary>
        IEnumerable<TItem> KeywordRank { get; set; }
    }
}
