using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SimpleRestClient.Tests
{
    public class RequestBodyCapturer
    {
        public const string VALIDATE_DEFAULTPARAMETER_HEADER = "ValidateDefaultParameterHeader";
        public const string VALIDATE_DEFAULTPARAMETER_URLSEGMENT = "ValidateDefaultParameterUrlSegment";
        public const string VALIDATE_GET_METHOD_PARAMETERS = "ValidateGetMethodParameters";
        public const string VALIDATE_POST_METHOD_PARAMETERS = "ValidatePostMethodParameters";
        public const string VALIDATE_POST_METHOD_CONTENTYPE = "ValidatePostMethodContentType";

        public const string VALIDATE_OBJECT_DESERIALIZATION = "ValidateObjectDeserialization";
        public const string VALIDATE_OBJECT_DESERIALIZATION_FAILURE = "ValidateObjectDeserializationFailure";

        public const string VALIDATE_AUTHORIZATION_FAILURE = "ValidateAuthorizationFailure";
        public const string VALIDATE_BADREQUEST_FAILURE = "ValidateBadRequestFailure";

        public const string VALIDATE_REQUEST_TIMEOUT = "ValidateRequestTimeout";
        public const string VALIDATE_REQUEST_CANCELED = "ValidateRequestCanceled";

        public static string CapturedResourceLocation { get; set; }

        public static string CapturedContentType { get; set; }

        public static bool CapturedHasEntityBody { get; set; }
        public static string CapturedEntityBody { get; set; }

        public static bool CapturedHasBasicAuthenticationHeader { get; set; }
        public static string CapturedBasicAuthenticationHeaderValue { get; set; }


        public static void ValidateDefaultParameterHeader(HttpListenerContext context)
        {
            var request = context.Request;

            CapturedHasBasicAuthenticationHeader = request.Headers.AllKeys.Contains("Authorization");
            CapturedBasicAuthenticationHeaderValue = request.Headers["Authorization"];
        }

        public static void ValidateAuthorizationFailure(HttpListenerContext context)
        {
            context.Response.StatusCode = 401;
            context.Response.StatusDescription = "Unauthorized";
        }

        public static void ValidateBadRequestFailure(HttpListenerContext context)
        {
            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "Bad Request";

            var test = new Test() { Foo = "12345", Bar = "abcde" };

            var content = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            byte[] bytes = System.Text.ASCIIEncoding.Default.GetBytes(content);

            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        public static void ValidateDefaultParameterUrlSegment(HttpListenerContext context)
        {
            var request = context.Request;

            CapturedResourceLocation = request.Url.ToString();
        }

        public static void ValidateGetMethodParameters(HttpListenerContext context)
        {
            var request = context.Request;

            CapturedResourceLocation = request.Url.ToString();
        }

        public static void ValidatePostMethodParameters(HttpListenerContext context)
        {
            var request = context.Request;

            CapturedHasEntityBody = request.HasEntityBody;
            CapturedEntityBody = StreamToString(request.InputStream);
        }

        public static void ValidatePostMethodContentType(HttpListenerContext context)
        {
            var request = context.Request;

            CapturedContentType = request.ContentType;
        }

        public static void ValidateObjectDeserialization(HttpListenerContext context)
        {
            var test = new Test() { Foo = "12345", Bar = "abcde" };

            var content = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            byte[] bytes = System.Text.ASCIIEncoding.Default.GetBytes(content);

            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        public static void ValidateObjectDeserializationFailure(HttpListenerContext context)
        {
            var test = new { A = "12345", B = "abcde" };

            var content = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            byte[] bytes = System.Text.ASCIIEncoding.Default.GetBytes(content);

            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        public static void ValidateRequestTimeout(HttpListenerContext context)
        {
            System.Threading.Thread.Sleep(10000);
        }

        public static void ValidateRequestCanceled(HttpListenerContext context)
        {
            System.Threading.Thread.Sleep(30000);
        }

        private static string StreamToString(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}
