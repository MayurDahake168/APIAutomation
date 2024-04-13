using System;
using Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using NUnit.Framework;
//using Assert = NUnit.Framework.Assert;

namespace APITestScript
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUser()
        {
            var demo = new TestMethods();
            var respone = demo.GetUsers();
            Assert.AreEqual(2, respone.Page);
            Assert.AreEqual("Michael", respone.Data[0].first_name);
            Assert.AreEqual("Lawson", respone.Data[0].last_name);
        }
        [TestMethod]
        public void CreateUser()
        {
            string playlod = @"{
                 ""name"": ""mayur"",
                 ""job"": ""leader""
            }";
            var demo = new TestMethods();
            var respone = demo.CreateUser(playlod);
            Assert.AreEqual("mayur", respone.Name);
            Assert.AreEqual("leader", respone.Job);
        }
        [TestMethod]
        public void UpdateUser()
        {
            string playlod = @"{
                 ""name"": ""mayurdahake"",
                 ""job"": ""leader""
            }";
            var demo = new TestMethods();
            var respone = demo.UpdateUser(playlod);
            Assert.AreEqual("mayurdahake", respone.Name);
            Assert.AreEqual("leader", respone.Job);
        }
        [TestMethod]
        public void DeleteUser()
        {
            var demo = new TestMethods();
            var respone = demo.DeleteUsers();
        }
    }
}
