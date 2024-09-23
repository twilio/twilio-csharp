
namespace Twilio.Http.BearerToken
{
    /// <summary>
    /// Interface for a Token Manager
    /// </summary>
    public interface TokenManager
    {

        /// <summary>
        /// Fetch/Create an access token
        /// </summary>
        ///
        /// <returns>access token fetched from token endpoint</returns>
        string fetchAccessToken();

    }
}

