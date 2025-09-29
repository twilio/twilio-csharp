namespace Twilio.Types
{
    /// <summary>
    /// App Endpoint
    /// </summary>
    public class App : IEndpoint
    {
        public const string PREFIX = "app:";

        private readonly string _app;

        /// <summary>
        /// Create new app
        /// </summary>
        /// <param name="app">App name</param>
        public App(string app)
        {
            if (!app.ToLower().StartsWith(PREFIX))
            {
                app = PREFIX + app;
            }

            _app = app;
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _app;
        }
    }
}
