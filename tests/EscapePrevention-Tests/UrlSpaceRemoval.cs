using System;
using System.Collections.Generic;
using EscapePrevention;
using NUnit.Framework;

namespace EscapePrevention_Tests
{

    [TestFixture]
    public class UrlSpaceRemoval
    {
        public const EscapePreventionKind remove = EscapePreventionKind.UrlSpaceRemoval;
        [Test]
        public void OnlyASpyaceIsEmpt()
        {
            var sut = " ";
            var retVal = sut.EscapePrevent(remove);
            Assert.AreEqual("", retVal);
        }

        [Test]
        public void SpaceInWords()
        {
            var sut = "key board";
            var retVal = sut.EscapePrevent(remove);
            Assert.AreEqual("keyboard", retVal);
        }

        [Test]
        public void Bulk()
        {
            var list = new Dictionary<string, string>
            {
                {"fELBM*#Yc4&gSf", "fELBMYc4gSf"},
                {"l46Gagns95@5Ee", "l46Gagns955Ee"},
                {"MebTVo3I", "MebTVo3I"},
                {"xr$yzdxj", "xryzdxj"},
            };
            foreach (var keyValuePair in list)
            {
                Assert.AreEqual(keyValuePair.Value, keyValuePair.Key.EscapePrevent(remove));
            }

        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebTVo3I")]
        [TestCase("xr$y zdxj", "xryzdxj")]
        public void Verify(string source, string expected)
        {
            var calc = source.EscapePrevent(remove);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }

        [Test]
        public void EmptyString()
        {
            var calc = String.Empty.EscapePrevent(remove);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(String.Empty, test);
        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebTVo3I")]
        [TestCase("xr$y zdxj", "xryzdxj")]
        public void ObjectVerifyRemoval(string source, string expected)
        {
            var prevented = new EscapePrevention.EscapePrevention();
            var calc = prevented.Prevent(source, remove);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }
    }
}
