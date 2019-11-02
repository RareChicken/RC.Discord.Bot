using JetBrains.Annotations;
using RC.KeywordRank.Constants;
using RC.KeywordRank.Exceptions;
using RC.KeywordRank.Helpers;
using RC.KeywordRank.Interface;
using RC.KeywordRank.Models;
using System;
using System.Threading.Tasks;

namespace RC.KeywordRank
{
    /// <summary>
    /// 네이버 실시간 검색어 검색 인자
    /// </summary>
    public class NaverKeywordRankSearchArgs : IKeywordRankSearchArgs
    {
        public NaverKeywordRankSearchArgs()
        {
            SearchEngine = SearchEngine.Naver;
        }

        /// <summary>
        /// 검색 엔진
        /// </summary>
        public SearchEngine SearchEngine { get; set; }

        /// <summary>
        /// 연령대
        /// </summary>
        public AgeGroup AgeGroup { get; set; }
    }

    /// <summary>
    /// 실시간 검색어 제공자
    /// </summary>
    public interface IKeywordRankProvider
    {
        Task<KeywordRankResult> GetKeywordRankAsync<T>([NotNull] T args) where T : IKeywordRankSearchArgs;
        Task<NaverKeywordRankResult> GetNaverKeywordRankAsync(AgeGroup ageGroup);
    }

    /// <summary>
    /// 실시간 검색어 제공자
    /// </summary>
    public class KeywordRankProvider : IKeywordRankProvider
    {
        #region Fields
        private readonly INaverKeywordRankParser _naverRankKeywordParser;
        #endregion

        #region Cosntructors
        /// <summary>
        /// 키워드 순위 제공자
        /// </summary>
        /// <param name="naverKeywordRankParser"></param>
        /// <exception cref="ArgumentNullException" />
        public KeywordRankProvider([NotNull] INaverKeywordRankParser naverKeywordRankParser)
        {
            _naverRankKeywordParser = naverKeywordRankParser ??
                throw new ArgumentNullException(nameof(naverKeywordRankParser));
        }
        #endregion

        #region Methods
        /// <summary>
        /// 키워드 순위 제공
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<KeywordRankResult> GetKeywordRankAsync<T>([NotNull] T args) where T : IKeywordRankSearchArgs
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
        public async Task<NaverKeywordRankResult> GetNaverKeywordRankAsync(AgeGroup ageGroup)
        {
            return new NaverKeywordRankResult
            {
                AgeGroup = ageGroup,
                Keywords = await _naverRankKeywordParser.ParseKeywordRankAsync(ageGroup),
                AggragationDateTime = DateTime.Now
            };
        }
        #endregion
    }
}
