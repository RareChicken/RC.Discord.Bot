using JetBrains.Annotations;
using RC.KeywordRank.Constants;
using RC.KeywordRank.Exceptions;
using RC.KeywordRank.Interface;
using RC.KeywordRank.Models;
using RC.KeywordRank.Services;
using RC.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RC.KeywordRank
{
    /// <summary>
    /// 실시간 검색어
    /// </summary>
    public interface IKeywordRank
    {
        Task<IKeywordRankResult> GetKeywordRankAsync<T>([NotNull] T args, CancellationToken cancellationToken = default) where T : IKeywordRankSearchArgs;
        Task<NaverKeywordRankResult> GetNaverKeywordRankAsync(NaverSearchAgeGroup ageGroup, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// 실시간 검색어
    /// </summary>
    public class KeywordRank : IKeywordRank
    {
        #region Fields
        private readonly INaverKeywordRankProvider _naverRankKeywordProvider;
        #endregion

        #region Cosntructors
        /// <summary>
        /// 키워드 순위 제공자
        /// </summary>
        /// <param name="naverKeywordRankParser"></param>
        /// <exception cref="ArgumentNullException" />
        public KeywordRank([NotNull] INaverKeywordRankProvider naverKeywordRankParser)
        {
            Check.NotNull(naverKeywordRankParser, nameof(naverKeywordRankParser));

            _naverRankKeywordProvider = naverKeywordRankParser;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 키워드 순위 제공
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<IKeywordRankResult> GetKeywordRankAsync<T>([NotNull] T args, CancellationToken cancellationToken = default) where T : IKeywordRankSearchArgs
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            return args.SearchEngine switch
            {
                SearchEngine.Naver when args is NaverKeywordRankSearchArgs naverArgs => await GetNaverKeywordRankAsync(naverArgs.AgeGroup),

                _ => throw new KeywordRankSearchArgsTypeIsNotMatchingException(),
            };
        }

        /// <summary>
        /// 네이버 키워드 순위 제공
        /// </summary>
        /// <param name="ageGroup"></param>
        /// <returns></returns>
        public async Task<NaverKeywordRankResult> GetNaverKeywordRankAsync(NaverSearchAgeGroup ageGroup, CancellationToken cancellationToken = default)
        {
            var keywordRank = await _naverRankKeywordProvider.GetKeywordRankAsync(ageGroup);

            return new NaverKeywordRankResult
            {
                AgeGroup = ageGroup,
                KeywordRank = keywordRank,
                AggragationDateTime = DateTime.Now
            };
        }
        #endregion
    }
}
