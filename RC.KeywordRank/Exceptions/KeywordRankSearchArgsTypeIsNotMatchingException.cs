using System;

namespace RC.KeywordRank.Exceptions
{
    public class KeywordRankSearchArgsTypeIsNotMatchingException : Exception
    {
        public KeywordRankSearchArgsTypeIsNotMatchingException() : base("실시간 검색어 검색 인자 타입이 일치하지 않습니다.") { }
    }
}
