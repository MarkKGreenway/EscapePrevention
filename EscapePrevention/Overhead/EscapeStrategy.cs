using System;
using System.Text;
using System.Threading.Tasks;

namespace EscapePrevention.Overhead
{
    public abstract class EscapeStrategy
    {
        public abstract string Escape(string input);
        public abstract bool CanBeUsed(EscapePreventionKind kind);
    }
}
