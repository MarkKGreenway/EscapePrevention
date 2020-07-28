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
        public void Verify()
        {
            var list = new Dictionary<string, string>
            {
                {"fELBM*#Yc4&gSf", "fELBMYc4gSf"},
                {"l46Gagns95@5Ee", "l46Gagns955Ee"},
                {"MebT Vo3I", "MebTVo3I"},
                {"xr$y zdxj", "xryzdxj"},
            };
            foreach (var keyValuePair in list)
            {
                var expected = keyValuePair.Value;
                var calc = keyValuePair.Key.EscapePrevent(EscapePreventionKind.UrlSpaceRemoval);
                var test = ""; // HttpUtility.UrlEncode(calc);
                Assert.AreEqual(expected, test);
            }

        }
    }
}
