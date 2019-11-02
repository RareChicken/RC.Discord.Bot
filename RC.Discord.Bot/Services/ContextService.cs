using RC.Discord.Bot.Models;
using Discord.Commands;
using Discord.WebSocket;
using JetBrains.Annotations;
using System;

namespace RC.Discord.Bot.Services
{
    /// <summary>
    /// 콘텍스트 서비스
    /// </summary>
    public interface IContextService
    {
        bool IsIgnorableContext([NotNull] SocketCommandContext context, ref int argPos);
    }

    /// <summary>
    /// 콘텍스트 서비스
    /// </summary>
    public class ContextService : IContextService
    {
        #region Fields
        private readonly BotConfig _botConfig;
        #endregion

        #region Constructors
        /// <summary>
        /// <see cref="ContextService" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="botConfig"></param>
        /// <exception cref="ArgumentNullException" />
        public ContextService([NotNull] BotConfig botConfig)
        {
            _botConfig = botConfig ??
                throw new ArgumentNullException(nameof(botConfig));
        }
        #endregion

        #region Methods
        /// <summary>
        /// 콘텍스트를 무시해도 되는지 여부 제공
        /// </summary>
        /// <param name="context"></param>
        /// <param name="argPos"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
        public bool IsIgnorableContext([NotNull] SocketCommandContext context, ref int argPos)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return context.Message == null ||
                context.User.IsBot ||
                string.IsNullOrWhiteSpace(context.Message.Content) ||
                !IsPrefixCorrect(context.Message, ref argPos);
        }

        /// <summary>
        /// 올바른 접두사인지 여부 제공
        /// </summary>
        /// <param name="userMessage"></param>
        /// <param name="argPos"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
        private bool IsPrefixCorrect([NotNull] SocketUserMessage userMessage, ref int argPos)
        {
            if (userMessage == null)
                throw new ArgumentNullException(nameof(userMessage));

            return userMessage.HasStringPrefix(_botConfig.Prefix, ref argPos);
        }
        #endregion
    }
}
