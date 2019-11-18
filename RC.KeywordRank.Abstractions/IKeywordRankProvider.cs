using JetBrains.Annotations;
using RC.KeywordRank.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank
{
    /// <summary>
    /// 키워드 순위 제공자
    /// </summary>
    /// <typeparam name="TArgs"></typeparam>
    public interface IKeywordRankProvider<TArgs>
    {
        /// <summary>
        /// 검색 엔진 정보
        /// </summary>
        SearchEngineInfo SearchEngineInfo { get; }

        /// <summary>
        /// 키워드 순위 제공
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetKeywordRankAsync([NotNull] TArgs args, CancellationToken cancellationToken = default);
    }
}
