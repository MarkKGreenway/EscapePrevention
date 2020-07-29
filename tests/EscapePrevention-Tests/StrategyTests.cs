using System;
using System.Collections.Generic;
using System.Text;
using EscapePrevention;
using EscapePrevention.EscapeKinds;
using NUnit.Framework;

namespace EscapePrevention_Tests
{
    [TestFixture]
    public class StrategyTests
    {
        [TestCase(EscapePreventionKind.UrlSpaceRemoval)]
        [TestCase(EscapePreventionKind.UrlSpaceReplacement)]
        [TestCase(EscapePreventionKind.XML)]
        public void StrategyCanBeUsedWhenItMatches(EscapePreventionKind escapePreventionKind)
        {
            var strat = new UrlEscapeStrategy(escapePreventionKind, "");

            Assert.IsTrue(strat.CanBeUsed(escapePreventionKind));
        }

        [TestCase(EscapePreventionKind.UrlSpaceRemoval, EscapePreventionKind.XML)]
        [TestCase(EscapePreventionKind.UrlSpaceReplacement, EscapePreventionKind.XML)]
        [TestCase(EscapePreventionKind.XML, EscapePreventionKind.UrlSpaceReplacement)]
        public void StrategyCannotBeUsedWhenItsDifferent(EscapePreventionKind escapePreventionKind, EscapePreventionKind notMatch)
        {
            var strat = new UrlEscapeStrategy(escapePreventionKind, "");

            Assert.IsFalse(strat.CanBeUsed(notMatch));
        }
    }
}
