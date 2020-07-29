using System;
using System.Collections.Generic;
using System.Web;
using EscapePrevention;
using NUnit.Framework;

namespace EscapePrevention_Tests
{
    [TestFixture]
    public class UrlSpaceReplacementTests
    {
        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebT_Vo3I")]
        [TestCase("xr$y zdxj", "xry_zdxj")]
        public void Bulk(string source, string expected)
        {

                Assert.AreEqual(expected, source.EscapePrevent(EscapePreventionKind.UrlSpaceReplacement));
            

        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebT_Vo3I")]
        [TestCase("xr$y zdxj", "xry_zdxj")]
        public void Verify(string source, string expected)
        {
            var calc = source.EscapePrevent(EscapePreventionKind.UrlSpaceReplacement);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }

    }
}