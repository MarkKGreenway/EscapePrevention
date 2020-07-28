using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
