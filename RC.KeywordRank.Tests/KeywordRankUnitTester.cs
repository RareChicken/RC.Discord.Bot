using RC.KeywordRank.Constants;
using RC.KeywordRank.Extensions;
using RC.KeywordRank.Helpers;
using RC.KeywordRank.Models;
using Xunit;

namespace RC.KeywordRank.Tests
{
    /// <summary>
    /// Ű���� ���� ���� �׽���
    /// </summary>
    public class KeywordRankUnitTester : UnitTester
    {
        /// <summary>
        /// ���̹� URL �׽�Ʈ
        /// </summary>
        [Fact]
        public void GetNaverUrlTest()
        {
            string url = SearchEngine.Naver.GetSearchEngineInfo().Url;

            Assert.NotNull(url);
        }

        /// <summary>
        /// ���̹� Ű���� ���� URL �׽�Ʈ
        /// </summary>
        [Fact]
        public void GetNaverKeywordRankUrlTest()
        {
            string url = SearchEngine.Naver.GetSearchEngineInfo().KeywordRankInfo.Url;

            Assert.NotNull(url);
        }
        
        /// <summary>
        /// ���̹� Ű���� ���� HTML ���� �׽�Ʈ
        /// </summary>
        [Fact]
        public async void GetNaverKeywordRankHtmlDocumentTestAsync()
        {
            var parser = new NaverKeywordRankParser();

            var document = await parser.GetHtmlDocumentAsync();

            Assert.NotNull(document);
        }

        /// <summary>
        /// ���̹� Ű���� ���� �׽�Ʈ
        /// </summary>
        [Fact]
        public async void ParseNaverKeywordRankTestAsync()
        {
            var parser = new NaverKeywordRankParser();

            var keywordRank = await parser.ParseKeywordRankAsync(AgeGroup.AllAges);

            Assert.NotNull(keywordRank);
        }

        /// <summary>
        /// ���̹� Ű���� ���� �׽�Ʈ
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
