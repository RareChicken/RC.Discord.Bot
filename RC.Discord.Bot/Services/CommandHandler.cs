using RC.Discord.Bot.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using JetBrains.Annotations;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace RC.Discord.Bot
{
    /// <summary>
    /// 커맨드 처리자
    /// </summary>
    public interface ICommandHandler
    {
        Task InitializeAsync();
    }

    /// <summary>
    /// 커맨드 처리자
    /// </summary>
    internal class CommandHandler : ICommandHandler
    {
        #region Fields
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IContextService _contextService;
        #endregion

        #region Constructors
        /// <summary>
        /// <see cref="CommandHandler" />의 새 인스턴스 생성 및 초기화
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="client"></param>
        /// <param name="contextService"></param>
        /// <exception cref="ArgumentNullException" />
        public CommandHandler([NotNull] IServiceProvider services, [NotNull] CommandService commands, [NotNull] DiscordSocketClient client, [NotNull] IContextService contextService)
        {
            _services = services ??
                throw new ArgumentNullException(nameof(services));

            _commands = commands ??
                throw new ArgumentNullException(nameof(commands));

            _client = client ??
                throw new ArgumentNullException(nameof(client));

            _contextService = contextService ??
                throw new ArgumentNullException(nameof(contextService));

            _client.MessageReceived += HandleCommandAsync;
            _commands.CommandExecuted += CommandExecutedAsync;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 초기화
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetExecutingAssembly(), _services);
        }

        /// <summary>
        /// 커맨드 처리
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task HandleCommandAsync(SocketMessage message)
        {
            var userMessage = message as SocketUserMessage;
            var context = new SocketCommandContext(_client, userMessage);

            int argPos = default;

            if (_contextService.IsIgnorableContext(context, ref argPos)) return;

            await _commands.ExecuteAsync(context, argPos, _services);
        }

        /// <summary>
        /// 커맨드가 실행됐을 때
        /// </summary>
        /// <param name="command"></param>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified)
            {
                Console.WriteLine($"Command failed to execute for [{context.User.Username}] <-> [{result.ErrorReason}]");

                return;
            }

            if (result.IsSuccess)
            {
                Console.WriteLine($"Command [{command.Value.Name}] executed for [{context.User.Username}]");

                return;
            }

            await context.Channel.SendMessageAsync($"Sorry, {context.User.Username}... something went wrong -> [{result}]");
        }
        #endregion
    }
}
