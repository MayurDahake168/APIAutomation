using System;
using System.Collections.Generic;
using System.IO;
using AventStack.ExtentReports;
using Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace APITestScript
{
    [TestClass]
    public class UnitTest1
    {
    //    public TestContext TestContext { get; set; }

    //    //ClassInialization call only once 

    //    [ClassInitialize] //Here we are calling method declacred in Report class and passing value to them
    //    public void SetUp(TestContext context)
    //    {
    //        var dir = TestContext.TestRunDirectory;
    //        Report.GenExtentReport("API Unit Test", "APITestReport", dir);
    //    }

    //    //TestInitiazation calls once before every testmethod

    //    [TestInitialize] //Here we are calling method declacred in Report class and passing value to them
    //    public void CreatTest(TestContext context)
    //    {
    //        Report.CreatTest(TestContext.TestName);
    //    }



        [TestMethod]
        public void GetUser()
        {
            var demo = new TestMethods();
            var respone = demo.GetUsersTestDriven();
            Assert.AreEqual(2, respone.Page);
            Assert.AreEqual("Michael", respone.Data[0].first_name);
            Assert.AreEqual("Lawson", respone.Data[0].last_name);
            Assert.AreEqual("Lindsay", respone.Data[1].first_name);
        }
        [TestMethod]
        public void CreateUser()
        {
            string playlod = @"{
                 ""name"": ""mayur"",
                 ""job"": ""leadery""
                   
            }";
            var demo = new TestMethods();
            var respone = demo.CreateUserTestDriven(playlod);
            Assert.AreEqual("mayur", respone.Name);
            Assert.AreEqual("leadery", respone.Job);
        }
        [TestMethod]
        public void UpdateUser()
        {
            string playlod = @"{
                 ""name"": ""mayurdahake"",
                 ""job"": ""leader""
            }";
            var demo = new TestMethods();
            var respone = demo.UpdateUserTestDriven(playlod);
            Assert.AreEqual("mayurdahake", respone.Name);
            Assert.AreEqual("leader", respone.Job);
        }
        [TestMethod]
        public void DeleteUser()
        {
            var demo = new TestMethods();
            var respone = demo.DeleteUsersTestDriven();
        }

        //[TestCleanup]

        //public void TestCleanup(TestContext context)
        //{
        //    var teststatus = TestContext.CurrentTestOutcome;
        //    Status logStatus;

        //    switch (teststatus)
        //    {
        //        case UnitTestOutcome.Passed:
        //            break;
        //        case UnitTestOutcome.Failed:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //[ClassCleanup]
        //public void GenReport()
        //{
        //    Report.FlushReport();
        //}
        

        [TestMethod]
      
        public void  CreateUserFromJsonFile( )
        {
            var contents = File.ReadAllText("TestData\\TestJSONData.json");
            var payload = JsonConvert.DeserializeObject<PostUserDTO>(contents);
            var demo = new TestMethods();
            var respone = demo.CreateUserDataDriven(payload);
            Assert.AreEqual(payload.Name, respone.Name);
            Assert.AreEqual(payload.Job, respone.Job);
        }
    }

}




