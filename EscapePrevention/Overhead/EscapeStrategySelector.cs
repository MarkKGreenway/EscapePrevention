using System.Collections.Generic;
using System.Linq;
using EscapePrevention.EscapeKinds;

namespace EscapePrevention.Overhead
{
    public class EscapeStrategySelector
    {
        private readonly List<EscapeStrategy> _actionStrategies =
            new List<EscapeStrategy>
            {
                new UrlSpaceRemovalStrategy(),
                   
            };

        public EscapeStrategy SelectStrategy(EscapePreventionKind kind)
        {
            return _actionStrategies.First(x => x.CanBeUsed(kind));
        }
    }
}