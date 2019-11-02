using RC.KeywordRank.Constants;
using RC.KeywordRank.Extensions;
using RC.KeywordRank.Helpers;
using RC.KeywordRank.Models;
using Xunit;

namespace RC.KeywordRank.Tests
{
    /// <summary>
    /// 키워드 순위 단위 테스터
    /// </summary>
    public class KeywordRankUnitTester : UnitTester
    {
        /// <summary>
        /// 네이버 URL 테스트
        /// </summary>
        [Fact]
        public void GetNaverUrlTest()
        {
            string url = SearchEngine.Naver.GetSearchEngineInfo().Url;

            Assert.NotNull(url);
        }

        /// <summary>
        /// 네이버 키워드 순위 URL 테스트
        /// </summary>
        [Fact]
        public void GetNaverKeywordRankUrlTest()
        {
            string url = SearchEngine.Naver.GetSearchEngineInfo().KeywordRankInfo.Url;

            Assert.NotNull(url);
        }
        
        /// <summary>
        /// 네이버 키워드 순위 HTML 문서 테스트
        /// </summary>
        [Fact]
        public async void GetNaverKeywordRankHtmlDocumentTestAsync()
        {
            var parser = new NaverKeywordRankParser();

            var document = await parser.GetHtmlDocumentAsync();

            Assert.NotNull(document);
        }

        /// <summary>
        /// 네이버 키워드 순위 테스트
        /// </summary>
        [Fact]
        public async void ParseNaverKeywordRankTestAsync()
        {
            var parser = new NaverKeywordRankParser();

            var keywordRank = await parser.ParseKeywordRankAsync(AgeGroup.AllAges);

            Assert.NotNull(keywordRank);
        }

        /// <summary>
        /// 네이버 키워드 순위 테스트
        /// </summary>
        [Fact]
        public async void GetNaverKeywordRankTestAsync()
        {
            var parser = GetKeywordRankProvider();

            var result = (NaverKeywordRankResult)await parser.GetKeywordRankAsync(new NaverKeywordRankSearchArgs()
            {
                AgeGroup = AgeGroup.AllAges
            });

            Assert.NotNull(result);
        }
    }
}
