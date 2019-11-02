using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using RC.Discord.Bot.Extensions;
using RC.Discord.Bot.Models;
using System;

namespace RC.Discord.Bot.Tests
{
    /// <summary>
    /// 단위 테스터
    /// </summary>
    public class UnitTester
    {
        public UnitTester()
        {
            Services = ConfigureServices(new ServiceCollection());
        }

        /// <summary>
        /// 서비스들
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// 서비스 구성
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices([NotNull] IServiceCollection services)
        {
            return services
                .AddBotConfig()
                .BuildServiceProvider();
        }

        /// <summary>
        /// 봇 설정 제공
        /// </summary>
        /// <returns></returns>
        public BotConfig GetBotConfig()
        {
            return Services.GetService<BotConfig>();
        }
    }
}
