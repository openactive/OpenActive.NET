using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.NET
{
    /// <summary>
    /// This interface represents the "common set of properties that capture the basic information" for both
    /// schema:Person and schema:Organization types, as defined in the Modelling Opportunity Data 2.0 and
    /// Open Booking 1.0 specifications
    /// </summary>
    public interface ILegalEntity
    {
        bool IsPerson { get; }
        bool IsOrganization { get; }
        Uri Id { get; set; }
        SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }
        string Name { get; set; }
        string GivenName { get; set; }
        string FamilyName { get; set; }
        string LegalName { get; set; }
        string Email { get; set; }
        TaxMode? TaxMode { get; set; }
        string VatID { get; set; }
        string Telephone { get; set; }
        Uri Url { get; set; }
        ImageObject Logo { get; set; }
        PostalAddress Address { get; set; }
        List<Terms> TermsOfService { get; set; }
        string FormattedDescription { get; set; }
        string Description { get; set; }
        List<Uri> SameAs { get; set; }
        string DisplayName { get; }
        bool? IsOpenBookingAllowed { get; set; }
    }

    public static class LegalEntityConverter
    {
        // Note that the order of "Organization, Person" must match the generated properties that accept ILegalEntity
        public static SingleValues<Organization, Person> GetSingleValues(this ILegalEntity legalEntity)
        {
            switch (legalEntity)
            {
                case Organization organization:
                    return organization;
                case Person person:
                    return person;
                case null:
                    return default;
                default:
                    throw new InvalidCastException($"Supplied ILegalEntity is of unknown type {legalEntity.GetType().ToString()}");
            }
        }
    }
}
