using System;
using System.Threading.Tasks;
using EscapePrevention.Overhead;

namespace EscapePrevention
{
    public static class EscapePreventionExtension
    {
        public static string EscapePrevent(this string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval, bool logErrors = false)
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
            var retVal = selector.SelectStrategy(kind).Escape(input);
            if (!logErrors)
            {
                return retVal;
            }
            return retVal;
        }
    }
}