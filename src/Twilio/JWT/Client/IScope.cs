using System;

namespace Twilio.Jwt
{
    /// <summary>
    /// Scope interface of client capabilities
    /// </summary>
    public interface IScope
    {
        /// <summary>
        /// Generate the scope payload
        /// </summary>
        string Payload { get; }
    }
}
