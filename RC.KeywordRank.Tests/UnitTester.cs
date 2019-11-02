using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using RC.KeywordRank.Extensions;
using System;

namespace RC.KeywordRank.Tests
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
        /// <exception cref="ArgumentNullException" />
        public IServiceProvider ConfigureServices([NotNull] IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services
                .AddKeywordRankServices()
                .BuildServiceProvider();
        }

        /// <summary>
        /// 키워드 순위 제공자 제공
        /// </summary>
        /// <returns></returns>
        public IKeywordRankProvider GetKeywordRankProvider()
        {
            return Services.GetService<IKeywordRankProvider>();
        }
    }
}
