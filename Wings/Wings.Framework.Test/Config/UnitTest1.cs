using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wings.Framework.Config;

namespace Wings.Framework.Test.Config
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hostname = WingsConfigurationReader.Instance.EmailHost;
        }
    }
}
