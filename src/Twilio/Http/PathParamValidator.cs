using Twilio.Exceptions;

namespace Twilio.Http
{
    /// <summary>
    /// Validates caller-supplied path parameters before they are substituted into a request path.
    /// </summary>
    public static class PathParamValidator
    {
        /// <summary>
        /// Returns the value unchanged if it is safe to use as a single path segment.
        /// </summary>
        /// <param name="value">Path parameter value</param>
        /// <returns>The unchanged value</returns>
        /// <exception cref="ApiException">If the value is null, empty, "." or "..", or contains '/', '?' or '#'</exception>
        public static string Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "." || value == ".."
                || value.IndexOf('/') >= 0 || value.IndexOf('?') >= 0 || value.IndexOf('#') >= 0)
            {
                throw new ApiException("Invalid path parameter: must not be empty, '.', '..' or contain '/', '?', '#'");
            }
            return value;
        }
    }
}
