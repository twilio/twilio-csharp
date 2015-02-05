using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Api.Tests.Integration
{
    public static class Utilities
    {
        private static readonly Random SingleRandom = new Random();

        public static string MakeRandomFriendlyName(){
            return MakeRandomFriendlyName(32);
        }

        public static string MakeRandomFriendlyName(int length)
        {
            char[] letters = new char[length];
            for (int i = 0; i < length; i++)
            {
                letters[i] = GenerateChar(SingleRandom);
            }
            return new string(letters);            
        }

        private static char GenerateChar(Random rng)
        {
            // 'Z' + 1 because the range is exclusive
            return (char)(rng.Next('A', 'Z' + 1));
        }
    }
}
