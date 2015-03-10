using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapePrevention.Overhead;

namespace EscapePrevention
{
    public static class EscapePrevention 
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
