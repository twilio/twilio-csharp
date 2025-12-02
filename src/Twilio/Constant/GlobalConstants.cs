using System.Collections.Generic;

namespace Twilio
{
    public static class GlobalConstants
    {
        public static readonly Dictionary<string, string> RegionToEdgeMap = new Dictionary<string, string>
        {
            { "au1", "sydney" },
            { "br1", "sao-paulo" },
            { "de1", "frankfurt" },
            { "ie1", "dublin" },
            { "jp1", "tokyo" },
            { "jp2", "osaka" },
            { "sg1", "singapore" },
            { "us1", "ashburn" },
            { "us2", "umatilla" }
        };
        public static bool IsOnlyOneSet(string edge, string region)
        {
            return (string.IsNullOrEmpty(edge) && !string.IsNullOrEmpty(region)) ||
                   (string.IsNullOrEmpty(region) && !string.IsNullOrEmpty(edge));
        }
    }
}
