using Newtonsoft.Json;

namespace RC.Discord.Bot.Models
{
    /// <summary>
    /// 봇 설정
    /// </summary>
    public class BotConfig
    {
        /// <summary>
        /// 토큰
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 접두사
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// 게임
        /// </summary>
        [JsonProperty("game")]
        public string Game { get; set; }

        /// <summary>
        /// 프로젝트 깃허브 주소
        /// </summary>
        [JsonProperty("github")]
        public string Github { get; set; }
    }
}
