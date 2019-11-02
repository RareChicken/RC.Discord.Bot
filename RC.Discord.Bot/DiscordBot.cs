using RC.Discord.Bot.Extensions;
using RC.Discord.Bot.Models;
using RC.Discord.Bot.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RC.KeywordRank.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace RC.Discord.Bot
{
    /// <summary>
    /// 디스코드 봇
    /// </summary>
    public sealed class DiscordBot : IDisposable
    {
        #region Fields
        private IServiceProvider _services;
        private BotConfig _config;
        private DiscordSocketClient _client;
        private bool _dispose;
        #endregion

        #region Methods
        /// <summary>
        /// 무한 딜레이로 시작
        /// </summary>
        /// <returns></returns>
        public async Task StartWithInfinityDelayAsync()
        {
            await StartAsync();
            await Task.Delay(-1);
        }

        /// <summary>
        /// 시작
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            _services = ConfigureServices(new ServiceCollection());
            _client = _services.GetRequiredService<DiscordSocketClient>();
            _config = _services.GetRequiredService<BotConfig>();
            _client.Ready += Client_Ready;
            _client.Log += Client_Log;

            // 커맨드 처리자 초기화 진행
            await _services.GetRequiredService<ICommandHandler>().InitializeAsync();
            await _client.LoginAsync(TokenType.Bot, _config.Token, true);
            await _client.StartAsync();
        }

        /// <summary>
        /// 서비스 구성
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddBotConfig()
                .AddKeywordRankServices()
                .AddSingleton<ICommandHandler, CommandHandler>()
                .AddSingleton<IContextService, ContextService>()
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    CaseSensitiveCommands = true,
                    DefaultRunMode = RunMode.Async,
                    LogLevel = LogSeverity.Debug
                }))
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Debug
                }))
                .BuildServiceProvider();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_dispose)
            {
                return;
            }

            if (disposing)
            {
                if (_client != null)
                {
                    _client.Dispose();
                }
            }

            _dispose = true;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// 클라이언트가 준비되었을 때
        /// </summary>
        /// <returns></returns>
        private async Task Client_Ready()
        {
            await _client.SetGameAsync(_config.Game, null, ActivityType.Playing);

            Console.WriteLine($"Connected as -> [{_client.CurrentUser}]");
        }

        /// <summary>
        /// 클라이언트 로그
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        private async Task Client_Log(LogMessage logMessage)
        {
            if (logMessage.Exception is CommandException cmdException)
            {
                await cmdException.Context.Channel.SendMessageAsync("앗... 아아... 뭔가 문제가 생겼습니다. 개발자를 죽봉으로 때려주세요.");

                return;
            }

            Console.WriteLine(logMessage.ToString());
        }
        #endregion
    }
}
