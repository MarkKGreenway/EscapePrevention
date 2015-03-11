using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EscapePrevention.Overhead;

namespace EscapePrevention.EscapeKinds
{
    public class UrlEscapeStrategy : EscapeStrategy
    {
        private readonly EscapePreventionKind _kind;
        private readonly string _spaceReplacement;

        private static readonly Regex FullStrip = new Regex("[a-zA-Z0-9]");
        private static readonly Regex NotFullStrip = new Regex("[a-zA-Z0-9_]");
        public UrlEscapeStrategy(EscapePreventionKind kind, string spaceReplacement)
        {
            _kind = kind;
            _spaceReplacement = spaceReplacement;
        }
        public override string Escape(string input)
        {
            if (String.IsNullOrEmpty(_spaceReplacement))
            {
                return Remove(input, FullStrip);
            }
            return Replace(input);
        }

        private string Replace(string input)
        {
            return Remove(input.Replace(" ", _spaceReplacement), NotFullStrip);
        }

        private static string Remove(string input, Regex regex)
        {
            return String.Join("", regex.Matches(input).Cast<Match>().Select(match => match.Value));
        }

        public override bool CanBeUsed(EscapePreventionKind kind)
        {
            return kind == _kind;
        }
    }
}