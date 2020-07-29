using System.Collections.Generic;
using EscapePrevention;
using NUnit.Framework;

namespace EscapePrevention_Tests
{

    [TestFixture]
    public class UrlSpaceRemoval
    {
        [Test]
        public void OnlyASpyaceIsEmpt()
        {
            var sut = " ";
            var retVal = sut.EscapePrevent(EscapePreventionKind.UrlSpaceRemoval);
            Assert.AreEqual("", retVal);
        }

        [Test]
        public void SpaceInWords()
        {
            var sut = "key board";
            var retVal = sut.EscapePrevent(EscapePreventionKind.UrlSpaceRemoval);
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
                Assert.AreEqual(keyValuePair.Value, keyValuePair.Key.EscapePrevent(EscapePreventionKind.UrlSpaceRemoval));
            }

        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebTVo3I")]
        [TestCase("xr$y zdxj", "xryzdxj")]
        public void Verify(string source, string expected)
        {
            var calc = source.EscapePrevent(EscapePreventionKind.UrlSpaceRemoval);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }

        [Test]
        [TestCase("fELBM*#Yc4&gSf", "fELBMYc4gSf")]
        [TestCase("l46Gagns95@5Ee", "l46Gagns955Ee")]
        [TestCase("MebT Vo3I", "MebTVo3I")]
        [TestCase("xr$y zdxj", "xryzdxj")]
        public void ObjectVerifyRemoval(string source, string expected)
        {
            var prevented = new EscapePrevention.EscapePrevention();
            var calc = prevented.Prevent(source, EscapePreventionKind.UrlSpaceRemoval);
            var test = System.Net.WebUtility.UrlEncode(calc);
            Assert.AreEqual(expected, test);
        }
    }
}
