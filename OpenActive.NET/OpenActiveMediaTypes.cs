using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace OpenActive.NET
{
    /// <summary>
    /// MediaTypes for OpenActive
    /// Use MediaTypeHeaderValue.Parse() for compatibility with .NET Framework
    /// </summary>
    public static class OpenActiveMediaTypes
    {
        /// <summary>
        /// Realtime Paged Data Exchange (https://www.openactive.io/realtime-paged-data-exchange/)
        /// </summary>
        public const string RealtimePagedDataExchange = "application/vnd.openactive.rpde+json";

        /// <summary>
        /// Open Booking (https://www.openactive.io/open-booking-api)
        /// </summary>
        public const string OpenBooking = "application/vnd.openactive.booking+json";

        public static class Version1
        {
            /// <summary>
            /// Media type for latest version of Realtime Paged Data Exchange
            /// </summary>
            public const string RealtimePagedDataExchange = OpenActiveMediaTypes.RealtimePagedDataExchange + "; version=1";

            /// <summary>
            /// Media type for latest version of Open Booking API
            /// </summary>
            public const string OpenBooking = OpenActiveMediaTypes.OpenBooking + "; version=1";
        }
    }
}
