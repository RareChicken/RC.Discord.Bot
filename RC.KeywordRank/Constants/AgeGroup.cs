using RC.KeywordRank.Attributes;
using System.ComponentModel;

namespace RC.KeywordRank.Constants
{
    /// <summary>
    /// 연령대
    /// </summary>
    public enum AgeGroup
    {
        /// <summary>
        /// 전체 연령대
        /// </summary>
        [DataAge("all")]
        [Description("전체 연령대")]
        AllAges,

        /// <summary>
        /// 10대
        /// </summary>
        [DataAge("10s")]
        [Description("10대")]
        Teens,

        /// <summary>
        /// 20대
        /// </summary>
        [DataAge("20s")]
        [Description("20대")]
        Twenties,

        /// <summary>
        /// 30대
        /// </summary>
        [DataAge("30s")]
        [Description("30대")]
        Thirties,

        /// <summary>
        /// 40대
        /// </summary>
        [DataAge("40s")]
        [Description("40대")]
        Fourties,

        /// <summary>
        /// 50대 이상
        /// </summary>
        [DataAge("50s")]
        [Description("50대 이상")]
        OverFifty
    }
}
