using RC.Discord.Bot.Models;
using Discord;
using JetBrains.Annotations;
using RC.KeywordRank.Extensions;
using RC.KeywordRank.Models;
using System;

namespace RC.Discord.Bot.EmbedBuilders
{
    /// <summary>
    /// 네이버 실시간 검색어 임베드 빌더
    /// </summary>
    public class NaverKeywordRankEmbedBuilder : EmbedBuilder
    {
        #region Fields
        private readonly BotConfig _botConfig;
        #endregion

        /// <summary>
        /// <see cref="NaverKeywordRankEmbedBuilder" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="rankResult"></param>
        /// <exception cref="ArgumentNullException" />
        public NaverKeywordRankEmbedBuilder([NotNull] NaverKeywordRankResult rankResult, [NotNull] BotConfig botConfig)
        {
            if (rankResult == null)
                throw new ArgumentNullException(nameof(rankResult));

            _botConfig = botConfig ??
                throw new ArgumentNullException(nameof(botConfig));

            SetProperties(rankResult);
        }

        /// <summary>
        /// 속성들 설정
        /// </summary>
        /// <param name="rankResult"></param>
        /// <exception cref="ArgumentNullException" />
        public void SetProperties([NotNull] NaverKeywordRankResult rankResult)
        {
            if (rankResult == null)
                throw new ArgumentNullException(nameof(rankResult));

            Title = $"{rankResult.SearchEngine.GetSearchEngineInfo().Name} {rankResult.SearchEngine.GetSearchEngineInfo().KeywordRankInfo.Title}";
            Url = rankResult.SearchEngine.GetSearchEngineInfo().KeywordRankInfo.Url;
            Description = rankResult.AgeGroup.GetName();
            Color = new Color(0, 199, 60);
            Author = new EmbedAuthorBuilder()
            {
                Name = _botConfig.Name,
                Url = _botConfig.Github
            };

            int i = 0;
            foreach (string keyword in rankResult.Keywords)
            {
                Fields.Add(new EmbedFieldBuilder()
                {
                    Name = $"{++i}.",
                    Value = keyword
                });
            }

            Footer = new EmbedFooterBuilder()
            {
                Text = $"집계시간 - {rankResult.AggragationDateTime.ToString()}"
            };
        }
    }
}
