using System;

namespace RC.Discord.Bot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var discordBot = new DiscordBot();
                discordBot.StartWithInfinityDelayAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
