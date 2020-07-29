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
        public const EscapePreventionKind replace = EscapePreventionKind.UrlSpaceReplacement;
        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebT_Vo3I")]
        [TestCase("xr$y zdxj", "xry_zdxj")]
        public void Bulk(string source, string expected)
        {

                Assert.AreEqual(expected, source.EscapePrevent(replace));
            

        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebT_Vo3I")]
        [TestCase("xr$y zdxj", "xry_zdxj")]
        public void Verify(string source, string expected)
        {
            var calc = source.EscapePrevent(replace);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }
        [Test]
        public void EmptyString()
        {
            var calc = String.Empty.EscapePrevent(replace);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(String.Empty, test);
        }
        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebT_Vo3I")]
        [TestCase("xr$y zdxj", "xry_zdxj")]
     
        public void ObjectPrevent(string source, string expected)
        {
            var prevented = new EscapePrevention.EscapePrevention();
            var calc = prevented.Prevent(source, replace);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }
    }
}