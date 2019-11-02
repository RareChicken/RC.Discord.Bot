using Xunit;

namespace RC.Discord.Bot.Tests
{
    /// <summary>
    /// ���ڵ� �� ���� �׽���
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
