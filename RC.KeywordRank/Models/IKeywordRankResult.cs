using RC.KeywordRank.Constants;
using System;
using System.Collections.Generic;

namespace RC.KeywordRank.Models
{
    /// <summary>
    /// 키워드 랭크 검색 결과
    /// </summary>
    public interface IKeywordRankResult
    {
        /// <summary>
        /// 검색 엔진
        /// </summary>
        public SearchEngine SearchEngine { get; set; }

        /// <summary>
        /// 집계시간
        /// </summary>
        public DateTime AggragationDateTime { get; set; }

        /// <summary>
        /// 키워드 목록
        /// </summary>
        public IEnumerable<string> KeywordRank { get; set; }
    }
}
