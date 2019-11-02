using RC.KeywordRank.Attributes;
using RC.KeywordRank.Constants;
using System.ComponentModel;

namespace RC.KeywordRank.Extensions
{
    public static class AgeGroupExtensions
    {
        /// <summary>
        /// 연령대의 DataAge를 제공
        /// </summary>
        /// <param name="ageGroup">연령대</param>
        /// <returns>DataAge</returns>
        public static string GetDataAge(this AgeGroup ageGroup)
        {
            return ageGroup.GetAttributeProperty<DataAgeAttribute, string>((a) => a.DataAge);
        }

        /// <summary>
        /// 연령대 명칭을 제공
        /// </summary>
        /// <param name="ageGroup">연령대</param>
        /// <returns>연령대 명칭</returns>
        public static string GetName(this AgeGroup ageGroup)
        {
            return ageGroup.GetAttributeProperty<DescriptionAttribute, string>((a) => a.Description);
        }
    }
}
