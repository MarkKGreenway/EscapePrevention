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
    }
}
