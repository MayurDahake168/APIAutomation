using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace Demo
{
    public static class Report
    {
        public static ExtentReports extenReport;
        public static ExtentSparkReporter extentSparkReporter;
        public static ExtentTest extentTest;
        public static void GenExtentReport(string reportName, string reportTitle, dynamic path)
        {
            extentSparkReporter = new ExtentSparkReporter(path);
            extentSparkReporter.Config.Theme = Theme.Standard;
            extentSparkReporter.Config.ReportName = reportName;
            extentSparkReporter.Config.DocumentTitle = reportTitle;

            extenReport = new ExtentReports();
            extenReport.AttachReporter(extentSparkReporter); //Here we are attaching reporter (configuration we done above)

        }
        public static void CreatTest(string testCase)
        {
            extentTest = extenReport.CreateTest(testCase); //Here we are creating test clouln in report
        }
        public static void LogToReport(Status status, string message)
        {
            extentTest.Log(status, message); //Here we are adding/printing textinfo to respective testcase
        }
        public static void FlushReport()
        {
            extenReport.Flush();
        }
        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                extentTest.Pass("testcase is passed");
            }
            else
            {
                extentTest.Fail("testcase is failed");
            }
        }
    }
}
