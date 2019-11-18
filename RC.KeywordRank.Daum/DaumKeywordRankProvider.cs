using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RC.KeywordRank.Models;

namespace RC.KeywordRank.Daum
{
    /// <summary>
    /// 다음 키워드 순위 제공자
    /// </summary>
    public interface IDaumKeywordRankProvider : IKeywordRankProvider<object> { }

    /// <summary>
    /// 다음 키워드 순위 제공자
    /// </summary>
    public class DaumKeywordRankProvider : IDaumKeywordRankProvider
    {
        public DaumKeywordRankProvider()
        {
            var keywordRankInfo = new KeywordRankInfo("실시간 이슈 검색어", "https://www.daum.net/");
            var searchEngineInfo = new SearchEngineInfo("다음", "https://www.daum.net/", keywordRankInfo);

            SearchEngineInfo = searchEngineInfo;
        }

        /// <summary>
        /// 검색 엔진 정보
        /// </summary>
        public SearchEngineInfo SearchEngineInfo { get; }

        /// <summary>
        /// 키워드 순위 제공
        /// </summary>
        /// <param name="args"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<string>> GetKeywordRankAsync([NotNull] object args, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
