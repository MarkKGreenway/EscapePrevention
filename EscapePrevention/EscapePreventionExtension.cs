using System;
using EscapePrevention.Overhead;

namespace EscapePrevention
{
    public static class EscapePreventionExtension
    {
        public static string EscapePrevent(this string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }
            if (String.IsNullOrWhiteSpace(input))
            {
                return String.Empty;
            }
            var selector = new EscapeStrategySelector();
            return selector.SelectStrategy(kind).Escape(input);
        }
    }
}