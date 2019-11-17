using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank
{
    /// <summary>
    /// 키워드 순위 제공자
    /// </summary>
    public interface IKeywordRankProvider
    {
        SearchEngine

        /// <summary>
        /// 키워드 순위 제공
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetKeywordRankAsync(CancellationToken cancellationToken = default);
    }
}
