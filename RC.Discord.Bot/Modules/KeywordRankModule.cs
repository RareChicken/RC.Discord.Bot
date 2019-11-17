using RC.Discord.Bot.EmbedBuilders;
using RC.Discord.Bot.Models;
using Discord.Commands;
using JetBrains.Annotations;
using RC.KeywordRank;
using RC.KeywordRank.Constants;
using RC.KeywordRank.Models;
using System;
using System.Threading.Tasks;
using RC.Utilities;

namespace RC.Discord.Bot.Modules
{
    /// <summary>
    /// 실시간 검색어 모듈
    /// </summary>
    public class KeywordRankModule : ModuleBase<SocketCommandContext>
    {
        #region Fields
        private readonly IKeywordRank _keywordRankProvider;
        private readonly BotConfig _botConfig;
        #endregion

        #region Constructors
        /// <summary>
        /// <see cref="KeywordRankModule" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="keywordRankProvider"></param>
        /// <param name="botConfig"></param>
        /// <exception cref="ArgumentNullException" />
        public KeywordRankModule(
            [NotNull] IKeywordRank keywordRankProvider,
            [NotNull] BotConfig botConfig)
        {
            Check.NotNull(keywordRankProvider, nameof(keywordRankProvider));
            Check.NotNull(botConfig, nameof(botConfig));

            _keywordRankProvider = keywordRankProvider;
            _botConfig = botConfig;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 네이버 실시간 검색어 커맨드
        /// </summary>
        /// <returns></returns>
        [Command("네이버실시간검색어", RunMode = RunMode.Async), Alias("네이버실검", "ㄴㅅㄱ"), Summary("네이버 실시간 검색어를 파싱하여 출력하는 커맨드")]
        public async Task NaverKeywordRankCommandAsync()
        {
            var result = await _keywordRankProvider.GetNaverKeywordRankAsync(NaverSearchAgeGroup.AllAges);
            var embedBuilder = new NaverKeywordRankEmbedBuilder(result, _botConfig);

            await Context.Channel.SendMessageAsync(string.Empty, false, embedBuilder.Build());
        }

        /// <summary>
        /// 다음 실시간 검색어 커맨드
        /// </summary>
        /// <returns></returns>
        [Command("다음실시간검색어", RunMode = RunMode.Async), Alias("다음실검", "ㄷㅅㄱ"), Summary("다음 실시간 검색어를 파싱하여 출력하는 커맨드")]
        public async Task DaumKeywordRankCommandAsync()
        {
            // var result = await _keywordRankProvider.GetDaumKeywordRankAsync();
        }
        #endregion
    }
}
