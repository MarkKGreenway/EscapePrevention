using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapePrevention.EscapeKinds
{
    public class UrlSpaceRemovalStrategy : UrlEscapeStrategy
    {
        public UrlSpaceRemovalStrategy() : base(EscapePreventionKind.UrlSpaceRemoval, "")
        {}
    }
}
