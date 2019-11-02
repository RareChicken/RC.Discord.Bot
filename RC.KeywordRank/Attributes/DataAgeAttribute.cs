using System;

namespace RC.KeywordRank.Attributes
{
    public class DataAgeAttribute : Attribute
    {
        public DataAgeAttribute(string dataAge)
        {
            DataAge = dataAge;
        }

        public string DataAge { get; set; }
    }
}
