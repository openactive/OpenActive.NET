using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace OpenActive.NET
{
    /// <summary>
    /// MediaTypes for OpenActive
    /// </summary>
    public static class OpenActiveMediaTypes
    {
        /// <summary>
        /// Open Booking (https://www.openactive.io/open-booking-api)
        /// </summary>
        public static class OpenBooking
        {
            /// <summary>
            /// Media type for Open Booking API, with no version specified
            /// </summary>
            public const string Versionless = "application/vnd.openactive.booking+json";

            /// <summary>
            /// Media type for latest version of Open Booking API
            /// </summary>
            public const string Version1 = Versionless + "; version=1";
        }

        /// <summary>
        /// Realtime Paged Data Exchange (https://www.openactive.io/realtime-paged-data-exchange/)
        /// </summary>
        public static class RealtimePagedDataExchange
        {
            /// <summary>
            /// Media type for Realtime Paged Data Exchange, with no version specified
            /// </summary>
            public const string Versionless = "application/vnd.openactive.rpde+json";

            /// <summary>
            /// Media type for latest version of Realtime Paged Data Exchange
            /// </summary>
            public const string Version1 = Versionless + "; version=1";
        }
    }
}
