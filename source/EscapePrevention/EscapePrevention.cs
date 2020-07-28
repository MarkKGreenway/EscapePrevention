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
        public static string EscPrevent(string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval, bool logErrors = false)
        {
            if (String.IsNullOrEmpty(input)) return String.Empty;
            if (String.IsNullOrWhiteSpace(input)) return String.Empty;
            var selector = new EscapeStrategySelector();
            var retVal = selector.SelectStrategy(kind).Escape(input);
            if (!logErrors)
            {
                return retVal;
            }
            return retVal;
        }

        

        public string Prevent(string input, EscapePreventionKind kind = EscapePreventionKind.UrlSpaceRemoval, bool logErrors = false)
        {
            return EscPrevent(input, kind, logErrors);
        }
    }

    public class Issue
    {
        public string title { get; set; }
        public string body { get; set; }
        public string assignee { get; set; }
        public int milestone { get; set; }
        public string[] labels { get; set; }
    }
}
