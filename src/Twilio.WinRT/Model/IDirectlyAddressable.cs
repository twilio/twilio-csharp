using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public interface IDirectlyAddressable
    {
        string Sid { get; set; }
    }
}
