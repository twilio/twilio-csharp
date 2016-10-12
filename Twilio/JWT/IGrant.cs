namespace Twilio.JWT
{
    /// <summary>
    /// Grant used in Access Tokens
    /// </summary>
    public interface IGrant
    {
        /// <summary>
        /// Get the name of the grant.
        /// </summary>
        ///
        /// <returns>String - the name of the grant</returns>
        string GetGrantKey();

        /// <summary>
        /// Get the data of the grant
        /// </summary>
        ///
        /// <returns>Object - the data of the grant</returns>
        object GetPayload();
    }
}
