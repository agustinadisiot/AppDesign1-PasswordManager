﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Assert.AreEqual(1, unaCalculadora.Sumar("1"));
        }
    }
}
