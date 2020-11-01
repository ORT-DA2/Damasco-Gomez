using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApi.Tests.Test
{
    [TestClass]
    public class StateControllerTest
    {
        [TestInitialize]
        public void initVariables()
        {
        }
        [TestMethod]
        public void TestGetAllStatesOk()
        {
        }

        [TestMethod]
        public void TestGetAllStatesEmpty()
        {
        }
        [TestMethod]
        public void TestGetByOk()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
        }
        
    }
}