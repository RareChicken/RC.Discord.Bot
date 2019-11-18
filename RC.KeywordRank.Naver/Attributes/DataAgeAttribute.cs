using System;

namespace RC.KeywordRank.Attributes
{
    /// <summary>
    /// 나이 데이터 특성
    /// </summary>
    public sealed class DataAgeAttribute : Attribute
    {
        public DataAgeAttribute(string dataAge)
        {
            DataAge = dataAge;
        }

        /// <summary>
        /// 나이 데이터
        /// </summary>
        public string DataAge { get; set; }
    }
}
