using Xunit;

namespace RC.Discord.Bot.Tests
{
    /// <summary>
    /// 디스코드 봇 단위 테스터
    /// </summary>
    public class DiscordBotUnitTester : UnitTester
    {
        private readonly DiscordBot _bot;

        public DiscordBotUnitTester()
        {
            _bot = new DiscordBot();
            _bot.StartAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public void BotConfigTest()
        {
            var config = GetBotConfig();

            Assert.NotNull(config);
        }
    }
}
