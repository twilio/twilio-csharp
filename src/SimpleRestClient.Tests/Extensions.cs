using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleRestClient.Tests
{
    public static class MyAssert
    {
        public static void NotEmpty(ICollection propsExpected)
        {
            Assert.IsNotNull(propsExpected);
            Assert.IsTrue(propsExpected.Count > 0);
        }
    }
}
