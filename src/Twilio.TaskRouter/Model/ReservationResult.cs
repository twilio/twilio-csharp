using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class ReservationResult: NextGenListBase
    {
        /// <summary>
        /// Gets or sets the reservations.
        /// </summary>
        public List<Reservation> Reservations { get; set; }
    }
}

