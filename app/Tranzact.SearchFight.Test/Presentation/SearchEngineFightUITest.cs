using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.SearchFight.Test.Presentation
{
    [TestClass]
    public class SearchEngineFightUITest
    {
        [TestMethod]
        public void SplitInput()
        {
            var result = Common.Util.DelimitedString.Split("net \"java script\" java nodejs");
            Assert.AreEqual(4, result.Length);
        }
    }
}
