using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.TwiML;
using Twilio.TwiML.Tests;

namespace Twilio.Twiml.Tests
{
    [TestClass]
    public class EnqueueTests : TestBase
    {
        [TestMethod]
        public void Can_Generate_Enqueue_With_Name()
        {
            var response = new TwilioResponse();
            response.Enqueue("example");

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Only_Options()
        {
            var response = new TwilioResponse();
            response.Enqueue(new { action = "example.xml", method = "GET", waitUrl = "wait.xml", waitUrlMethod = "GET"});

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Name_And_Options()
        {
            var response = new TwilioResponse();
            response.Enqueue("example", new { action = "example.xml", method = "GET", waitUrl="wait.xml", waitUrlMethod="GET"});

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Options_And_TaskAttributes()
        {
            var response = new TwilioResponse();
            response.Enqueue(new { action = "example.xml", method = "GET", waitUrl = "wait.xml", waitUrlMethod = "GET", workflowSid = "WFXXXXX" }, "{'task':'attributes'}");

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Options_And_TaskAttributes_And_Priority_And_Timeout()
        {
            var response = new TwilioResponse();
            response.Enqueue(new { action = "example.xml", method = "GET", waitUrl = "wait.xml", waitUrlMethod = "GET", workflowSid = "WFXXXXX" }, "{'task':'attributes'}", new {priority="10", timeout="30"});

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Task()
        {
            var response = new TwilioResponse();
            var task = new Task("{'task':'attributes'}", new {priority = "10", timeout = "30"});
            response.EnqueueTask(new { workflowSid = "WFXXXXX" }, task);

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Options_And_TaskAttributes_And_Priority_And_Timeout()
        {
            var response = new TwilioResponse();
            response.Enqueue(new { action = "example.xml", method = "GET", waitUrl = "wait.xml", waitUrlMethod = "GET", workspaceSid = "WSXXXXX" }, "{'task':'attributes'}", new {priority="10", timeout="30"});

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }

        [TestMethod]
        public void Can_Generate_Enqueue_With_Task()
        {
            var response = new TwilioResponse();
            var task = new Task("{'task':'attributes'}", new {priority = "10", timeout = "30"});
            response.EnqueueTask(task);

            Assert.IsTrue(IsValidTwiML(response.ToXDocument()));
        }
    }
}
