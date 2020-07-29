using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapePrevention;
using NUnit.Framework;

namespace EscapePrevention_Tests
{
    [TestFixture]
    public class Smoke
    {
        [Test]
        public void MathTest()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [Test]
        [TestCase(EscapePreventionKind.UrlSpaceRemoval)]
        [TestCase(EscapePreventionKind.UrlSpaceReplacement)]
        [TestCase(EscapePreventionKind.XML)]
        public void EmptyReturnsEmpty(EscapePreventionKind escapePreventionKind)
        {
            var testString = "";
            var expected = String.Empty;
            //Static
            var staticOutput = EscapePrevention.EscapePrevention.EscPrevent(testString, kind: escapePreventionKind);
          

            // Not Static
            var preventer = new EscapePrevention.EscapePrevention();
            var notStaticOutput = preventer.Prevent(testString);


            Assert.AreEqual(expected, staticOutput);
            Assert.AreEqual(expected, notStaticOutput);
        }

        [Test]
        [TestCase(EscapePreventionKind.UrlSpaceRemoval)]
        [TestCase(EscapePreventionKind.UrlSpaceReplacement)]
        [TestCase(EscapePreventionKind.XML)]
        public void WhitespaceReturnsEmpty(EscapePreventionKind escapePreventionKind)
        {
            var testString = " ";
            var expected = String.Empty;
            //Static
            var staticOutput = EscapePrevention.EscapePrevention.EscPrevent(testString, kind: escapePreventionKind);


            // Not Static
            var preventer = new EscapePrevention.EscapePrevention();
            var notStaticOutput = preventer.Prevent(testString);


            Assert.AreEqual(expected, staticOutput);
            Assert.AreEqual(expected, notStaticOutput);

        }
    }
}
