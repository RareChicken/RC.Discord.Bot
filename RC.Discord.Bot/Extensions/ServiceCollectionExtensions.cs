using RC.Discord.Bot.Models;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RC.Discord.Bot.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection" />의 확장 메서드를 제공합니다.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// <see cref="BotConfig" />를 추가합니다.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
        public static IServiceCollection AddBotConfig([NotNull] this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("config.json")
                .Build();

            var botConfig = new BotConfig();
            config.Bind(botConfig);

            return services.AddSingleton(botConfig);
        }
    }
}
