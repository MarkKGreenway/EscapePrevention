using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapePrevention.Overhead;

namespace EscapePrevention
{
    public class EscapePrevention
    {
        public static string EscapePrevent(string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval)
        {
            if (String.IsNullOrEmpty(input)) return String.Empty;
            if (String.IsNullOrWhiteSpace(input)) return String.Empty;
            var selector = new EscapeStrategySelector();
            return selector.SelectStrategy(kind).Escape(input);
        }

        public string Prevent(string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval)
        {
            return EscapePrevent(input, kind);
        }
    }
}
