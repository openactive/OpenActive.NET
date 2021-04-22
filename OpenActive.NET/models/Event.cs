using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Event, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Event : Schema.NET.Event
    {
        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// This method overrides Schema.NET ToString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents the JSON-LD representation of this instance.</returns>
        public override string ToString()
        {
            return OpenActiveSerializer.Serialize(this);
        }

        /// <summary>
        /// Returns the JSON-LD representation of this instance, including "https://schema.org" in the "@context".
        ///
        /// This method must be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// 
        /// This method overrides Schema.NET ToHtmlEscapedString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public new string ToHtmlEscapedString()
        {
            return OpenActiveSerializer.SerializeToHtmlEmbeddableString(this);
        }

        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Event";

        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }

        /// <summary>
        /// The name of the event
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the event, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "A fast paced game that incorporates netball, handball and football."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }

        /// <summary>
        /// Provide additional, specific documentation for participants about how disabilities are, or can be supported at the Event.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessibilityInformation": "This route has been British Cycling assessed as an accessible route, meaning it is suitable for the majority of adaptive bikes. The route will have no or low levels of traffic, there will be plenty of space and will have a good surface throughout. If you have any questions about using this route on an adaptive bike on this ride, please use visit https://www.letsride.co.uk/accessibility or call 0123 456 7000 and ask for the Recreation team."
        /// </code>
        /// </example>
        [DataMember(Name = "accessibilityInformation", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AccessibilityInformation { get; set; }

        /// <summary>
        /// Used to specify the types of disabilities or impairments that are supported at an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessibilitySupport": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://openactive.io/accessibility-support#1393f2dc-3fcc-4be9-a99f-f1e51f5ad277",
        ///     "prefLabel": "Visual impairment",
        ///     "inScheme": "https://openactive.io/accessibility-support"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "accessibilitySupport", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> AccessibilitySupport { get; set; }

        /// <summary>
        /// Specifies the physical activity or activities that will take place during an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "activity": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://openactive.io/activity-list#5e78bcbe-36db-425a-9064-bf96d09cc351",
        ///     "prefLabel": "Bodypump™",
        ///     "inScheme": "https://openactive.io/activity-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "activity", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> Activity { get; set; }

        /// <summary>
        /// Free text restrictions that must be displayed prominently to the user before booking. This property must only contain restrictions not described by `oa:ageRestriction` or `oa:genderRestriction`.
        /// </summary>
        /// <example>
        /// <code>
        /// "additionalAdmissionRestriction": [
        ///   "Participants younger than 12 must be accompanied by an adult",
        ///   "Participants must be comfortable standing for long periods of time"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "additionalAdmissionRestriction", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<string> AdditionalAdmissionRestriction { get; set; }

        /// <summary>
        /// Indicates that an event is recommended as being suitable for or is targetted at a specific age range.
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRange": {
        ///   "@type": "QuantitativeValue",
        ///   "minValue": 50,
        ///   "maxValue": 60
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRange", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue AgeRange { get; set; }

        /// <summary>
        /// The enforced attendee age range requirement of the Event or Offer, that must be displayed prominently to the user before booking.
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRestriction": {
        ///   "@type": "QuantitativeValue",
        ///   "minValue": 15,
        ///   "maxValue": 60
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRestriction", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue AgeRestriction { get; set; }

        /// <summary>
        /// Provides additional notes and instructions for event attendees, for example more information on how to find the event, what to bring, etc. The value of this property must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "attendeeInstructions": "Ensure you bring trainers and a bottle of water."
        /// </code>
        /// </example>
        [DataMember(Name = "attendeeInstructions", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AttendeeInstructions { get; set; }

        /// <summary>
        /// The channels through which a booking can be made.
        /// </summary>
        [DataMember(Name = "bookingChannel", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<BookingChannelType> BookingChannel { get; set; }

        /// <summary>
        /// Provides a set of tags that help categorise and describe an event, e.g. its intensity, purpose, etc.
        /// </summary>
        /// <example>
        /// <code>
        /// "category": [
        ///   "High Intensity"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "category", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<List<string>, List<Concept>> Category { get; set; }

        /// <summary>
        /// A Person who contributes to the facilitation of the Event.
        /// </summary>
        /// <example>
        /// <code>
        /// "contributor": [
        ///   {
        ///     "@type": "Person",
        ///     "familyName": "Smith",
        ///     "givenName": "Nicole",
        ///     "@id": "https://example.com/locations/1234ABCD/leaders/89",
        ///     "identifier": 89
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "contributor", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Person> Contributor { get; set; }

        /// <summary>
        /// The duration of the event given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new virtual TimeSpan? Duration { get; set; }

        /// <summary>
        /// The eventAttendanceMode of an event indicates whether it occurs online, offline, or a mix.
        /// </summary>
        /// <example>
        /// <code>
        /// "eventAttendanceMode": "https://schema.org/OnlineEventAttendanceMode"
        /// </code>
        /// </example>
        [DataMember(Name = "eventAttendanceMode", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual EventAttendanceModeEnumeration? EventAttendanceMode { get; set; }

        /// <summary>
        /// The status of an event. Can be used to indicate rescheduled or cancelled events
        /// </summary>
        /// <example>
        /// <code>
        /// "eventStatus": "https://schema.org/EventScheduled"
        /// </code>
        /// </example>
        [DataMember(Name = "eventStatus", EmitDefaultValue = false, Order = 22)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Schema.NET.EventStatusType? EventStatus { get; set; }

        /// <summary>
        /// Indicates that an event is restricted to male, female or a mixed audience. This information must be displayed prominently to the user before booking. If a gender restriction isn't specified then applications should assume that an event is suitable for a mixed audience.
        /// </summary>
        /// <example>
        /// <code>
        /// "genderRestriction": "https://openactive.io/FemaleOnly"
        /// </code>
        /// </example>
        [DataMember(Name = "genderRestriction", EmitDefaultValue = false, Order = 23)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual GenderRestrictionType? GenderRestriction { get; set; }

        /// <summary>
        /// An image or photo that depicts the event, e.g. a photo taken at a previous event.
        /// </summary>
        /// <example>
        /// <code>
        /// "image": [
        ///   {
        ///     "@type": "ImageObject",
        ///     "url": "http://example.com/static/image/speedball_large.jpg",
        ///     "thumbnail": [
        ///       {
        ///         "@type": "ImageObject",
        ///         "url": "http://example.com/static/image/speedball_thumbnail.jpg"
        ///       }
        ///     ]
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 24)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ImageObject> Image { get; set; }

        /// <summary>
        /// Whether the Event is accessible without charge.
        /// </summary>
        /// <example>
        /// <code>
        /// "isAccessibleForFree": "true"
        /// </code>
        /// </example>
        [DataMember(Name = "isAccessibleForFree", EmitDefaultValue = false, Order = 25)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual bool? IsAccessibleForFree { get; set; }

        /// <summary>
        /// A boolean property that indicates whether an Event will be coached. This flag allows an Event to be marked as being coached without having to specify a named individual as a coach. This addresses both privacy concerns and also scenarios where the actual coach may only be decided on the day.
        /// </summary>
        /// <example>
        /// <code>
        /// "isCoached": "true"
        /// </code>
        /// </example>
        [DataMember(Name = "isCoached", EmitDefaultValue = false, Order = 26)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsCoached { get; set; }

        /// <summary>
        /// Refers to a person (schema:Person) who will be leading an event. E.g. a coach. This is a more specific role than an organiser or a contributor. The person will need to have given their consent for their personal information to be present in the Open Data.
        /// </summary>
        /// <example>
        /// <code>
        /// "leader": [
        ///   {
        ///     "@type": "Person",
        ///     "familyName": "Smith",
        ///     "givenName": "Nicole",
        ///     "gender": "https://schema.org/Male",
        ///     "@id": "https://example.com/locations/1234ABCD/leaders/89",
        ///     "identifier": 89
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "leader", EmitDefaultValue = false, Order = 27)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Person> Leader { get; set; }

        /// <summary>
        /// A general purpose property for specifying the suitability of an event for different participant “levels”. E.g. `Beginner`, `Intermediate`, `Advanced`. Or in the case of martial arts, specific belt requirements.
        /// </summary>
        /// <example>
        /// <code>
        /// "level": [
        ///   "Beginner"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "level", EmitDefaultValue = false, Order = 28)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual SingleValues<List<string>, List<Concept>> Level { get; set; }

        /// <summary>
        /// The location at which the event will take place. Or, in the case of events that may span multiple locations, the initial meeting or starting point.
        /// It is recommended that locations should be specified as a [Place](/models/place) complete with a fully described geographic location and/or address.
        /// If only an address is available then this should be described as a [PostalAddress](/models/postaladdress).
        /// Applications may use [schema:Text](https://schema.org/Text) to provide a more general description of a location ("In Victoria Park, near the lake"), but this is not recommended: consuming applications will be unable to help users discover opportunities based on their location.
        /// </summary>
        /// <example>
        /// <code>
        /// "location": {
        ///   "@type": "Place",
        ///   "@id": "https://example.com/locations/1234ABCD",
        ///   "identifier": "1234ABCD",
        ///   "address": {
        ///     "addressLocality": "New Malden",
        ///     "addressRegion": "London",
        ///     "postalCode": "NW5 3DU",
        ///     "streetAddress": "Raynes Park High School, 46A West Barnes Lane",
        ///     "@type": "PostalAddress"
        ///   },
        ///   "description": "Raynes Park High School in London",
        ///   "geo": {
        ///     "latitude": 51.4034423828125,
        ///     "longitude": -0.2369088977575302,
        ///     "@type": "GeoCoordinates"
        ///   },
        ///   "name": "Raynes Park High School",
        ///   "telephone": "01253 473934"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "location", EmitDefaultValue = false, Order = 29)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Place Location { get; set; }

        /// <summary>
        /// The maximum capacity of the Event.
        /// </summary>
        /// <example>
        /// <code>
        /// "maximumAttendeeCapacity": 30
        /// </code>
        /// </example>
        [DataMember(Name = "maximumAttendeeCapacity", EmitDefaultValue = false, Order = 30)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual long? MaximumAttendeeCapacity { get; set; }

        /// <summary>
        /// Indicates the maximum number of connections to a shared virtual space.
        /// </summary>
        /// <example>
        /// <code>
        /// "maximumVirtualAttendeeCapacity": 20
        /// </code>
        /// </example>
        [DataMember(Name = "maximumVirtualAttendeeCapacity", EmitDefaultValue = false, Order = 31)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? MaximumVirtualAttendeeCapacity { get; set; }

        /// <summary>
        /// Instructions for the attendees of an Event about where they should meet the organizer or leader at the start of the event. Some larger locations may have several possible meeting points, so this property provides additional more specific directions.
        /// </summary>
        /// <example>
        /// <code>
        /// "meetingPoint": "At the entrance to the park"
        /// </code>
        /// </example>
        [DataMember(Name = "meetingPoint", EmitDefaultValue = false, Order = 32)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string MeetingPoint { get; set; }

        /// <summary>
        /// An array of schema:Offer that include the price of attending.
        /// </summary>
        /// <example>
        /// <code>
        /// "offers": [
        ///   {
        ///     "@type": "Offer",
        ///     "identifier": "OX-AD",
        ///     "name": "Adult",
        ///     "price": 3.3,
        ///     "priceCurrency": "GBP",
        ///     "url": "https://profile.everyoneactive.com/booking?Site=0140&Activities=1402CBP20150217&Culture=en-GB"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "offers", EmitDefaultValue = false, Order = 33)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Offer> Offers { get; set; }

        /// <summary>
        /// The person or organization ultimately responsible for an event. An organizer might be an  schema:Organization or a schema:Person.
        /// </summary>
        /// <example>
        /// <code>
        /// "organizer": {
        ///   "@type": "Organization",
        ///   "name": "Central Speedball Association",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "organizer", EmitDefaultValue = false, Order = 34)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ILegalEntity Organizer { get; set; }

        /// <summary>
        /// Indicates that an event will be organised according to a specific Programme.
        /// </summary>
        /// <example>
        /// <code>
        /// "programme": {
        ///   "@type": "Brand",
        ///   "name": "Play Ball!",
        ///   "url": "http://example.org/brand/play-ball"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "programme", EmitDefaultValue = false, Order = 35)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Brand Programme { get; set; }

        /// <summary>
        /// The number of places that are still available for the Event.
        /// </summary>
        /// <example>
        /// <code>
        /// "remainingAttendeeCapacity": 20
        /// </code>
        /// </example>
        [DataMember(Name = "remainingAttendeeCapacity", EmitDefaultValue = false, Order = 36)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual long? RemainingAttendeeCapacity { get; set; }

        /// <summary>
        /// Provides a note from an organizer relating to how this Event is scheduled.
        /// </summary>
        /// <example>
        /// <code>
        /// "schedulingNote": "This event doesn't run during school holidays"
        /// </code>
        /// </example>
        [DataMember(Name = "schedulingNote", EmitDefaultValue = false, Order = 37)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string SchedulingNote { get; set; }

        /// <summary>
        /// The start date and time of the event. Can be specified as a schema:Date or schema:DateTime.
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 38)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> StartDate { get; set; }

        /// <summary>
        /// The end date and time of the event. Can be specified as a schema:Date or  schema:DateTime
        /// It is recommended that publishers provide either an schema:endDate or a schema:duration for an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 39)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> EndDate { get; set; }

        /// <summary>
        /// Relates a parent event to a child event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A child event might be a specific instance of an Event within a schedule
        /// </summary>
        [DataMember(Name = "subEvent", EmitDefaultValue = false, Order = 40)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Event> SubEvent { get; set; }

        /// <summary>
        /// Relates a child event to a parent event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A parent event might specify a recurring schedule, of which the child event is one specific instance
        /// </summary>
        [DataMember(Name = "superEvent", EmitDefaultValue = false, Order = 41)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Event SuperEvent { get; set; }

        /// <summary>
        /// A URL to a web page (or section of a page) that describes the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://example.com/event/1234"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 42)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers. This property must contain HTML.
        /// 
        /// If you are using this property, please join the discussion at proposal [#2](https://github.com/openactive/ns-beta/issues/2).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1043)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string FormattedDescription { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// The distance of a run, cycle or other activity. Must also include units.
        /// 
        /// If you are using this property, please join the discussion at proposal [#3](https://github.com/openactive/ns-beta/issues/3).
        /// </summary>
        [DataMember(Name = "beta:distance", EmitDefaultValue = false, Order = 1044)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue Distance { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// For events that have an unlimited number of tickets, captures the number of attendees (actual attendance).
        /// 
        /// If you are using this property, please join the discussion at proposal [#12](https://github.com/openactive/ns-beta/issues/12).
        /// </summary>
        [DataMember(Name = "beta:attendeeCount", EmitDefaultValue = false, Order = 1045)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? AttendeeCount { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// For events that have an unlimited number of tickets, captures the number of registrations (intention to attend).
        /// 
        /// If you are using this property, please join the discussion at proposal [#13](https://github.com/openactive/ns-beta/issues/13).
        /// </summary>
        [DataMember(Name = "beta:registrationCount", EmitDefaultValue = false, Order = 1046)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? RegistrationCount { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A property that details whether the event is suitable for wheelchair access. Placed on Event as this field could be used to detail whether the Event is suitable, as well as the Place.
        /// 
        /// If you are using this property, please join the discussion at proposal [#166](https://github.com/openactive/modelling-opportunity-data/issues/166).
        /// </summary>
        [DataMember(Name = "beta:isWheelchairAccessible", EmitDefaultValue = false, Order = 1047)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsWheelchairAccessible { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A property that allows an Event duration to be represented as a range (e.g. 0-30mins, 30-60mins, 60-90mins, 90+).
        /// 
        /// If you are using this property, please join the discussion at proposal [#201](https://github.com/openactive/modelling-opportunity-data/issues/201).
        /// </summary>
        [DataMember(Name = "beta:estimatedDuration", EmitDefaultValue = false, Order = 1048)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue EstimatedDuration { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", EmitDefaultValue = false, Order = 1049)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<VideoObject> Video { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Internal location of the event, e.g. Court 1
        /// 
        /// If you are using this property, please join the discussion at proposal [#110](https://github.com/openactive/modelling-opportunity-data/issues/110).
        /// </summary>
        [DataMember(Name = "beta:sportsActivityLocation", EmitDefaultValue = false, Order = 1050)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Schema.NET.SportsActivityLocation> SportsActivityLocation { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Duration before the event for which the associated Offers are valid
        /// 
        /// If you are using this property, please join the discussion at proposal [#204](https://github.com/openactive/modelling-opportunity-data/issues/204).
        /// </summary>
        [DataMember(Name = "beta:offerValidityPeriod", EmitDefaultValue = false, Order = 1051)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? OfferValidityPeriod { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Whether the event or facility is indoor or outdoor.
        /// 
        /// If you are using this property, please join the discussion at proposal [#1](https://github.com/openactive/facility-types/issues/1).
        /// </summary>
        [DataMember(Name = "beta:facilitySetting", EmitDefaultValue = false, Order = 1052)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual FacilitySettingType? FacilitySetting { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A property that indicates whether the event is led by a virtual coach. Only relevant if an event `isCoached`. If not provided is assumed to be `false`.
        /// 
        /// If you are using this property, please join the discussion at proposal [#71](https://github.com/openactive/modelling-opportunity-data/issues/71).
        /// </summary>
        [DataMember(Name = "beta:isVirtuallyCoached", EmitDefaultValue = false, Order = 1053)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsVirtuallyCoached { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Describes a means of electronic access to a shared virtual space.
        /// 
        /// If you are using this property, please join the discussion at proposal [#224](https://github.com/openactive/modelling-opportunity-data/issues/224).
        /// </summary>
        [DataMember(Name = "beta:virtualLocation", EmitDefaultValue = false, Order = 1054)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual VirtualLocation VirtualLocation { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// The physical location affiliated with the virtual event, for example the original location of the event before it was moved online.
        /// 
        /// If you are using this property, please join the discussion at proposal [#227](https://github.com/openactive/modelling-opportunity-data/issues/227).
        /// </summary>
        [DataMember(Name = "beta:affiliatedLocation", EmitDefaultValue = false, Order = 1055)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Place AffiliatedLocation { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Indicates whether the virtual event is interactive (e.g. Zoom with participant microphones and cameras on), or is just a one-way broadcast (e.g. Facebook Live, Instagram Live, Zoom with participant microphones and cameras off).
        /// 
        /// If you are using this property, please join the discussion at proposal [#230](https://github.com/openactive/modelling-opportunity-data/issues/230).
        /// </summary>
        [DataMember(Name = "beta:isInteractivityPreferred", EmitDefaultValue = false, Order = 1056)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsInteractivityPreferred { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Indicates whether the participant must or may supply equipment for use in the Event.
        /// 
        /// If you are using this property, please join the discussion at proposal [#229](https://github.com/openactive/modelling-opportunity-data/issues/229).
        /// </summary>
        [DataMember(Name = "beta:participantSuppliedEquipment", EmitDefaultValue = false, Order = 1057)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual RequiredStatusType? ParticipantSuppliedEquipment { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// The URL of the webpage where the activity provider accepts donations.
        /// 
        /// If you are using this property, please join the discussion at proposal [#234](https://github.com/openactive/modelling-opportunity-data/issues/234).
        /// </summary>
        [DataMember(Name = "beta:donationPaymentUrl", EmitDefaultValue = false, Order = 1058)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri DonationPaymentUrl { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A property that indicates whether the first session is free.
        /// 
        /// If you are using this property, please join the discussion at proposal [#232](https://github.com/openactive/modelling-opportunity-data/issues/232).
        /// </summary>
        [DataMember(Name = "beta:isFirstSessionAccessibleForFree", EmitDefaultValue = false, Order = 1059)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsFirstSessionAccessibleForFree { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Contact details for an Event, where they are not specifically related to the `organizer` or `leader`.
        /// 
        /// If you are using this property, please join the discussion at proposal [#113](https://github.com/openactive/modelling-opportunity-data/issues/113).
        /// </summary>
        [DataMember(Name = "beta:contactPoint", EmitDefaultValue = false, Order = 1060)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Schema.NET.ContactPoint ContactPoint { get; set; }

        /// <summary>
        /// [NOTICE: This property is part of the Open Booking API Test Interface, and MUST NOT be used in production.]
        /// The opportunity criteria which the Event conforms to.
        /// </summary>
        [DataMember(Name = "test:testOpportunityCriteria", EmitDefaultValue = false, Order = 1061)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual TestOpportunityCriteriaEnumeration? TestOpportunityCriteria { get; set; }
    }
}
