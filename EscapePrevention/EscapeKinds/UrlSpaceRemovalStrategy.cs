using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapePrevention.Overhead;

namespace EscapePrevention.EscapeKinds
{

    class UrlSpaceRemovalStrategy : EscapeStrategy
    {
        public override string Escape(string input)
        {
            var retVal = input;
            retVal = retVal.Replace(" ", "");
            return retVal;
        }

        public override bool CanBeUsed(EscapePreventionKind kind)
        {
            return kind == EscapePreventionKind.UrlSpaceRemoval;
        }
    }


}
