using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Exceptions;

namespace Twilio.Tests.Exceptions
{
    [TestFixture]
    public class ApiStandardExceptionTest
    {
        [Test]
        public void TestCreateWithMessageAndInnerException()
        {
            var innerException = new InvalidOperationException("Inner error");
            var exception = new ApiStandardException("Outer error message", innerException);

            Assert.AreEqual("Outer error message", exception.Message);
            Assert.AreEqual(innerException, exception.InnerException);
            Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
        }

        [Test]
        public void TestCreateWithAllRfc9457Fields()
        {
            var errors = new List<ErrorDetail>
            {
                new ErrorDetail { Detail = "Field is required", Pointer = "#/From" }
            };

            var exception = new ApiStandardException(
                code: 20001,
                status: 400,
                type: "https://www.twilio.com/docs/errors/20001",
                title: "Bad Request",
                detail: "The request was invalid",
                instance: "/Accounts/AC123/Messages",
                errors: errors
            );

            Assert.AreEqual(20001, exception.Code);
            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual("https://www.twilio.com/docs/errors/20001", exception.Type);
            Assert.AreEqual("Bad Request", exception.Title);
            Assert.AreEqual("The request was invalid", exception.Detail);
            Assert.AreEqual("The request was invalid", exception.Message);
            Assert.AreEqual("/Accounts/AC123/Messages", exception.Instance);
            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(1, exception.Errors.Count);
            Assert.AreEqual("Field is required", exception.Errors[0].Detail);
            Assert.AreEqual("#/From", exception.Errors[0].Pointer);
        }

        [Test]
        public void TestCreateWithNullOptionalFields()
        {
            var exception = new ApiStandardException(
                code: 20001,
                status: 400,
                type: "https://example.com/error",
                title: "Bad Request",
                detail: null,
                instance: null,
                errors: null
            );

            Assert.AreEqual(20001, exception.Code);
            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual("https://example.com/error", exception.Type);
            Assert.AreEqual("Bad Request", exception.Title);
            Assert.IsNull(exception.Detail);
            Assert.AreEqual("Bad Request", exception.Message); // Falls back to Title when Detail is null
            Assert.IsNull(exception.Instance);
            Assert.IsNull(exception.Errors);
        }

        [Test]
        public void TestDetailProperty()
        {
            var exception = new ApiStandardException(
                code: 20001,
                status: 400,
                type: "https://example.com/error",
                title: "Bad Request",
                detail: "The 'From' parameter is required but was not provided.",
                instance: "/Accounts/AC123/Messages",
                errors: null
            );

            Assert.AreEqual("The 'From' parameter is required but was not provided.", exception.Detail);
            Assert.AreEqual("The 'From' parameter is required but was not provided.", exception.Message);
        }

        [Test]
        public void TestMessageFallsBackToTitleWhenDetailIsNull()
        {
            var exception = new ApiStandardException(
                code: 20001,
                status: 400,
                type: "https://example.com/error",
                title: "Bad Request",
                detail: null,
                instance: null,
                errors: null
            );

            Assert.IsNull(exception.Detail);
            Assert.AreEqual("Bad Request", exception.Message);
        }

        [Test]
        public void TestCreateWithMultipleValidationErrors()
        {
            var errors = new List<ErrorDetail>
            {
                new ErrorDetail { Detail = "The 'From' parameter is required", Pointer = "#/From" },
                new ErrorDetail { Detail = "The 'To' parameter must be a valid phone number", Pointer = "#/To" },
                new ErrorDetail { Detail = "The 'Body' parameter cannot exceed 1600 characters", Pointer = "#/Body" }
            };

            var exception = new ApiStandardException(
                code: 21211,
                status: 422,
                type: "https://www.twilio.com/docs/errors/validation",
                title: "Unprocessable Entity",
                detail: "Validation failed",
                instance: "/Accounts/AC123/Messages/MM456",
                errors: errors
            );

            Assert.AreEqual("Validation failed", exception.Detail);
            Assert.AreEqual(3, exception.Errors.Count);
            Assert.AreEqual("#/From", exception.Errors[0].Pointer);
            Assert.AreEqual("#/To", exception.Errors[1].Pointer);
            Assert.AreEqual("#/Body", exception.Errors[2].Pointer);
        }

        [Test]
        public void TestCreateWithInnerException()
        {
            var innerException = new InvalidOperationException("Original error");

            var exception = new ApiStandardException(
                code: 20500,
                status: 500,
                type: "https://www.twilio.com/docs/errors/20500",
                title: "Internal Server Error",
                detail: "Internal server error",
                instance: null,
                errors: null,
                exception: innerException
            );

            Assert.AreEqual(innerException, exception.InnerException);
            Assert.AreEqual("Original error", exception.InnerException.Message);
        }

        [Test]
        public void TestInheritsFromTwilioException()
        {
            var exception = new ApiStandardException("Test");

            Assert.IsInstanceOf<TwilioException>(exception);
            Assert.IsInstanceOf<Exception>(exception);
        }

        [Test]
        public void TestErrorDetailProperties()
        {
            var errorDetail = new ErrorDetail
            {
                Detail = "The 'From' parameter is required but was not provided.",
                Pointer = "#/From"
            };

            Assert.AreEqual("The 'From' parameter is required but was not provided.", errorDetail.Detail);
            Assert.AreEqual("#/From", errorDetail.Pointer);
        }

        [Test]
        public void TestEmptyErrorsList()
        {
            var exception = new ApiStandardException(
                code: 20001,
                status: 400,
                type: "https://example.com/error",
                title: "Error",
                detail: "Error occurred",
                instance: null,
                errors: new List<ErrorDetail>()
            );

            Assert.IsNotNull(exception.Errors);
            Assert.AreEqual(0, exception.Errors.Count);
        }

        [Test]
        public void TestCanBeCaughtAsTwilioException()
        {
            try
            {
                throw new ApiStandardException(
                    code: 20001,
                    status: 400,
                    type: "https://example.com/error",
                    title: "Bad Request",
                    detail: "Test error",
                    instance: null,
                    errors: null
                );
            }
            catch (TwilioException ex)
            {
                Assert.AreEqual("Test error", ex.Message);
                Assert.IsInstanceOf<ApiStandardException>(ex);
            }
        }
    }
}
