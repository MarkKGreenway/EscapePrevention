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
        public void Bulk()
        {
            var list = new Dictionary<string, string>
            {
                {"fELBM*#Yc4&gSf", "fELBMYc4gSf"},
                {"l46Gagns95@5Ee", "l46Gagns955Ee"},
                {"MebT Vo3I", "MebT_Vo3I"},
                {"xr$y zdxj", "xry_zdxj"},
            };
            foreach (var keyValuePair in list)
            {
                Assert.AreEqual(keyValuePair.Value, keyValuePair.Key.EscapePrevent(EscapePreventionKind.UrlSpaceReplacement));
            }

        }

        [Test]
        public void Verify()
        {
            var list = new Dictionary<string, string>
            {
                {"fELBM*#Yc4&gSf", "fELBMYc4gSf"},
                {"l46Gagns95@5Ee", "l46Gagns955Ee"},
                {"MebT Vo3I", "MebT_Vo3I"},
                {"xr$y zdxj", "xry_zdxj"},
            };
            foreach (var keyValuePair in list)
            {
                var expected = keyValuePair.Value;
                var calc = keyValuePair.Key.EscapePrevent(EscapePreventionKind.UrlSpaceReplacement);
                var test = ""; // HttpUtility.UrlEncode(calc);
                Assert.AreEqual(expected, test);
            }

        }

    }
}