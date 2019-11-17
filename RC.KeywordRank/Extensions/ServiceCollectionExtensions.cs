using JetBrains.Annotations;
using RC.KeywordRank.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RC.KeywordRank.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection" />의 확장 메서드를 제공합니다.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// <see cref="RC.KeywordRank" /> 어셈블리의 서비스들을 추가합니다.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
        public static IServiceCollection AddKeywordRankServices([NotNull] this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services
                .AddSingleton<IKeywordRank, KeywordRank>()
                .AddSingleton<INaverKeywordRankParser, NaverKeywordRankParser>();
        }
    }
}
