/*using System;
using System.Collections.Generic;
using System.Text;
using Schema.NET;

namespace OpenActive.NET
{
    static class LegendSystem
    {
        public static Controller(request)
        {
            //Separate library / dll for unit testing OpenActive.NET.Mocks
            // Different Mock class for different endpoints
            OpenBookingMock.GenerateBasicOrderQuote()

            //For use in each request, can throw exception, and listener can pick it up and transform it and log it
            // Include interface as well as concrete implementation, so it can be overridden if need
            // Do this for use with dependency injection framework
            // Throw custom exception including error
            // Better not to use NRules as it'll need custom attributes on model classes
            // Custom code is likely better with attributes
            OpenBookingValidator.ValidateRequest(OrderQuoteC1, request);
            // Could be better as many classes, easier to manage
            OpenBookingC1Validator.ValidateRequest(request);

            response = ...request ...;

            //For use in each request, return 500 / log as system error if errors occur
            // Include a different class of exception in response errors than in request errors
            // To allow listener to react differently
            OpenBookingValidator.ValidateResponse(OrderQuoteC1, request, response);
        }
    }

   
}
*/