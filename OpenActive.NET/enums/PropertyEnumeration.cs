using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This enumeration contains a value for all properties in the https://schema.org/ and https://openactive.io/ vocabularies.
    /// </summary>
    public enum  PropertyEnumeration
    {
        [EnumMember(Value = "https://openactive.io/accessChannel")]
        AccessChannel,
        [EnumMember(Value = "https://openactive.io/accessId")]
        AccessId,
        [EnumMember(Value = "https://openactive.io/accessPass")]
        AccessPass,
        [EnumMember(Value = "https://openactive.io/accessibilityInformation")]
        AccessibilityInformation,
        [EnumMember(Value = "https://openactive.io/accessibilitySupport")]
        AccessibilitySupport,
        [EnumMember(Value = "https://openactive.io/accountNumber")]
        AccountNumber,
        [EnumMember(Value = "https://openactive.io/activity")]
        Activity,
        [EnumMember(Value = "https://openactive.io/additionalAdmissionRestriction")]
        AdditionalAdmissionRestriction,
        [EnumMember(Value = "https://openactive.io/ageRange")]
        AgeRange,
        [EnumMember(Value = "https://openactive.io/ageRestriction")]
        AgeRestriction,
        [EnumMember(Value = "https://openactive.io/aggregateFacilityUse")]
        AggregateFacilityUse,
        [EnumMember(Value = "https://openactive.io/allowCustomerCancellationFullRefund")]
        AllowCustomerCancellationFullRefund,
        [EnumMember(Value = "https://openactive.io/attendeeDetailsRequired")]
        AttendeeDetailsRequired,
        [EnumMember(Value = "https://openactive.io/attendeeInstructions")]
        AttendeeInstructions,
        [EnumMember(Value = "https://openactive.io/authenticationAuthority")]
        AuthenticationAuthority,
        [EnumMember(Value = "https://openactive.io/backgroundImage")]
        BackgroundImage,
        [EnumMember(Value = "https://openactive.io/bookingService")]
        BookingService,
        [EnumMember(Value = "https://openactive.io/brokerRole")]
        BrokerRole,
        [EnumMember(Value = "https://openactive.io/cancellationMessage")]
        CancellationMessage,
        [EnumMember(Value = "https://openactive.io/concept")]
        Concept,
        [EnumMember(Value = "https://openactive.io/customerAccountBookingRestriction")]
        CustomerAccountBookingRestriction,
        [EnumMember(Value = "https://openactive.io/customerNotice")]
        CustomerNotice,
        [EnumMember(Value = "https://openactive.io/eligibleEntitlementType")]
        EligibleEntitlementType,
        [EnumMember(Value = "https://openactive.io/emergencyContact")]
        EmergencyContact,
        [EnumMember(Value = "https://openactive.io/entitlement")]
        Entitlement,
        [EnumMember(Value = "https://openactive.io/entitlementType")]
        EntitlementType,
        [EnumMember(Value = "https://openactive.io/evidenceRequestAction")]
        EvidenceRequestAction,
        [EnumMember(Value = "https://openactive.io/facilityUse")]
        FacilityUse,
        [EnumMember(Value = "https://openactive.io/genderRestriction")]
        GenderRestriction,
        [EnumMember(Value = "https://openactive.io/hasAccount")]
        HasAccount,
        [EnumMember(Value = "https://openactive.io/hasHiddenEntitlements")]
        HasHiddenEntitlements,
        [EnumMember(Value = "https://openactive.io/idTemplate")]
        IdTemplate,
        [EnumMember(Value = "https://openactive.io/individualFacilityUse")]
        IndividualFacilityUse,
        [EnumMember(Value = "https://openactive.io/instance")]
        Instance,
        [EnumMember(Value = "https://openactive.io/instanceOfCourse")]
        InstanceOfCourse,
        [EnumMember(Value = "https://openactive.io/isCoached")]
        IsCoached,
        [EnumMember(Value = "https://openactive.io/isOpenBookingAllowed")]
        IsOpenBookingAllowed,
        [EnumMember(Value = "https://openactive.io/isOpenBookingWithCustomerAccountAllowed")]
        IsOpenBookingWithCustomerAccountAllowed,
        [EnumMember(Value = "https://openactive.io/latestCancellationBeforeStartDate")]
        LatestCancellationBeforeStartDate,
        [EnumMember(Value = "https://openactive.io/leader")]
        Leader,
        [EnumMember(Value = "https://openactive.io/lease")]
        Lease,
        [EnumMember(Value = "https://openactive.io/leaseExpires")]
        LeaseExpires,
        [EnumMember(Value = "https://openactive.io/level")]
        Level,
        [EnumMember(Value = "https://openactive.io/maximumUses")]
        MaximumUses,
        [EnumMember(Value = "https://openactive.io/meetingPoint")]
        MeetingPoint,
        [EnumMember(Value = "https://openactive.io/openBookingFlowRequirement")]
        OpenBookingFlowRequirement,
        [EnumMember(Value = "https://openactive.io/openBookingInAdvance")]
        OpenBookingInAdvance,
        [EnumMember(Value = "https://openactive.io/openBookingPrepayment")]
        OpenBookingPrepayment,
        [EnumMember(Value = "https://openactive.io/orderCreationStatus")]
        OrderCreationStatus,
        [EnumMember(Value = "https://openactive.io/orderCustomerNote")]
        OrderCustomerNote,
        [EnumMember(Value = "https://openactive.io/orderItemIntakeForm")]
        OrderItemIntakeForm,
        [EnumMember(Value = "https://openactive.io/orderItemIntakeFormResponse")]
        OrderItemIntakeFormResponse,
        [EnumMember(Value = "https://openactive.io/orderProposalStatus")]
        OrderProposalStatus,
        [EnumMember(Value = "https://openactive.io/orderProposalVersion")]
        OrderProposalVersion,
        [EnumMember(Value = "https://openactive.io/orderRequiresApproval")]
        OrderRequiresApproval,
        [EnumMember(Value = "https://openactive.io/orderSellerNote")]
        OrderSellerNote,
        [EnumMember(Value = "https://openactive.io/outstandingAction")]
        OutstandingAction,
        [EnumMember(Value = "https://openactive.io/payment")]
        Payment,
        [EnumMember(Value = "https://openactive.io/paymentProviderId")]
        PaymentProviderId,
        [EnumMember(Value = "https://openactive.io/programme")]
        Programme,
        [EnumMember(Value = "https://openactive.io/rate")]
        Rate,
        [EnumMember(Value = "https://openactive.io/remainingUses")]
        RemainingUses,
        [EnumMember(Value = "https://openactive.io/requestId")]
        RequestId,
        [EnumMember(Value = "https://openactive.io/requiresExplicitConsent")]
        RequiresExplicitConsent,
        [EnumMember(Value = "https://openactive.io/scheduledEventType")]
        ScheduledEventType,
        [EnumMember(Value = "https://openactive.io/schedulingNote")]
        SchedulingNote,
        [EnumMember(Value = "https://openactive.io/statusCode")]
        StatusCode,
        [EnumMember(Value = "https://openactive.io/taxCalculationExcluded")]
        TaxCalculationExcluded,
        [EnumMember(Value = "https://openactive.io/taxMode")]
        TaxMode,
        [EnumMember(Value = "https://openactive.io/totalPaymentTax")]
        TotalPaymentTax,
        [EnumMember(Value = "https://openactive.io/unitTaxSpecification")]
        UnitTaxSpecification,
        [EnumMember(Value = "https://openactive.io/validFromBeforeStartDate")]
        ValidFromBeforeStartDate,
        [EnumMember(Value = "https://openactive.io/valueOption")]
        ValueOption,
        [EnumMember(Value = "https://schema.org/about")]
        About,
        [EnumMember(Value = "https://schema.org/abridged")]
        Abridged,
        [EnumMember(Value = "https://schema.org/abstract")]
        Abstract,
        [EnumMember(Value = "https://schema.org/accelerationTime")]
        AccelerationTime,
        [EnumMember(Value = "https://schema.org/acceptedAnswer")]
        AcceptedAnswer,
        [EnumMember(Value = "https://schema.org/acceptedOffer")]
        AcceptedOffer,
        [EnumMember(Value = "https://schema.org/acceptedPaymentMethod")]
        AcceptedPaymentMethod,
        [EnumMember(Value = "https://schema.org/acceptsReservations")]
        AcceptsReservations,
        [EnumMember(Value = "https://schema.org/accessCode")]
        AccessCode,
        [EnumMember(Value = "https://schema.org/accessMode")]
        AccessMode,
        [EnumMember(Value = "https://schema.org/accessModeSufficient")]
        AccessModeSufficient,
        [EnumMember(Value = "https://schema.org/accessibilityAPI")]
        AccessibilityAPI,
        [EnumMember(Value = "https://schema.org/accessibilityControl")]
        AccessibilityControl,
        [EnumMember(Value = "https://schema.org/accessibilityFeature")]
        AccessibilityFeature,
        [EnumMember(Value = "https://schema.org/accessibilityHazard")]
        AccessibilityHazard,
        [EnumMember(Value = "https://schema.org/accessibilitySummary")]
        AccessibilitySummary,
        [EnumMember(Value = "https://schema.org/accommodationCategory")]
        AccommodationCategory,
        [EnumMember(Value = "https://schema.org/accommodationFloorPlan")]
        AccommodationFloorPlan,
        [EnumMember(Value = "https://schema.org/accountId")]
        AccountId,
        [EnumMember(Value = "https://schema.org/accountMinimumInflow")]
        AccountMinimumInflow,
        [EnumMember(Value = "https://schema.org/accountOverdraftLimit")]
        AccountOverdraftLimit,
        [EnumMember(Value = "https://schema.org/accountablePerson")]
        AccountablePerson,
        [EnumMember(Value = "https://schema.org/acquireLicensePage")]
        AcquireLicensePage,
        [EnumMember(Value = "https://schema.org/acquiredFrom")]
        AcquiredFrom,
        [EnumMember(Value = "https://schema.org/acrissCode")]
        AcrissCode,
        [EnumMember(Value = "https://schema.org/actionAccessibilityRequirement")]
        ActionAccessibilityRequirement,
        [EnumMember(Value = "https://schema.org/actionApplication")]
        ActionApplication,
        [EnumMember(Value = "https://schema.org/actionOption")]
        ActionOption,
        [EnumMember(Value = "https://schema.org/actionPlatform")]
        ActionPlatform,
        [EnumMember(Value = "https://schema.org/actionStatus")]
        ActionStatus,
        [EnumMember(Value = "https://schema.org/actionableFeedbackPolicy")]
        ActionableFeedbackPolicy,
        [EnumMember(Value = "https://schema.org/activeIngredient")]
        ActiveIngredient,
        [EnumMember(Value = "https://schema.org/activityDuration")]
        ActivityDuration,
        [EnumMember(Value = "https://schema.org/activityFrequency")]
        ActivityFrequency,
        [EnumMember(Value = "https://schema.org/actor")]
        Actor,
        [EnumMember(Value = "https://schema.org/actors")]
        Actors,
        [EnumMember(Value = "https://schema.org/addOn")]
        AddOn,
        [EnumMember(Value = "https://schema.org/additionalName")]
        AdditionalName,
        [EnumMember(Value = "https://schema.org/additionalNumberOfGuests")]
        AdditionalNumberOfGuests,
        [EnumMember(Value = "https://schema.org/additionalProperty")]
        AdditionalProperty,
        [EnumMember(Value = "https://schema.org/additionalType")]
        AdditionalType,
        [EnumMember(Value = "https://schema.org/additionalVariable")]
        AdditionalVariable,
        [EnumMember(Value = "https://schema.org/address")]
        Address,
        [EnumMember(Value = "https://schema.org/addressCountry")]
        AddressCountry,
        [EnumMember(Value = "https://schema.org/addressLocality")]
        AddressLocality,
        [EnumMember(Value = "https://schema.org/addressRegion")]
        AddressRegion,
        [EnumMember(Value = "https://schema.org/administrationRoute")]
        AdministrationRoute,
        [EnumMember(Value = "https://schema.org/advanceBookingRequirement")]
        AdvanceBookingRequirement,
        [EnumMember(Value = "https://schema.org/adverseOutcome")]
        AdverseOutcome,
        [EnumMember(Value = "https://schema.org/affectedBy")]
        AffectedBy,
        [EnumMember(Value = "https://schema.org/affiliation")]
        Affiliation,
        [EnumMember(Value = "https://schema.org/afterMedia")]
        AfterMedia,
        [EnumMember(Value = "https://schema.org/agent")]
        Agent,
        [EnumMember(Value = "https://schema.org/aggregateRating")]
        AggregateRating,
        [EnumMember(Value = "https://schema.org/aircraft")]
        Aircraft,
        [EnumMember(Value = "https://schema.org/album")]
        Album,
        [EnumMember(Value = "https://schema.org/albumProductionType")]
        AlbumProductionType,
        [EnumMember(Value = "https://schema.org/albumRelease")]
        AlbumRelease,
        [EnumMember(Value = "https://schema.org/albumReleaseType")]
        AlbumReleaseType,
        [EnumMember(Value = "https://schema.org/albums")]
        Albums,
        [EnumMember(Value = "https://schema.org/alcoholWarning")]
        AlcoholWarning,
        [EnumMember(Value = "https://schema.org/algorithm")]
        Algorithm,
        [EnumMember(Value = "https://schema.org/alignmentType")]
        AlignmentType,
        [EnumMember(Value = "https://schema.org/alternateName")]
        AlternateName,
        [EnumMember(Value = "https://schema.org/alternativeHeadline")]
        AlternativeHeadline,
        [EnumMember(Value = "https://schema.org/alternativeOf")]
        AlternativeOf,
        [EnumMember(Value = "https://schema.org/alumni")]
        Alumni,
        [EnumMember(Value = "https://schema.org/alumniOf")]
        AlumniOf,
        [EnumMember(Value = "https://schema.org/amenityFeature")]
        AmenityFeature,
        [EnumMember(Value = "https://schema.org/amount")]
        Amount,
        [EnumMember(Value = "https://schema.org/amountOfThisGood")]
        AmountOfThisGood,
        [EnumMember(Value = "https://schema.org/announcementLocation")]
        AnnouncementLocation,
        [EnumMember(Value = "https://schema.org/annualPercentageRate")]
        AnnualPercentageRate,
        [EnumMember(Value = "https://schema.org/answerCount")]
        AnswerCount,
        [EnumMember(Value = "https://schema.org/answerExplanation")]
        AnswerExplanation,
        [EnumMember(Value = "https://schema.org/antagonist")]
        Antagonist,
        [EnumMember(Value = "https://schema.org/appearance")]
        Appearance,
        [EnumMember(Value = "https://schema.org/applicableLocation")]
        ApplicableLocation,
        [EnumMember(Value = "https://schema.org/applicantLocationRequirements")]
        ApplicantLocationRequirements,
        [EnumMember(Value = "https://schema.org/application")]
        Application,
        [EnumMember(Value = "https://schema.org/applicationCategory")]
        ApplicationCategory,
        [EnumMember(Value = "https://schema.org/applicationContact")]
        ApplicationContact,
        [EnumMember(Value = "https://schema.org/applicationDeadline")]
        ApplicationDeadline,
        [EnumMember(Value = "https://schema.org/applicationStartDate")]
        ApplicationStartDate,
        [EnumMember(Value = "https://schema.org/applicationSubCategory")]
        ApplicationSubCategory,
        [EnumMember(Value = "https://schema.org/applicationSuite")]
        ApplicationSuite,
        [EnumMember(Value = "https://schema.org/appliesToDeliveryMethod")]
        AppliesToDeliveryMethod,
        [EnumMember(Value = "https://schema.org/appliesToPaymentMethod")]
        AppliesToPaymentMethod,
        [EnumMember(Value = "https://schema.org/archiveHeld")]
        ArchiveHeld,
        [EnumMember(Value = "https://schema.org/archivedAt")]
        ArchivedAt,
        [EnumMember(Value = "https://schema.org/area")]
        Area,
        [EnumMember(Value = "https://schema.org/areaServed")]
        AreaServed,
        [EnumMember(Value = "https://schema.org/arrivalAirport")]
        ArrivalAirport,
        [EnumMember(Value = "https://schema.org/arrivalBoatTerminal")]
        ArrivalBoatTerminal,
        [EnumMember(Value = "https://schema.org/arrivalBusStop")]
        ArrivalBusStop,
        [EnumMember(Value = "https://schema.org/arrivalGate")]
        ArrivalGate,
        [EnumMember(Value = "https://schema.org/arrivalPlatform")]
        ArrivalPlatform,
        [EnumMember(Value = "https://schema.org/arrivalStation")]
        ArrivalStation,
        [EnumMember(Value = "https://schema.org/arrivalTerminal")]
        ArrivalTerminal,
        [EnumMember(Value = "https://schema.org/arrivalTime")]
        ArrivalTime,
        [EnumMember(Value = "https://schema.org/artEdition")]
        ArtEdition,
        [EnumMember(Value = "https://schema.org/artMedium")]
        ArtMedium,
        [EnumMember(Value = "https://schema.org/arterialBranch")]
        ArterialBranch,
        [EnumMember(Value = "https://schema.org/artform")]
        Artform,
        [EnumMember(Value = "https://schema.org/articleBody")]
        ArticleBody,
        [EnumMember(Value = "https://schema.org/articleSection")]
        ArticleSection,
        [EnumMember(Value = "https://schema.org/artist")]
        Artist,
        [EnumMember(Value = "https://schema.org/artworkSurface")]
        ArtworkSurface,
        [EnumMember(Value = "https://schema.org/aspect")]
        Aspect,
        [EnumMember(Value = "https://schema.org/assembly")]
        Assembly,
        [EnumMember(Value = "https://schema.org/assemblyVersion")]
        AssemblyVersion,
        [EnumMember(Value = "https://schema.org/assesses")]
        Assesses,
        [EnumMember(Value = "https://schema.org/associatedAnatomy")]
        AssociatedAnatomy,
        [EnumMember(Value = "https://schema.org/associatedArticle")]
        AssociatedArticle,
        [EnumMember(Value = "https://schema.org/associatedClaimReview")]
        AssociatedClaimReview,
        [EnumMember(Value = "https://schema.org/associatedDisease")]
        AssociatedDisease,
        [EnumMember(Value = "https://schema.org/associatedMedia")]
        AssociatedMedia,
        [EnumMember(Value = "https://schema.org/associatedMediaReview")]
        AssociatedMediaReview,
        [EnumMember(Value = "https://schema.org/associatedPathophysiology")]
        AssociatedPathophysiology,
        [EnumMember(Value = "https://schema.org/associatedReview")]
        AssociatedReview,
        [EnumMember(Value = "https://schema.org/athlete")]
        Athlete,
        [EnumMember(Value = "https://schema.org/attendee")]
        Attendee,
        [EnumMember(Value = "https://schema.org/attendees")]
        Attendees,
        [EnumMember(Value = "https://schema.org/audience")]
        Audience,
        [EnumMember(Value = "https://schema.org/audienceType")]
        AudienceType,
        [EnumMember(Value = "https://schema.org/audio")]
        Audio,
        [EnumMember(Value = "https://schema.org/authenticator")]
        Authenticator,
        [EnumMember(Value = "https://schema.org/author")]
        Author,
        [EnumMember(Value = "https://schema.org/availability")]
        Availability,
        [EnumMember(Value = "https://schema.org/availabilityEnds")]
        AvailabilityEnds,
        [EnumMember(Value = "https://schema.org/availabilityStarts")]
        AvailabilityStarts,
        [EnumMember(Value = "https://schema.org/availableAtOrFrom")]
        AvailableAtOrFrom,
        [EnumMember(Value = "https://schema.org/availableChannel")]
        AvailableChannel,
        [EnumMember(Value = "https://schema.org/availableDeliveryMethod")]
        AvailableDeliveryMethod,
        [EnumMember(Value = "https://schema.org/availableFrom")]
        AvailableFrom,
        [EnumMember(Value = "https://schema.org/availableIn")]
        AvailableIn,
        [EnumMember(Value = "https://schema.org/availableLanguage")]
        AvailableLanguage,
        [EnumMember(Value = "https://schema.org/availableOnDevice")]
        AvailableOnDevice,
        [EnumMember(Value = "https://schema.org/availableService")]
        AvailableService,
        [EnumMember(Value = "https://schema.org/availableStrength")]
        AvailableStrength,
        [EnumMember(Value = "https://schema.org/availableTest")]
        AvailableTest,
        [EnumMember(Value = "https://schema.org/availableThrough")]
        AvailableThrough,
        [EnumMember(Value = "https://schema.org/award")]
        Award,
        [EnumMember(Value = "https://schema.org/awards")]
        Awards,
        [EnumMember(Value = "https://schema.org/awayTeam")]
        AwayTeam,
        [EnumMember(Value = "https://schema.org/backstory")]
        Backstory,
        [EnumMember(Value = "https://schema.org/bankAccountType")]
        BankAccountType,
        [EnumMember(Value = "https://schema.org/baseSalary")]
        BaseSalary,
        [EnumMember(Value = "https://schema.org/bccRecipient")]
        BccRecipient,
        [EnumMember(Value = "https://schema.org/bed")]
        Bed,
        [EnumMember(Value = "https://schema.org/beforeMedia")]
        BeforeMedia,
        [EnumMember(Value = "https://schema.org/beneficiaryBank")]
        BeneficiaryBank,
        [EnumMember(Value = "https://schema.org/benefits")]
        Benefits,
        [EnumMember(Value = "https://schema.org/benefitsSummaryUrl")]
        BenefitsSummaryUrl,
        [EnumMember(Value = "https://schema.org/bestRating")]
        BestRating,
        [EnumMember(Value = "https://schema.org/billingAddress")]
        BillingAddress,
        [EnumMember(Value = "https://schema.org/billingDuration")]
        BillingDuration,
        [EnumMember(Value = "https://schema.org/billingIncrement")]
        BillingIncrement,
        [EnumMember(Value = "https://schema.org/billingPeriod")]
        BillingPeriod,
        [EnumMember(Value = "https://schema.org/billingStart")]
        BillingStart,
        [EnumMember(Value = "https://schema.org/bioChemInteraction")]
        BioChemInteraction,
        [EnumMember(Value = "https://schema.org/bioChemSimilarity")]
        BioChemSimilarity,
        [EnumMember(Value = "https://schema.org/biologicalRole")]
        BiologicalRole,
        [EnumMember(Value = "https://schema.org/biomechnicalClass")]
        BiomechnicalClass,
        [EnumMember(Value = "https://schema.org/birthDate")]
        BirthDate,
        [EnumMember(Value = "https://schema.org/birthPlace")]
        BirthPlace,
        [EnumMember(Value = "https://schema.org/bitrate")]
        Bitrate,
        [EnumMember(Value = "https://schema.org/blogPost")]
        BlogPost,
        [EnumMember(Value = "https://schema.org/blogPosts")]
        BlogPosts,
        [EnumMember(Value = "https://schema.org/bloodSupply")]
        BloodSupply,
        [EnumMember(Value = "https://schema.org/boardingGroup")]
        BoardingGroup,
        [EnumMember(Value = "https://schema.org/boardingPolicy")]
        BoardingPolicy,
        [EnumMember(Value = "https://schema.org/bodyLocation")]
        BodyLocation,
        [EnumMember(Value = "https://schema.org/bodyType")]
        BodyType,
        [EnumMember(Value = "https://schema.org/bookEdition")]
        BookEdition,
        [EnumMember(Value = "https://schema.org/bookFormat")]
        BookFormat,
        [EnumMember(Value = "https://schema.org/bookingAgent")]
        BookingAgent,
        [EnumMember(Value = "https://schema.org/bookingTime")]
        BookingTime,
        [EnumMember(Value = "https://schema.org/borrower")]
        Borrower,
        [EnumMember(Value = "https://schema.org/box")]
        Box,
        [EnumMember(Value = "https://schema.org/branch")]
        Branch,
        [EnumMember(Value = "https://schema.org/branchCode")]
        BranchCode,
        [EnumMember(Value = "https://schema.org/branchOf")]
        BranchOf,
        [EnumMember(Value = "https://schema.org/brand")]
        Brand,
        [EnumMember(Value = "https://schema.org/breadcrumb")]
        Breadcrumb,
        [EnumMember(Value = "https://schema.org/breastfeedingWarning")]
        BreastfeedingWarning,
        [EnumMember(Value = "https://schema.org/broadcastAffiliateOf")]
        BroadcastAffiliateOf,
        [EnumMember(Value = "https://schema.org/broadcastChannelId")]
        BroadcastChannelId,
        [EnumMember(Value = "https://schema.org/broadcastDisplayName")]
        BroadcastDisplayName,
        [EnumMember(Value = "https://schema.org/broadcastFrequency")]
        BroadcastFrequency,
        [EnumMember(Value = "https://schema.org/broadcastFrequencyValue")]
        BroadcastFrequencyValue,
        [EnumMember(Value = "https://schema.org/broadcastOfEvent")]
        BroadcastOfEvent,
        [EnumMember(Value = "https://schema.org/broadcastServiceTier")]
        BroadcastServiceTier,
        [EnumMember(Value = "https://schema.org/broadcastSignalModulation")]
        BroadcastSignalModulation,
        [EnumMember(Value = "https://schema.org/broadcastSubChannel")]
        BroadcastSubChannel,
        [EnumMember(Value = "https://schema.org/broadcastTimezone")]
        BroadcastTimezone,
        [EnumMember(Value = "https://schema.org/broadcaster")]
        Broadcaster,
        [EnumMember(Value = "https://schema.org/broker")]
        Broker,
        [EnumMember(Value = "https://schema.org/browserRequirements")]
        BrowserRequirements,
        [EnumMember(Value = "https://schema.org/busName")]
        BusName,
        [EnumMember(Value = "https://schema.org/busNumber")]
        BusNumber,
        [EnumMember(Value = "https://schema.org/businessDays")]
        BusinessDays,
        [EnumMember(Value = "https://schema.org/businessFunction")]
        BusinessFunction,
        [EnumMember(Value = "https://schema.org/buyer")]
        Buyer,
        [EnumMember(Value = "https://schema.org/byArtist")]
        ByArtist,
        [EnumMember(Value = "https://schema.org/byDay")]
        ByDay,
        [EnumMember(Value = "https://schema.org/byMonth")]
        ByMonth,
        [EnumMember(Value = "https://schema.org/byMonthDay")]
        ByMonthDay,
        [EnumMember(Value = "https://schema.org/byMonthWeek")]
        ByMonthWeek,
        [EnumMember(Value = "https://schema.org/callSign")]
        CallSign,
        [EnumMember(Value = "https://schema.org/calories")]
        Calories,
        [EnumMember(Value = "https://schema.org/candidate")]
        Candidate,
        [EnumMember(Value = "https://schema.org/caption")]
        Caption,
        [EnumMember(Value = "https://schema.org/carbohydrateContent")]
        CarbohydrateContent,
        [EnumMember(Value = "https://schema.org/cargoVolume")]
        CargoVolume,
        [EnumMember(Value = "https://schema.org/carrier")]
        Carrier,
        [EnumMember(Value = "https://schema.org/carrierRequirements")]
        CarrierRequirements,
        [EnumMember(Value = "https://schema.org/cashBack")]
        CashBack,
        [EnumMember(Value = "https://schema.org/catalog")]
        Catalog,
        [EnumMember(Value = "https://schema.org/catalogNumber")]
        CatalogNumber,
        [EnumMember(Value = "https://schema.org/category")]
        Category,
        [EnumMember(Value = "https://schema.org/causeOf")]
        CauseOf,
        [EnumMember(Value = "https://schema.org/ccRecipient")]
        CcRecipient,
        [EnumMember(Value = "https://schema.org/character")]
        Character,
        [EnumMember(Value = "https://schema.org/characterAttribute")]
        CharacterAttribute,
        [EnumMember(Value = "https://schema.org/characterName")]
        CharacterName,
        [EnumMember(Value = "https://schema.org/cheatCode")]
        CheatCode,
        [EnumMember(Value = "https://schema.org/checkinTime")]
        CheckinTime,
        [EnumMember(Value = "https://schema.org/checkoutTime")]
        CheckoutTime,
        [EnumMember(Value = "https://schema.org/chemicalComposition")]
        ChemicalComposition,
        [EnumMember(Value = "https://schema.org/chemicalRole")]
        ChemicalRole,
        [EnumMember(Value = "https://schema.org/childMaxAge")]
        ChildMaxAge,
        [EnumMember(Value = "https://schema.org/childMinAge")]
        ChildMinAge,
        [EnumMember(Value = "https://schema.org/childTaxon")]
        ChildTaxon,
        [EnumMember(Value = "https://schema.org/children")]
        Children,
        [EnumMember(Value = "https://schema.org/cholesterolContent")]
        CholesterolContent,
        [EnumMember(Value = "https://schema.org/circle")]
        Circle,
        [EnumMember(Value = "https://schema.org/citation")]
        Citation,
        [EnumMember(Value = "https://schema.org/claimInterpreter")]
        ClaimInterpreter,
        [EnumMember(Value = "https://schema.org/claimReviewed")]
        ClaimReviewed,
        [EnumMember(Value = "https://schema.org/clincalPharmacology")]
        ClincalPharmacology,
        [EnumMember(Value = "https://schema.org/clinicalPharmacology")]
        ClinicalPharmacology,
        [EnumMember(Value = "https://schema.org/clipNumber")]
        ClipNumber,
        [EnumMember(Value = "https://schema.org/closes")]
        Closes,
        [EnumMember(Value = "https://schema.org/coach")]
        Coach,
        [EnumMember(Value = "https://schema.org/code")]
        Code,
        [EnumMember(Value = "https://schema.org/codeRepository")]
        CodeRepository,
        [EnumMember(Value = "https://schema.org/codeSampleType")]
        CodeSampleType,
        [EnumMember(Value = "https://schema.org/codeValue")]
        CodeValue,
        [EnumMember(Value = "https://schema.org/codingSystem")]
        CodingSystem,
        [EnumMember(Value = "https://schema.org/colleague")]
        Colleague,
        [EnumMember(Value = "https://schema.org/colleagues")]
        Colleagues,
        [EnumMember(Value = "https://schema.org/collection")]
        Collection,
        [EnumMember(Value = "https://schema.org/collectionSize")]
        CollectionSize,
        [EnumMember(Value = "https://schema.org/color")]
        Color,
        [EnumMember(Value = "https://schema.org/colorist")]
        Colorist,
        [EnumMember(Value = "https://schema.org/comment")]
        Comment,
        [EnumMember(Value = "https://schema.org/commentCount")]
        CommentCount,
        [EnumMember(Value = "https://schema.org/commentText")]
        CommentText,
        [EnumMember(Value = "https://schema.org/commentTime")]
        CommentTime,
        [EnumMember(Value = "https://schema.org/competencyRequired")]
        CompetencyRequired,
        [EnumMember(Value = "https://schema.org/competitor")]
        Competitor,
        [EnumMember(Value = "https://schema.org/composer")]
        Composer,
        [EnumMember(Value = "https://schema.org/comprisedOf")]
        ComprisedOf,
        [EnumMember(Value = "https://schema.org/conditionsOfAccess")]
        ConditionsOfAccess,
        [EnumMember(Value = "https://schema.org/confirmationNumber")]
        ConfirmationNumber,
        [EnumMember(Value = "https://schema.org/connectedTo")]
        ConnectedTo,
        [EnumMember(Value = "https://schema.org/constrainingProperty")]
        ConstrainingProperty,
        [EnumMember(Value = "https://schema.org/contactOption")]
        ContactOption,
        [EnumMember(Value = "https://schema.org/contactPoint")]
        ContactPoint,
        [EnumMember(Value = "https://schema.org/contactPoints")]
        ContactPoints,
        [EnumMember(Value = "https://schema.org/contactType")]
        ContactType,
        [EnumMember(Value = "https://schema.org/contactlessPayment")]
        ContactlessPayment,
        [EnumMember(Value = "https://schema.org/containedIn")]
        ContainedIn,
        [EnumMember(Value = "https://schema.org/containedInPlace")]
        ContainedInPlace,
        [EnumMember(Value = "https://schema.org/containsPlace")]
        ContainsPlace,
        [EnumMember(Value = "https://schema.org/containsSeason")]
        ContainsSeason,
        [EnumMember(Value = "https://schema.org/contentLocation")]
        ContentLocation,
        [EnumMember(Value = "https://schema.org/contentRating")]
        ContentRating,
        [EnumMember(Value = "https://schema.org/contentReferenceTime")]
        ContentReferenceTime,
        [EnumMember(Value = "https://schema.org/contentSize")]
        ContentSize,
        [EnumMember(Value = "https://schema.org/contentType")]
        ContentType,
        [EnumMember(Value = "https://schema.org/contentUrl")]
        ContentUrl,
        [EnumMember(Value = "https://schema.org/contraindication")]
        Contraindication,
        [EnumMember(Value = "https://schema.org/contributor")]
        Contributor,
        [EnumMember(Value = "https://schema.org/cookTime")]
        CookTime,
        [EnumMember(Value = "https://schema.org/cookingMethod")]
        CookingMethod,
        [EnumMember(Value = "https://schema.org/copyrightHolder")]
        CopyrightHolder,
        [EnumMember(Value = "https://schema.org/copyrightNotice")]
        CopyrightNotice,
        [EnumMember(Value = "https://schema.org/copyrightYear")]
        CopyrightYear,
        [EnumMember(Value = "https://schema.org/correction")]
        Correction,
        [EnumMember(Value = "https://schema.org/correctionsPolicy")]
        CorrectionsPolicy,
        [EnumMember(Value = "https://schema.org/costCategory")]
        CostCategory,
        [EnumMember(Value = "https://schema.org/costCurrency")]
        CostCurrency,
        [EnumMember(Value = "https://schema.org/costOrigin")]
        CostOrigin,
        [EnumMember(Value = "https://schema.org/costPerUnit")]
        CostPerUnit,
        [EnumMember(Value = "https://schema.org/countriesNotSupported")]
        CountriesNotSupported,
        [EnumMember(Value = "https://schema.org/countriesSupported")]
        CountriesSupported,
        [EnumMember(Value = "https://schema.org/countryOfAssembly")]
        CountryOfAssembly,
        [EnumMember(Value = "https://schema.org/countryOfLastProcessing")]
        CountryOfLastProcessing,
        [EnumMember(Value = "https://schema.org/countryOfOrigin")]
        CountryOfOrigin,
        [EnumMember(Value = "https://schema.org/course")]
        Course,
        [EnumMember(Value = "https://schema.org/courseCode")]
        CourseCode,
        [EnumMember(Value = "https://schema.org/courseMode")]
        CourseMode,
        [EnumMember(Value = "https://schema.org/coursePrerequisites")]
        CoursePrerequisites,
        [EnumMember(Value = "https://schema.org/courseWorkload")]
        CourseWorkload,
        [EnumMember(Value = "https://schema.org/coverageEndTime")]
        CoverageEndTime,
        [EnumMember(Value = "https://schema.org/coverageStartTime")]
        CoverageStartTime,
        [EnumMember(Value = "https://schema.org/creativeWorkStatus")]
        CreativeWorkStatus,
        [EnumMember(Value = "https://schema.org/creator")]
        Creator,
        [EnumMember(Value = "https://schema.org/credentialCategory")]
        CredentialCategory,
        [EnumMember(Value = "https://schema.org/creditText")]
        CreditText,
        [EnumMember(Value = "https://schema.org/creditedTo")]
        CreditedTo,
        [EnumMember(Value = "https://schema.org/cssSelector")]
        CssSelector,
        [EnumMember(Value = "https://schema.org/currenciesAccepted")]
        CurrenciesAccepted,
        [EnumMember(Value = "https://schema.org/currency")]
        Currency,
        [EnumMember(Value = "https://schema.org/currentExchangeRate")]
        CurrentExchangeRate,
        [EnumMember(Value = "https://schema.org/customer")]
        Customer,
        [EnumMember(Value = "https://schema.org/customerRemorseReturnFees")]
        CustomerRemorseReturnFees,
        [EnumMember(Value = "https://schema.org/customerRemorseReturnLabelSource")]
        CustomerRemorseReturnLabelSource,
        [EnumMember(Value = "https://schema.org/customerRemorseReturnShippingFeesAmount")]
        CustomerRemorseReturnShippingFeesAmount,
        [EnumMember(Value = "https://schema.org/cutoffTime")]
        CutoffTime,
        [EnumMember(Value = "https://schema.org/cvdCollectionDate")]
        CvdCollectionDate,
        [EnumMember(Value = "https://schema.org/cvdFacilityCounty")]
        CvdFacilityCounty,
        [EnumMember(Value = "https://schema.org/cvdFacilityId")]
        CvdFacilityId,
        [EnumMember(Value = "https://schema.org/cvdNumBeds")]
        CvdNumBeds,
        [EnumMember(Value = "https://schema.org/cvdNumBedsOcc")]
        CvdNumBedsOcc,
        [EnumMember(Value = "https://schema.org/cvdNumC19Died")]
        CvdNumC19Died,
        [EnumMember(Value = "https://schema.org/cvdNumC19HOPats")]
        CvdNumC19HOPats,
        [EnumMember(Value = "https://schema.org/cvdNumC19HospPats")]
        CvdNumC19HospPats,
        [EnumMember(Value = "https://schema.org/cvdNumC19MechVentPats")]
        CvdNumC19MechVentPats,
        [EnumMember(Value = "https://schema.org/cvdNumC19OFMechVentPats")]
        CvdNumC19OFMechVentPats,
        [EnumMember(Value = "https://schema.org/cvdNumC19OverflowPats")]
        CvdNumC19OverflowPats,
        [EnumMember(Value = "https://schema.org/cvdNumICUBeds")]
        CvdNumICUBeds,
        [EnumMember(Value = "https://schema.org/cvdNumICUBedsOcc")]
        CvdNumICUBedsOcc,
        [EnumMember(Value = "https://schema.org/cvdNumTotBeds")]
        CvdNumTotBeds,
        [EnumMember(Value = "https://schema.org/cvdNumVent")]
        CvdNumVent,
        [EnumMember(Value = "https://schema.org/cvdNumVentUse")]
        CvdNumVentUse,
        [EnumMember(Value = "https://schema.org/dataFeedElement")]
        DataFeedElement,
        [EnumMember(Value = "https://schema.org/dataset")]
        Dataset,
        [EnumMember(Value = "https://schema.org/datasetTimeInterval")]
        DatasetTimeInterval,
        [EnumMember(Value = "https://schema.org/dateCreated")]
        DateCreated,
        [EnumMember(Value = "https://schema.org/dateDeleted")]
        DateDeleted,
        [EnumMember(Value = "https://schema.org/dateIssued")]
        DateIssued,
        [EnumMember(Value = "https://schema.org/dateModified")]
        DateModified,
        [EnumMember(Value = "https://schema.org/datePosted")]
        DatePosted,
        [EnumMember(Value = "https://schema.org/datePublished")]
        DatePublished,
        [EnumMember(Value = "https://schema.org/dateRead")]
        DateRead,
        [EnumMember(Value = "https://schema.org/dateReceived")]
        DateReceived,
        [EnumMember(Value = "https://schema.org/dateSent")]
        DateSent,
        [EnumMember(Value = "https://schema.org/dateVehicleFirstRegistered")]
        DateVehicleFirstRegistered,
        [EnumMember(Value = "https://schema.org/dateline")]
        Dateline,
        [EnumMember(Value = "https://schema.org/dayOfWeek")]
        DayOfWeek,
        [EnumMember(Value = "https://schema.org/deathDate")]
        DeathDate,
        [EnumMember(Value = "https://schema.org/deathPlace")]
        DeathPlace,
        [EnumMember(Value = "https://schema.org/defaultValue")]
        DefaultValue,
        [EnumMember(Value = "https://schema.org/deliveryAddress")]
        DeliveryAddress,
        [EnumMember(Value = "https://schema.org/deliveryLeadTime")]
        DeliveryLeadTime,
        [EnumMember(Value = "https://schema.org/deliveryMethod")]
        DeliveryMethod,
        [EnumMember(Value = "https://schema.org/deliveryStatus")]
        DeliveryStatus,
        [EnumMember(Value = "https://schema.org/deliveryTime")]
        DeliveryTime,
        [EnumMember(Value = "https://schema.org/department")]
        Department,
        [EnumMember(Value = "https://schema.org/departureAirport")]
        DepartureAirport,
        [EnumMember(Value = "https://schema.org/departureBoatTerminal")]
        DepartureBoatTerminal,
        [EnumMember(Value = "https://schema.org/departureBusStop")]
        DepartureBusStop,
        [EnumMember(Value = "https://schema.org/departureGate")]
        DepartureGate,
        [EnumMember(Value = "https://schema.org/departurePlatform")]
        DeparturePlatform,
        [EnumMember(Value = "https://schema.org/departureStation")]
        DepartureStation,
        [EnumMember(Value = "https://schema.org/departureTerminal")]
        DepartureTerminal,
        [EnumMember(Value = "https://schema.org/departureTime")]
        DepartureTime,
        [EnumMember(Value = "https://schema.org/dependencies")]
        Dependencies,
        [EnumMember(Value = "https://schema.org/depth")]
        Depth,
        [EnumMember(Value = "https://schema.org/description")]
        Description,
        [EnumMember(Value = "https://schema.org/device")]
        Device,
        [EnumMember(Value = "https://schema.org/diagnosis")]
        Diagnosis,
        [EnumMember(Value = "https://schema.org/diagram")]
        Diagram,
        [EnumMember(Value = "https://schema.org/diet")]
        Diet,
        [EnumMember(Value = "https://schema.org/dietFeatures")]
        DietFeatures,
        [EnumMember(Value = "https://schema.org/differentialDiagnosis")]
        DifferentialDiagnosis,
        [EnumMember(Value = "https://schema.org/directApply")]
        DirectApply,
        [EnumMember(Value = "https://schema.org/director")]
        Director,
        [EnumMember(Value = "https://schema.org/directors")]
        Directors,
        [EnumMember(Value = "https://schema.org/disambiguatingDescription")]
        DisambiguatingDescription,
        [EnumMember(Value = "https://schema.org/discount")]
        Discount,
        [EnumMember(Value = "https://schema.org/discountCode")]
        DiscountCode,
        [EnumMember(Value = "https://schema.org/discountCurrency")]
        DiscountCurrency,
        [EnumMember(Value = "https://schema.org/discusses")]
        Discusses,
        [EnumMember(Value = "https://schema.org/discussionUrl")]
        DiscussionUrl,
        [EnumMember(Value = "https://schema.org/diseasePreventionInfo")]
        DiseasePreventionInfo,
        [EnumMember(Value = "https://schema.org/diseaseSpreadStatistics")]
        DiseaseSpreadStatistics,
        [EnumMember(Value = "https://schema.org/dissolutionDate")]
        DissolutionDate,
        [EnumMember(Value = "https://schema.org/distance")]
        Distance,
        [EnumMember(Value = "https://schema.org/distinguishingSign")]
        DistinguishingSign,
        [EnumMember(Value = "https://schema.org/distribution")]
        Distribution,
        [EnumMember(Value = "https://schema.org/diversityPolicy")]
        DiversityPolicy,
        [EnumMember(Value = "https://schema.org/diversityStaffingReport")]
        DiversityStaffingReport,
        [EnumMember(Value = "https://schema.org/documentation")]
        Documentation,
        [EnumMember(Value = "https://schema.org/doesNotShip")]
        DoesNotShip,
        [EnumMember(Value = "https://schema.org/domainIncludes")]
        DomainIncludes,
        [EnumMember(Value = "https://schema.org/domiciledMortgage")]
        DomiciledMortgage,
        [EnumMember(Value = "https://schema.org/doorTime")]
        DoorTime,
        [EnumMember(Value = "https://schema.org/dosageForm")]
        DosageForm,
        [EnumMember(Value = "https://schema.org/doseSchedule")]
        DoseSchedule,
        [EnumMember(Value = "https://schema.org/doseUnit")]
        DoseUnit,
        [EnumMember(Value = "https://schema.org/doseValue")]
        DoseValue,
        [EnumMember(Value = "https://schema.org/downPayment")]
        DownPayment,
        [EnumMember(Value = "https://schema.org/downloadUrl")]
        DownloadUrl,
        [EnumMember(Value = "https://schema.org/downvoteCount")]
        DownvoteCount,
        [EnumMember(Value = "https://schema.org/drainsTo")]
        DrainsTo,
        [EnumMember(Value = "https://schema.org/driveWheelConfiguration")]
        DriveWheelConfiguration,
        [EnumMember(Value = "https://schema.org/dropoffLocation")]
        DropoffLocation,
        [EnumMember(Value = "https://schema.org/dropoffTime")]
        DropoffTime,
        [EnumMember(Value = "https://schema.org/drug")]
        Drug,
        [EnumMember(Value = "https://schema.org/drugClass")]
        DrugClass,
        [EnumMember(Value = "https://schema.org/drugUnit")]
        DrugUnit,
        [EnumMember(Value = "https://schema.org/duns")]
        Duns,
        [EnumMember(Value = "https://schema.org/duplicateTherapy")]
        DuplicateTherapy,
        [EnumMember(Value = "https://schema.org/duration")]
        Duration,
        [EnumMember(Value = "https://schema.org/durationOfWarranty")]
        DurationOfWarranty,
        [EnumMember(Value = "https://schema.org/duringMedia")]
        DuringMedia,
        [EnumMember(Value = "https://schema.org/earlyPrepaymentPenalty")]
        EarlyPrepaymentPenalty,
        [EnumMember(Value = "https://schema.org/editEIDR")]
        EditEIDR,
        [EnumMember(Value = "https://schema.org/editor")]
        Editor,
        [EnumMember(Value = "https://schema.org/eduQuestionType")]
        EduQuestionType,
        [EnumMember(Value = "https://schema.org/educationRequirements")]
        EducationRequirements,
        [EnumMember(Value = "https://schema.org/educationalAlignment")]
        EducationalAlignment,
        [EnumMember(Value = "https://schema.org/educationalCredentialAwarded")]
        EducationalCredentialAwarded,
        [EnumMember(Value = "https://schema.org/educationalFramework")]
        EducationalFramework,
        [EnumMember(Value = "https://schema.org/educationalLevel")]
        EducationalLevel,
        [EnumMember(Value = "https://schema.org/educationalProgramMode")]
        EducationalProgramMode,
        [EnumMember(Value = "https://schema.org/educationalRole")]
        EducationalRole,
        [EnumMember(Value = "https://schema.org/educationalUse")]
        EducationalUse,
        [EnumMember(Value = "https://schema.org/elevation")]
        Elevation,
        [EnumMember(Value = "https://schema.org/eligibilityToWorkRequirement")]
        EligibilityToWorkRequirement,
        [EnumMember(Value = "https://schema.org/eligibleCustomerType")]
        EligibleCustomerType,
        [EnumMember(Value = "https://schema.org/eligibleDuration")]
        EligibleDuration,
        [EnumMember(Value = "https://schema.org/eligibleQuantity")]
        EligibleQuantity,
        [EnumMember(Value = "https://schema.org/eligibleRegion")]
        EligibleRegion,
        [EnumMember(Value = "https://schema.org/eligibleTransactionVolume")]
        EligibleTransactionVolume,
        [EnumMember(Value = "https://schema.org/email")]
        Email,
        [EnumMember(Value = "https://schema.org/embedUrl")]
        EmbedUrl,
        [EnumMember(Value = "https://schema.org/embeddedTextCaption")]
        EmbeddedTextCaption,
        [EnumMember(Value = "https://schema.org/emissionsCO2")]
        EmissionsCO2,
        [EnumMember(Value = "https://schema.org/employee")]
        Employee,
        [EnumMember(Value = "https://schema.org/employees")]
        Employees,
        [EnumMember(Value = "https://schema.org/employerOverview")]
        EmployerOverview,
        [EnumMember(Value = "https://schema.org/employmentType")]
        EmploymentType,
        [EnumMember(Value = "https://schema.org/employmentUnit")]
        EmploymentUnit,
        [EnumMember(Value = "https://schema.org/encodesBioChemEntity")]
        EncodesBioChemEntity,
        [EnumMember(Value = "https://schema.org/encodesCreativeWork")]
        EncodesCreativeWork,
        [EnumMember(Value = "https://schema.org/encoding")]
        Encoding,
        [EnumMember(Value = "https://schema.org/encodingFormat")]
        EncodingFormat,
        [EnumMember(Value = "https://schema.org/encodingType")]
        EncodingType,
        [EnumMember(Value = "https://schema.org/encodings")]
        Encodings,
        [EnumMember(Value = "https://schema.org/endDate")]
        EndDate,
        [EnumMember(Value = "https://schema.org/endOffset")]
        EndOffset,
        [EnumMember(Value = "https://schema.org/endTime")]
        EndTime,
        [EnumMember(Value = "https://schema.org/endorsee")]
        Endorsee,
        [EnumMember(Value = "https://schema.org/endorsers")]
        Endorsers,
        [EnumMember(Value = "https://schema.org/energyEfficiencyScaleMax")]
        EnergyEfficiencyScaleMax,
        [EnumMember(Value = "https://schema.org/energyEfficiencyScaleMin")]
        EnergyEfficiencyScaleMin,
        [EnumMember(Value = "https://schema.org/engineDisplacement")]
        EngineDisplacement,
        [EnumMember(Value = "https://schema.org/enginePower")]
        EnginePower,
        [EnumMember(Value = "https://schema.org/engineType")]
        EngineType,
        [EnumMember(Value = "https://schema.org/entertainmentBusiness")]
        EntertainmentBusiness,
        [EnumMember(Value = "https://schema.org/epidemiology")]
        Epidemiology,
        [EnumMember(Value = "https://schema.org/episode")]
        Episode,
        [EnumMember(Value = "https://schema.org/episodeNumber")]
        EpisodeNumber,
        [EnumMember(Value = "https://schema.org/episodes")]
        Episodes,
        [EnumMember(Value = "https://schema.org/equal")]
        Equal,
        [EnumMember(Value = "https://schema.org/error")]
        Error,
        [EnumMember(Value = "https://schema.org/estimatedCost")]
        EstimatedCost,
        [EnumMember(Value = "https://schema.org/estimatedFlightDuration")]
        EstimatedFlightDuration,
        [EnumMember(Value = "https://schema.org/estimatedSalary")]
        EstimatedSalary,
        [EnumMember(Value = "https://schema.org/estimatesRiskOf")]
        EstimatesRiskOf,
        [EnumMember(Value = "https://schema.org/ethicsPolicy")]
        EthicsPolicy,
        [EnumMember(Value = "https://schema.org/event")]
        Event,
        [EnumMember(Value = "https://schema.org/eventAttendanceMode")]
        EventAttendanceMode,
        [EnumMember(Value = "https://schema.org/eventSchedule")]
        EventSchedule,
        [EnumMember(Value = "https://schema.org/eventStatus")]
        EventStatus,
        [EnumMember(Value = "https://schema.org/events")]
        Events,
        [EnumMember(Value = "https://schema.org/evidenceLevel")]
        EvidenceLevel,
        [EnumMember(Value = "https://schema.org/evidenceOrigin")]
        EvidenceOrigin,
        [EnumMember(Value = "https://schema.org/exampleOfWork")]
        ExampleOfWork,
        [EnumMember(Value = "https://schema.org/exceptDate")]
        ExceptDate,
        [EnumMember(Value = "https://schema.org/exchangeRateSpread")]
        ExchangeRateSpread,
        [EnumMember(Value = "https://schema.org/executableLibraryName")]
        ExecutableLibraryName,
        [EnumMember(Value = "https://schema.org/exerciseCourse")]
        ExerciseCourse,
        [EnumMember(Value = "https://schema.org/exercisePlan")]
        ExercisePlan,
        [EnumMember(Value = "https://schema.org/exerciseRelatedDiet")]
        ExerciseRelatedDiet,
        [EnumMember(Value = "https://schema.org/exerciseType")]
        ExerciseType,
        [EnumMember(Value = "https://schema.org/exifData")]
        ExifData,
        [EnumMember(Value = "https://schema.org/expectedArrivalFrom")]
        ExpectedArrivalFrom,
        [EnumMember(Value = "https://schema.org/expectedArrivalUntil")]
        ExpectedArrivalUntil,
        [EnumMember(Value = "https://schema.org/expectedPrognosis")]
        ExpectedPrognosis,
        [EnumMember(Value = "https://schema.org/expectsAcceptanceOf")]
        ExpectsAcceptanceOf,
        [EnumMember(Value = "https://schema.org/experienceInPlaceOfEducation")]
        ExperienceInPlaceOfEducation,
        [EnumMember(Value = "https://schema.org/experienceRequirements")]
        ExperienceRequirements,
        [EnumMember(Value = "https://schema.org/expertConsiderations")]
        ExpertConsiderations,
        [EnumMember(Value = "https://schema.org/expires")]
        Expires,
        [EnumMember(Value = "https://schema.org/expressedIn")]
        ExpressedIn,
        [EnumMember(Value = "https://schema.org/familyName")]
        FamilyName,
        [EnumMember(Value = "https://schema.org/fatContent")]
        FatContent,
        [EnumMember(Value = "https://schema.org/faxNumber")]
        FaxNumber,
        [EnumMember(Value = "https://schema.org/featureList")]
        FeatureList,
        [EnumMember(Value = "https://schema.org/feesAndCommissionsSpecification")]
        FeesAndCommissionsSpecification,
        [EnumMember(Value = "https://schema.org/fiberContent")]
        FiberContent,
        [EnumMember(Value = "https://schema.org/fileFormat")]
        FileFormat,
        [EnumMember(Value = "https://schema.org/fileSize")]
        FileSize,
        [EnumMember(Value = "https://schema.org/financialAidEligible")]
        FinancialAidEligible,
        [EnumMember(Value = "https://schema.org/firstAppearance")]
        FirstAppearance,
        [EnumMember(Value = "https://schema.org/firstPerformance")]
        FirstPerformance,
        [EnumMember(Value = "https://schema.org/flightDistance")]
        FlightDistance,
        [EnumMember(Value = "https://schema.org/flightNumber")]
        FlightNumber,
        [EnumMember(Value = "https://schema.org/floorLevel")]
        FloorLevel,
        [EnumMember(Value = "https://schema.org/floorLimit")]
        FloorLimit,
        [EnumMember(Value = "https://schema.org/floorSize")]
        FloorSize,
        [EnumMember(Value = "https://schema.org/followee")]
        Followee,
        [EnumMember(Value = "https://schema.org/follows")]
        Follows,
        [EnumMember(Value = "https://schema.org/followup")]
        Followup,
        [EnumMember(Value = "https://schema.org/foodEstablishment")]
        FoodEstablishment,
        [EnumMember(Value = "https://schema.org/foodEvent")]
        FoodEvent,
        [EnumMember(Value = "https://schema.org/foodWarning")]
        FoodWarning,
        [EnumMember(Value = "https://schema.org/founder")]
        Founder,
        [EnumMember(Value = "https://schema.org/founders")]
        Founders,
        [EnumMember(Value = "https://schema.org/foundingDate")]
        FoundingDate,
        [EnumMember(Value = "https://schema.org/foundingLocation")]
        FoundingLocation,
        [EnumMember(Value = "https://schema.org/free")]
        Free,
        [EnumMember(Value = "https://schema.org/freeShippingThreshold")]
        FreeShippingThreshold,
        [EnumMember(Value = "https://schema.org/frequency")]
        Frequency,
        [EnumMember(Value = "https://schema.org/fromLocation")]
        FromLocation,
        [EnumMember(Value = "https://schema.org/fuelCapacity")]
        FuelCapacity,
        [EnumMember(Value = "https://schema.org/fuelConsumption")]
        FuelConsumption,
        [EnumMember(Value = "https://schema.org/fuelEfficiency")]
        FuelEfficiency,
        [EnumMember(Value = "https://schema.org/fuelType")]
        FuelType,
        [EnumMember(Value = "https://schema.org/functionalClass")]
        FunctionalClass,
        [EnumMember(Value = "https://schema.org/fundedItem")]
        FundedItem,
        [EnumMember(Value = "https://schema.org/funder")]
        Funder,
        [EnumMember(Value = "https://schema.org/game")]
        Game,
        [EnumMember(Value = "https://schema.org/gameItem")]
        GameItem,
        [EnumMember(Value = "https://schema.org/gameLocation")]
        GameLocation,
        [EnumMember(Value = "https://schema.org/gamePlatform")]
        GamePlatform,
        [EnumMember(Value = "https://schema.org/gameServer")]
        GameServer,
        [EnumMember(Value = "https://schema.org/gameTip")]
        GameTip,
        [EnumMember(Value = "https://schema.org/gender")]
        Gender,
        [EnumMember(Value = "https://schema.org/genre")]
        Genre,
        [EnumMember(Value = "https://schema.org/geo")]
        Geo,
        [EnumMember(Value = "https://schema.org/geoContains")]
        GeoContains,
        [EnumMember(Value = "https://schema.org/geoCoveredBy")]
        GeoCoveredBy,
        [EnumMember(Value = "https://schema.org/geoCovers")]
        GeoCovers,
        [EnumMember(Value = "https://schema.org/geoCrosses")]
        GeoCrosses,
        [EnumMember(Value = "https://schema.org/geoDisjoint")]
        GeoDisjoint,
        [EnumMember(Value = "https://schema.org/geoEquals")]
        GeoEquals,
        [EnumMember(Value = "https://schema.org/geoIntersects")]
        GeoIntersects,
        [EnumMember(Value = "https://schema.org/geoMidpoint")]
        GeoMidpoint,
        [EnumMember(Value = "https://schema.org/geoOverlaps")]
        GeoOverlaps,
        [EnumMember(Value = "https://schema.org/geoRadius")]
        GeoRadius,
        [EnumMember(Value = "https://schema.org/geoTouches")]
        GeoTouches,
        [EnumMember(Value = "https://schema.org/geoWithin")]
        GeoWithin,
        [EnumMember(Value = "https://schema.org/geographicArea")]
        GeographicArea,
        [EnumMember(Value = "https://schema.org/gettingTestedInfo")]
        GettingTestedInfo,
        [EnumMember(Value = "https://schema.org/givenName")]
        GivenName,
        [EnumMember(Value = "https://schema.org/globalLocationNumber")]
        GlobalLocationNumber,
        [EnumMember(Value = "https://schema.org/governmentBenefitsInfo")]
        GovernmentBenefitsInfo,
        [EnumMember(Value = "https://schema.org/gracePeriod")]
        GracePeriod,
        [EnumMember(Value = "https://schema.org/grantee")]
        Grantee,
        [EnumMember(Value = "https://schema.org/greater")]
        Greater,
        [EnumMember(Value = "https://schema.org/greaterOrEqual")]
        GreaterOrEqual,
        [EnumMember(Value = "https://schema.org/gtin")]
        Gtin,
        [EnumMember(Value = "https://schema.org/gtin12")]
        Gtin12,
        [EnumMember(Value = "https://schema.org/gtin13")]
        Gtin13,
        [EnumMember(Value = "https://schema.org/gtin14")]
        Gtin14,
        [EnumMember(Value = "https://schema.org/gtin8")]
        Gtin8,
        [EnumMember(Value = "https://schema.org/guideline")]
        Guideline,
        [EnumMember(Value = "https://schema.org/guidelineDate")]
        GuidelineDate,
        [EnumMember(Value = "https://schema.org/guidelineSubject")]
        GuidelineSubject,
        [EnumMember(Value = "https://schema.org/handlingTime")]
        HandlingTime,
        [EnumMember(Value = "https://schema.org/hasBioChemEntityPart")]
        HasBioChemEntityPart,
        [EnumMember(Value = "https://schema.org/hasBioPolymerSequence")]
        HasBioPolymerSequence,
        [EnumMember(Value = "https://schema.org/hasBroadcastChannel")]
        HasBroadcastChannel,
        [EnumMember(Value = "https://schema.org/hasCategoryCode")]
        HasCategoryCode,
        [EnumMember(Value = "https://schema.org/hasCourse")]
        HasCourse,
        [EnumMember(Value = "https://schema.org/hasCourseInstance")]
        HasCourseInstance,
        [EnumMember(Value = "https://schema.org/hasCredential")]
        HasCredential,
        [EnumMember(Value = "https://schema.org/hasDefinedTerm")]
        HasDefinedTerm,
        [EnumMember(Value = "https://schema.org/hasDeliveryMethod")]
        HasDeliveryMethod,
        [EnumMember(Value = "https://schema.org/hasDigitalDocumentPermission")]
        HasDigitalDocumentPermission,
        [EnumMember(Value = "https://schema.org/hasDriveThroughService")]
        HasDriveThroughService,
        [EnumMember(Value = "https://schema.org/hasEnergyConsumptionDetails")]
        HasEnergyConsumptionDetails,
        [EnumMember(Value = "https://schema.org/hasEnergyEfficiencyCategory")]
        HasEnergyEfficiencyCategory,
        [EnumMember(Value = "https://schema.org/hasHealthAspect")]
        HasHealthAspect,
        [EnumMember(Value = "https://schema.org/hasMap")]
        HasMap,
        [EnumMember(Value = "https://schema.org/hasMeasurement")]
        HasMeasurement,
        [EnumMember(Value = "https://schema.org/hasMenu")]
        HasMenu,
        [EnumMember(Value = "https://schema.org/hasMenuItem")]
        HasMenuItem,
        [EnumMember(Value = "https://schema.org/hasMenuSection")]
        HasMenuSection,
        [EnumMember(Value = "https://schema.org/hasMerchantReturnPolicy")]
        HasMerchantReturnPolicy,
        [EnumMember(Value = "https://schema.org/hasMolecularFunction")]
        HasMolecularFunction,
        [EnumMember(Value = "https://schema.org/hasOccupation")]
        HasOccupation,
        [EnumMember(Value = "https://schema.org/hasOfferCatalog")]
        HasOfferCatalog,
        [EnumMember(Value = "https://schema.org/hasPOS")]
        HasPOS,
        [EnumMember(Value = "https://schema.org/hasPart")]
        HasPart,
        [EnumMember(Value = "https://schema.org/hasRepresentation")]
        HasRepresentation,
        [EnumMember(Value = "https://schema.org/hasVariant")]
        HasVariant,
        [EnumMember(Value = "https://schema.org/headline")]
        Headline,
        [EnumMember(Value = "https://schema.org/healthCondition")]
        HealthCondition,
        [EnumMember(Value = "https://schema.org/healthPlanCoinsuranceOption")]
        HealthPlanCoinsuranceOption,
        [EnumMember(Value = "https://schema.org/healthPlanCoinsuranceRate")]
        HealthPlanCoinsuranceRate,
        [EnumMember(Value = "https://schema.org/healthPlanCopay")]
        HealthPlanCopay,
        [EnumMember(Value = "https://schema.org/healthPlanCopayOption")]
        HealthPlanCopayOption,
        [EnumMember(Value = "https://schema.org/healthPlanCostSharing")]
        HealthPlanCostSharing,
        [EnumMember(Value = "https://schema.org/healthPlanDrugOption")]
        HealthPlanDrugOption,
        [EnumMember(Value = "https://schema.org/healthPlanDrugTier")]
        HealthPlanDrugTier,
        [EnumMember(Value = "https://schema.org/healthPlanId")]
        HealthPlanId,
        [EnumMember(Value = "https://schema.org/healthPlanMarketingUrl")]
        HealthPlanMarketingUrl,
        [EnumMember(Value = "https://schema.org/healthPlanNetworkId")]
        HealthPlanNetworkId,
        [EnumMember(Value = "https://schema.org/healthPlanNetworkTier")]
        HealthPlanNetworkTier,
        [EnumMember(Value = "https://schema.org/healthPlanPharmacyCategory")]
        HealthPlanPharmacyCategory,
        [EnumMember(Value = "https://schema.org/healthcareReportingData")]
        HealthcareReportingData,
        [EnumMember(Value = "https://schema.org/height")]
        Height,
        [EnumMember(Value = "https://schema.org/highPrice")]
        HighPrice,
        [EnumMember(Value = "https://schema.org/hiringOrganization")]
        HiringOrganization,
        [EnumMember(Value = "https://schema.org/holdingArchive")]
        HoldingArchive,
        [EnumMember(Value = "https://schema.org/homeLocation")]
        HomeLocation,
        [EnumMember(Value = "https://schema.org/homeTeam")]
        HomeTeam,
        [EnumMember(Value = "https://schema.org/honorificPrefix")]
        HonorificPrefix,
        [EnumMember(Value = "https://schema.org/honorificSuffix")]
        HonorificSuffix,
        [EnumMember(Value = "https://schema.org/hospitalAffiliation")]
        HospitalAffiliation,
        [EnumMember(Value = "https://schema.org/hostingOrganization")]
        HostingOrganization,
        [EnumMember(Value = "https://schema.org/hoursAvailable")]
        HoursAvailable,
        [EnumMember(Value = "https://schema.org/howPerformed")]
        HowPerformed,
        [EnumMember(Value = "https://schema.org/httpMethod")]
        HttpMethod,
        [EnumMember(Value = "https://schema.org/iataCode")]
        IataCode,
        [EnumMember(Value = "https://schema.org/icaoCode")]
        IcaoCode,
        [EnumMember(Value = "https://schema.org/identifier")]
        Identifier,
        [EnumMember(Value = "https://schema.org/identifyingExam")]
        IdentifyingExam,
        [EnumMember(Value = "https://schema.org/identifyingTest")]
        IdentifyingTest,
        [EnumMember(Value = "https://schema.org/illustrator")]
        Illustrator,
        [EnumMember(Value = "https://schema.org/image")]
        Image,
        [EnumMember(Value = "https://schema.org/imagingTechnique")]
        ImagingTechnique,
        [EnumMember(Value = "https://schema.org/inAlbum")]
        InAlbum,
        [EnumMember(Value = "https://schema.org/inBroadcastLineup")]
        InBroadcastLineup,
        [EnumMember(Value = "https://schema.org/inChI")]
        InChI,
        [EnumMember(Value = "https://schema.org/inChIKey")]
        InChIKey,
        [EnumMember(Value = "https://schema.org/inCodeSet")]
        InCodeSet,
        [EnumMember(Value = "https://schema.org/inDefinedTermSet")]
        InDefinedTermSet,
        [EnumMember(Value = "https://schema.org/inLanguage")]
        InLanguage,
        [EnumMember(Value = "https://schema.org/inPlaylist")]
        InPlaylist,
        [EnumMember(Value = "https://schema.org/inProductGroupWithID")]
        InProductGroupWithID,
        [EnumMember(Value = "https://schema.org/inStoreReturnsOffered")]
        InStoreReturnsOffered,
        [EnumMember(Value = "https://schema.org/inSupportOf")]
        InSupportOf,
        [EnumMember(Value = "https://schema.org/incentiveCompensation")]
        IncentiveCompensation,
        [EnumMember(Value = "https://schema.org/incentives")]
        Incentives,
        [EnumMember(Value = "https://schema.org/includedComposition")]
        IncludedComposition,
        [EnumMember(Value = "https://schema.org/includedDataCatalog")]
        IncludedDataCatalog,
        [EnumMember(Value = "https://schema.org/includedInDataCatalog")]
        IncludedInDataCatalog,
        [EnumMember(Value = "https://schema.org/includedInHealthInsurancePlan")]
        IncludedInHealthInsurancePlan,
        [EnumMember(Value = "https://schema.org/includedRiskFactor")]
        IncludedRiskFactor,
        [EnumMember(Value = "https://schema.org/includesAttraction")]
        IncludesAttraction,
        [EnumMember(Value = "https://schema.org/includesHealthPlanFormulary")]
        IncludesHealthPlanFormulary,
        [EnumMember(Value = "https://schema.org/includesHealthPlanNetwork")]
        IncludesHealthPlanNetwork,
        [EnumMember(Value = "https://schema.org/includesObject")]
        IncludesObject,
        [EnumMember(Value = "https://schema.org/increasesRiskOf")]
        IncreasesRiskOf,
        [EnumMember(Value = "https://schema.org/industry")]
        Industry,
        [EnumMember(Value = "https://schema.org/ineligibleRegion")]
        IneligibleRegion,
        [EnumMember(Value = "https://schema.org/infectiousAgent")]
        InfectiousAgent,
        [EnumMember(Value = "https://schema.org/infectiousAgentClass")]
        InfectiousAgentClass,
        [EnumMember(Value = "https://schema.org/ingredients")]
        Ingredients,
        [EnumMember(Value = "https://schema.org/inker")]
        Inker,
        [EnumMember(Value = "https://schema.org/insertion")]
        Insertion,
        [EnumMember(Value = "https://schema.org/installUrl")]
        InstallUrl,
        [EnumMember(Value = "https://schema.org/instructor")]
        Instructor,
        [EnumMember(Value = "https://schema.org/instrument")]
        Instrument,
        [EnumMember(Value = "https://schema.org/intensity")]
        Intensity,
        [EnumMember(Value = "https://schema.org/interactingDrug")]
        InteractingDrug,
        [EnumMember(Value = "https://schema.org/interactionCount")]
        InteractionCount,
        [EnumMember(Value = "https://schema.org/interactionService")]
        InteractionService,
        [EnumMember(Value = "https://schema.org/interactionStatistic")]
        InteractionStatistic,
        [EnumMember(Value = "https://schema.org/interactionType")]
        InteractionType,
        [EnumMember(Value = "https://schema.org/interactivityType")]
        InteractivityType,
        [EnumMember(Value = "https://schema.org/interestRate")]
        InterestRate,
        [EnumMember(Value = "https://schema.org/interpretedAsClaim")]
        InterpretedAsClaim,
        [EnumMember(Value = "https://schema.org/inventoryLevel")]
        InventoryLevel,
        [EnumMember(Value = "https://schema.org/inverseOf")]
        InverseOf,
        [EnumMember(Value = "https://schema.org/isAcceptingNewPatients")]
        IsAcceptingNewPatients,
        [EnumMember(Value = "https://schema.org/isAccessibleForFree")]
        IsAccessibleForFree,
        [EnumMember(Value = "https://schema.org/isAccessoryOrSparePartFor")]
        IsAccessoryOrSparePartFor,
        [EnumMember(Value = "https://schema.org/isAvailableGenerically")]
        IsAvailableGenerically,
        [EnumMember(Value = "https://schema.org/isBasedOn")]
        IsBasedOn,
        [EnumMember(Value = "https://schema.org/isBasedOnUrl")]
        IsBasedOnUrl,
        [EnumMember(Value = "https://schema.org/isConsumableFor")]
        IsConsumableFor,
        [EnumMember(Value = "https://schema.org/isEncodedByBioChemEntity")]
        IsEncodedByBioChemEntity,
        [EnumMember(Value = "https://schema.org/isFamilyFriendly")]
        IsFamilyFriendly,
        [EnumMember(Value = "https://schema.org/isGift")]
        IsGift,
        [EnumMember(Value = "https://schema.org/isInvolvedInBiologicalProcess")]
        IsInvolvedInBiologicalProcess,
        [EnumMember(Value = "https://schema.org/isLiveBroadcast")]
        IsLiveBroadcast,
        [EnumMember(Value = "https://schema.org/isLocatedInSubcellularLocation")]
        IsLocatedInSubcellularLocation,
        [EnumMember(Value = "https://schema.org/isPartOf")]
        IsPartOf,
        [EnumMember(Value = "https://schema.org/isPartOfBioChemEntity")]
        IsPartOfBioChemEntity,
        [EnumMember(Value = "https://schema.org/isPlanForApartment")]
        IsPlanForApartment,
        [EnumMember(Value = "https://schema.org/isProprietary")]
        IsProprietary,
        [EnumMember(Value = "https://schema.org/isRelatedTo")]
        IsRelatedTo,
        [EnumMember(Value = "https://schema.org/isResizable")]
        IsResizable,
        [EnumMember(Value = "https://schema.org/isSimilarTo")]
        IsSimilarTo,
        [EnumMember(Value = "https://schema.org/isUnlabelledFallback")]
        IsUnlabelledFallback,
        [EnumMember(Value = "https://schema.org/isVariantOf")]
        IsVariantOf,
        [EnumMember(Value = "https://schema.org/isbn")]
        Isbn,
        [EnumMember(Value = "https://schema.org/isicV4")]
        IsicV4,
        [EnumMember(Value = "https://schema.org/isrcCode")]
        IsrcCode,
        [EnumMember(Value = "https://schema.org/issn")]
        Issn,
        [EnumMember(Value = "https://schema.org/issueNumber")]
        IssueNumber,
        [EnumMember(Value = "https://schema.org/issuedBy")]
        IssuedBy,
        [EnumMember(Value = "https://schema.org/issuedThrough")]
        IssuedThrough,
        [EnumMember(Value = "https://schema.org/iswcCode")]
        IswcCode,
        [EnumMember(Value = "https://schema.org/item")]
        Item,
        [EnumMember(Value = "https://schema.org/itemCondition")]
        ItemCondition,
        [EnumMember(Value = "https://schema.org/itemDefectReturnFees")]
        ItemDefectReturnFees,
        [EnumMember(Value = "https://schema.org/itemDefectReturnLabelSource")]
        ItemDefectReturnLabelSource,
        [EnumMember(Value = "https://schema.org/itemDefectReturnShippingFeesAmount")]
        ItemDefectReturnShippingFeesAmount,
        [EnumMember(Value = "https://schema.org/itemListElement")]
        ItemListElement,
        [EnumMember(Value = "https://schema.org/itemListOrder")]
        ItemListOrder,
        [EnumMember(Value = "https://schema.org/itemLocation")]
        ItemLocation,
        [EnumMember(Value = "https://schema.org/itemOffered")]
        ItemOffered,
        [EnumMember(Value = "https://schema.org/itemReviewed")]
        ItemReviewed,
        [EnumMember(Value = "https://schema.org/itemShipped")]
        ItemShipped,
        [EnumMember(Value = "https://schema.org/itinerary")]
        Itinerary,
        [EnumMember(Value = "https://schema.org/iupacName")]
        IupacName,
        [EnumMember(Value = "https://schema.org/jobBenefits")]
        JobBenefits,
        [EnumMember(Value = "https://schema.org/jobImmediateStart")]
        JobImmediateStart,
        [EnumMember(Value = "https://schema.org/jobLocation")]
        JobLocation,
        [EnumMember(Value = "https://schema.org/jobLocationType")]
        JobLocationType,
        [EnumMember(Value = "https://schema.org/jobStartDate")]
        JobStartDate,
        [EnumMember(Value = "https://schema.org/jobTitle")]
        JobTitle,
        [EnumMember(Value = "https://schema.org/jurisdiction")]
        Jurisdiction,
        [EnumMember(Value = "https://schema.org/keywords")]
        Keywords,
        [EnumMember(Value = "https://schema.org/knownVehicleDamages")]
        KnownVehicleDamages,
        [EnumMember(Value = "https://schema.org/knows")]
        Knows,
        [EnumMember(Value = "https://schema.org/knowsAbout")]
        KnowsAbout,
        [EnumMember(Value = "https://schema.org/knowsLanguage")]
        KnowsLanguage,
        [EnumMember(Value = "https://schema.org/labelDetails")]
        LabelDetails,
        [EnumMember(Value = "https://schema.org/landlord")]
        Landlord,
        [EnumMember(Value = "https://schema.org/language")]
        Language,
        [EnumMember(Value = "https://schema.org/lastReviewed")]
        LastReviewed,
        [EnumMember(Value = "https://schema.org/latitude")]
        Latitude,
        [EnumMember(Value = "https://schema.org/layoutImage")]
        LayoutImage,
        [EnumMember(Value = "https://schema.org/learningResourceType")]
        LearningResourceType,
        [EnumMember(Value = "https://schema.org/leaseLength")]
        LeaseLength,
        [EnumMember(Value = "https://schema.org/legalName")]
        LegalName,
        [EnumMember(Value = "https://schema.org/legalStatus")]
        LegalStatus,
        [EnumMember(Value = "https://schema.org/legislationApplies")]
        LegislationApplies,
        [EnumMember(Value = "https://schema.org/legislationChanges")]
        LegislationChanges,
        [EnumMember(Value = "https://schema.org/legislationConsolidates")]
        LegislationConsolidates,
        [EnumMember(Value = "https://schema.org/legislationDate")]
        LegislationDate,
        [EnumMember(Value = "https://schema.org/legislationDateVersion")]
        LegislationDateVersion,
        [EnumMember(Value = "https://schema.org/legislationIdentifier")]
        LegislationIdentifier,
        [EnumMember(Value = "https://schema.org/legislationJurisdiction")]
        LegislationJurisdiction,
        [EnumMember(Value = "https://schema.org/legislationLegalForce")]
        LegislationLegalForce,
        [EnumMember(Value = "https://schema.org/legislationLegalValue")]
        LegislationLegalValue,
        [EnumMember(Value = "https://schema.org/legislationPassedBy")]
        LegislationPassedBy,
        [EnumMember(Value = "https://schema.org/legislationResponsible")]
        LegislationResponsible,
        [EnumMember(Value = "https://schema.org/legislationTransposes")]
        LegislationTransposes,
        [EnumMember(Value = "https://schema.org/legislationType")]
        LegislationType,
        [EnumMember(Value = "https://schema.org/leiCode")]
        LeiCode,
        [EnumMember(Value = "https://schema.org/lender")]
        Lender,
        [EnumMember(Value = "https://schema.org/lesser")]
        Lesser,
        [EnumMember(Value = "https://schema.org/lesserOrEqual")]
        LesserOrEqual,
        [EnumMember(Value = "https://schema.org/letterer")]
        Letterer,
        [EnumMember(Value = "https://schema.org/license")]
        License,
        [EnumMember(Value = "https://schema.org/line")]
        Line,
        [EnumMember(Value = "https://schema.org/linkRelationship")]
        LinkRelationship,
        [EnumMember(Value = "https://schema.org/liveBlogUpdate")]
        LiveBlogUpdate,
        [EnumMember(Value = "https://schema.org/loanMortgageMandateAmount")]
        LoanMortgageMandateAmount,
        [EnumMember(Value = "https://schema.org/loanPaymentAmount")]
        LoanPaymentAmount,
        [EnumMember(Value = "https://schema.org/loanPaymentFrequency")]
        LoanPaymentFrequency,
        [EnumMember(Value = "https://schema.org/loanRepaymentForm")]
        LoanRepaymentForm,
        [EnumMember(Value = "https://schema.org/loanTerm")]
        LoanTerm,
        [EnumMember(Value = "https://schema.org/loanType")]
        LoanType,
        [EnumMember(Value = "https://schema.org/location")]
        Location,
        [EnumMember(Value = "https://schema.org/locationCreated")]
        LocationCreated,
        [EnumMember(Value = "https://schema.org/lodgingUnitDescription")]
        LodgingUnitDescription,
        [EnumMember(Value = "https://schema.org/lodgingUnitType")]
        LodgingUnitType,
        [EnumMember(Value = "https://schema.org/logo")]
        Logo,
        [EnumMember(Value = "https://schema.org/longitude")]
        Longitude,
        [EnumMember(Value = "https://schema.org/loser")]
        Loser,
        [EnumMember(Value = "https://schema.org/lowPrice")]
        LowPrice,
        [EnumMember(Value = "https://schema.org/lyricist")]
        Lyricist,
        [EnumMember(Value = "https://schema.org/lyrics")]
        Lyrics,
        [EnumMember(Value = "https://schema.org/mainContentOfPage")]
        MainContentOfPage,
        [EnumMember(Value = "https://schema.org/mainEntity")]
        MainEntity,
        [EnumMember(Value = "https://schema.org/mainEntityOfPage")]
        MainEntityOfPage,
        [EnumMember(Value = "https://schema.org/maintainer")]
        Maintainer,
        [EnumMember(Value = "https://schema.org/makesOffer")]
        MakesOffer,
        [EnumMember(Value = "https://schema.org/manufacturer")]
        Manufacturer,
        [EnumMember(Value = "https://schema.org/map")]
        Map,
        [EnumMember(Value = "https://schema.org/mapType")]
        MapType,
        [EnumMember(Value = "https://schema.org/maps")]
        Maps,
        [EnumMember(Value = "https://schema.org/marginOfError")]
        MarginOfError,
        [EnumMember(Value = "https://schema.org/masthead")]
        Masthead,
        [EnumMember(Value = "https://schema.org/material")]
        Material,
        [EnumMember(Value = "https://schema.org/materialExtent")]
        MaterialExtent,
        [EnumMember(Value = "https://schema.org/mathExpression")]
        MathExpression,
        [EnumMember(Value = "https://schema.org/maxPrice")]
        MaxPrice,
        [EnumMember(Value = "https://schema.org/maxValue")]
        MaxValue,
        [EnumMember(Value = "https://schema.org/maximumAttendeeCapacity")]
        MaximumAttendeeCapacity,
        [EnumMember(Value = "https://schema.org/maximumEnrollment")]
        MaximumEnrollment,
        [EnumMember(Value = "https://schema.org/maximumIntake")]
        MaximumIntake,
        [EnumMember(Value = "https://schema.org/maximumPhysicalAttendeeCapacity")]
        MaximumPhysicalAttendeeCapacity,
        [EnumMember(Value = "https://schema.org/maximumVirtualAttendeeCapacity")]
        MaximumVirtualAttendeeCapacity,
        [EnumMember(Value = "https://schema.org/mealService")]
        MealService,
        [EnumMember(Value = "https://schema.org/measuredProperty")]
        MeasuredProperty,
        [EnumMember(Value = "https://schema.org/measuredValue")]
        MeasuredValue,
        [EnumMember(Value = "https://schema.org/measurementTechnique")]
        MeasurementTechnique,
        [EnumMember(Value = "https://schema.org/mechanismOfAction")]
        MechanismOfAction,
        [EnumMember(Value = "https://schema.org/mediaAuthenticityCategory")]
        MediaAuthenticityCategory,
        [EnumMember(Value = "https://schema.org/mediaItemAppearance")]
        MediaItemAppearance,
        [EnumMember(Value = "https://schema.org/median")]
        Median,
        [EnumMember(Value = "https://schema.org/medicalAudience")]
        MedicalAudience,
        [EnumMember(Value = "https://schema.org/medicalSpecialty")]
        MedicalSpecialty,
        [EnumMember(Value = "https://schema.org/medicineSystem")]
        MedicineSystem,
        [EnumMember(Value = "https://schema.org/meetsEmissionStandard")]
        MeetsEmissionStandard,
        [EnumMember(Value = "https://schema.org/member")]
        Member,
        [EnumMember(Value = "https://schema.org/memberOf")]
        MemberOf,
        [EnumMember(Value = "https://schema.org/members")]
        Members,
        [EnumMember(Value = "https://schema.org/membershipNumber")]
        MembershipNumber,
        [EnumMember(Value = "https://schema.org/membershipPointsEarned")]
        MembershipPointsEarned,
        [EnumMember(Value = "https://schema.org/memoryRequirements")]
        MemoryRequirements,
        [EnumMember(Value = "https://schema.org/mentions")]
        Mentions,
        [EnumMember(Value = "https://schema.org/menu")]
        Menu,
        [EnumMember(Value = "https://schema.org/menuAddOn")]
        MenuAddOn,
        [EnumMember(Value = "https://schema.org/merchant")]
        Merchant,
        [EnumMember(Value = "https://schema.org/merchantReturnDays")]
        MerchantReturnDays,
        [EnumMember(Value = "https://schema.org/merchantReturnLink")]
        MerchantReturnLink,
        [EnumMember(Value = "https://schema.org/messageAttachment")]
        MessageAttachment,
        [EnumMember(Value = "https://schema.org/mileageFromOdometer")]
        MileageFromOdometer,
        [EnumMember(Value = "https://schema.org/minPrice")]
        MinPrice,
        [EnumMember(Value = "https://schema.org/minValue")]
        MinValue,
        [EnumMember(Value = "https://schema.org/minimumPaymentDue")]
        MinimumPaymentDue,
        [EnumMember(Value = "https://schema.org/missionCoveragePrioritiesPolicy")]
        MissionCoveragePrioritiesPolicy,
        [EnumMember(Value = "https://schema.org/model")]
        Model,
        [EnumMember(Value = "https://schema.org/modelDate")]
        ModelDate,
        [EnumMember(Value = "https://schema.org/modifiedTime")]
        ModifiedTime,
        [EnumMember(Value = "https://schema.org/molecularFormula")]
        MolecularFormula,
        [EnumMember(Value = "https://schema.org/molecularWeight")]
        MolecularWeight,
        [EnumMember(Value = "https://schema.org/monoisotopicMolecularWeight")]
        MonoisotopicMolecularWeight,
        [EnumMember(Value = "https://schema.org/monthlyMinimumRepaymentAmount")]
        MonthlyMinimumRepaymentAmount,
        [EnumMember(Value = "https://schema.org/monthsOfExperience")]
        MonthsOfExperience,
        [EnumMember(Value = "https://schema.org/mpn")]
        Mpn,
        [EnumMember(Value = "https://schema.org/multipleValues")]
        MultipleValues,
        [EnumMember(Value = "https://schema.org/muscleAction")]
        MuscleAction,
        [EnumMember(Value = "https://schema.org/musicArrangement")]
        MusicArrangement,
        [EnumMember(Value = "https://schema.org/musicBy")]
        MusicBy,
        [EnumMember(Value = "https://schema.org/musicCompositionForm")]
        MusicCompositionForm,
        [EnumMember(Value = "https://schema.org/musicGroupMember")]
        MusicGroupMember,
        [EnumMember(Value = "https://schema.org/musicReleaseFormat")]
        MusicReleaseFormat,
        [EnumMember(Value = "https://schema.org/musicalKey")]
        MusicalKey,
        [EnumMember(Value = "https://schema.org/naics")]
        Naics,
        [EnumMember(Value = "https://schema.org/name")]
        Name,
        [EnumMember(Value = "https://schema.org/namedPosition")]
        NamedPosition,
        [EnumMember(Value = "https://schema.org/nationality")]
        Nationality,
        [EnumMember(Value = "https://schema.org/naturalProgression")]
        NaturalProgression,
        [EnumMember(Value = "https://schema.org/negativeNotes")]
        NegativeNotes,
        [EnumMember(Value = "https://schema.org/nerve")]
        Nerve,
        [EnumMember(Value = "https://schema.org/nerveMotor")]
        NerveMotor,
        [EnumMember(Value = "https://schema.org/netWorth")]
        NetWorth,
        [EnumMember(Value = "https://schema.org/newsUpdatesAndGuidelines")]
        NewsUpdatesAndGuidelines,
        [EnumMember(Value = "https://schema.org/nextItem")]
        NextItem,
        [EnumMember(Value = "https://schema.org/noBylinesPolicy")]
        NoBylinesPolicy,
        [EnumMember(Value = "https://schema.org/nonEqual")]
        NonEqual,
        [EnumMember(Value = "https://schema.org/nonProprietaryName")]
        NonProprietaryName,
        [EnumMember(Value = "https://schema.org/nonprofitStatus")]
        NonprofitStatus,
        [EnumMember(Value = "https://schema.org/normalRange")]
        NormalRange,
        [EnumMember(Value = "https://schema.org/nsn")]
        Nsn,
        [EnumMember(Value = "https://schema.org/numAdults")]
        NumAdults,
        [EnumMember(Value = "https://schema.org/numChildren")]
        NumChildren,
        [EnumMember(Value = "https://schema.org/numConstraints")]
        NumConstraints,
        [EnumMember(Value = "https://schema.org/numTracks")]
        NumTracks,
        [EnumMember(Value = "https://schema.org/numberOfAccommodationUnits")]
        NumberOfAccommodationUnits,
        [EnumMember(Value = "https://schema.org/numberOfAirbags")]
        NumberOfAirbags,
        [EnumMember(Value = "https://schema.org/numberOfAvailableAccommodationUnits")]
        NumberOfAvailableAccommodationUnits,
        [EnumMember(Value = "https://schema.org/numberOfAxles")]
        NumberOfAxles,
        [EnumMember(Value = "https://schema.org/numberOfBathroomsTotal")]
        NumberOfBathroomsTotal,
        [EnumMember(Value = "https://schema.org/numberOfBedrooms")]
        NumberOfBedrooms,
        [EnumMember(Value = "https://schema.org/numberOfBeds")]
        NumberOfBeds,
        [EnumMember(Value = "https://schema.org/numberOfCredits")]
        NumberOfCredits,
        [EnumMember(Value = "https://schema.org/numberOfDoors")]
        NumberOfDoors,
        [EnumMember(Value = "https://schema.org/numberOfEmployees")]
        NumberOfEmployees,
        [EnumMember(Value = "https://schema.org/numberOfEpisodes")]
        NumberOfEpisodes,
        [EnumMember(Value = "https://schema.org/numberOfForwardGears")]
        NumberOfForwardGears,
        [EnumMember(Value = "https://schema.org/numberOfFullBathrooms")]
        NumberOfFullBathrooms,
        [EnumMember(Value = "https://schema.org/numberOfItems")]
        NumberOfItems,
        [EnumMember(Value = "https://schema.org/numberOfLoanPayments")]
        NumberOfLoanPayments,
        [EnumMember(Value = "https://schema.org/numberOfPages")]
        NumberOfPages,
        [EnumMember(Value = "https://schema.org/numberOfPartialBathrooms")]
        NumberOfPartialBathrooms,
        [EnumMember(Value = "https://schema.org/numberOfPlayers")]
        NumberOfPlayers,
        [EnumMember(Value = "https://schema.org/numberOfPreviousOwners")]
        NumberOfPreviousOwners,
        [EnumMember(Value = "https://schema.org/numberOfRooms")]
        NumberOfRooms,
        [EnumMember(Value = "https://schema.org/numberOfSeasons")]
        NumberOfSeasons,
        [EnumMember(Value = "https://schema.org/numberedPosition")]
        NumberedPosition,
        [EnumMember(Value = "https://schema.org/nutrition")]
        Nutrition,
        [EnumMember(Value = "https://schema.org/object")]
        Object,
        [EnumMember(Value = "https://schema.org/observationDate")]
        ObservationDate,
        [EnumMember(Value = "https://schema.org/observedNode")]
        ObservedNode,
        [EnumMember(Value = "https://schema.org/occupancy")]
        Occupancy,
        [EnumMember(Value = "https://schema.org/occupationLocation")]
        OccupationLocation,
        [EnumMember(Value = "https://schema.org/occupationalCategory")]
        OccupationalCategory,
        [EnumMember(Value = "https://schema.org/occupationalCredentialAwarded")]
        OccupationalCredentialAwarded,
        [EnumMember(Value = "https://schema.org/offerCount")]
        OfferCount,
        [EnumMember(Value = "https://schema.org/offeredBy")]
        OfferedBy,
        [EnumMember(Value = "https://schema.org/offers")]
        Offers,
        [EnumMember(Value = "https://schema.org/offersPrescriptionByMail")]
        OffersPrescriptionByMail,
        [EnumMember(Value = "https://schema.org/openingHours")]
        OpeningHours,
        [EnumMember(Value = "https://schema.org/openingHoursSpecification")]
        OpeningHoursSpecification,
        [EnumMember(Value = "https://schema.org/opens")]
        Opens,
        [EnumMember(Value = "https://schema.org/operatingSystem")]
        OperatingSystem,
        [EnumMember(Value = "https://schema.org/opponent")]
        Opponent,
        [EnumMember(Value = "https://schema.org/option")]
        Option,
        [EnumMember(Value = "https://schema.org/orderDate")]
        OrderDate,
        [EnumMember(Value = "https://schema.org/orderDelivery")]
        OrderDelivery,
        [EnumMember(Value = "https://schema.org/orderItemNumber")]
        OrderItemNumber,
        [EnumMember(Value = "https://schema.org/orderItemStatus")]
        OrderItemStatus,
        [EnumMember(Value = "https://schema.org/orderNumber")]
        OrderNumber,
        [EnumMember(Value = "https://schema.org/orderQuantity")]
        OrderQuantity,
        [EnumMember(Value = "https://schema.org/orderStatus")]
        OrderStatus,
        [EnumMember(Value = "https://schema.org/orderedItem")]
        OrderedItem,
        [EnumMember(Value = "https://schema.org/organizer")]
        Organizer,
        [EnumMember(Value = "https://schema.org/originAddress")]
        OriginAddress,
        [EnumMember(Value = "https://schema.org/originalMediaContextDescription")]
        OriginalMediaContextDescription,
        [EnumMember(Value = "https://schema.org/originalMediaLink")]
        OriginalMediaLink,
        [EnumMember(Value = "https://schema.org/originatesFrom")]
        OriginatesFrom,
        [EnumMember(Value = "https://schema.org/overdosage")]
        Overdosage,
        [EnumMember(Value = "https://schema.org/ownedFrom")]
        OwnedFrom,
        [EnumMember(Value = "https://schema.org/ownedThrough")]
        OwnedThrough,
        [EnumMember(Value = "https://schema.org/ownershipFundingInfo")]
        OwnershipFundingInfo,
        [EnumMember(Value = "https://schema.org/owns")]
        Owns,
        [EnumMember(Value = "https://schema.org/pageEnd")]
        PageEnd,
        [EnumMember(Value = "https://schema.org/pageStart")]
        PageStart,
        [EnumMember(Value = "https://schema.org/pagination")]
        Pagination,
        [EnumMember(Value = "https://schema.org/parent")]
        Parent,
        [EnumMember(Value = "https://schema.org/parentItem")]
        ParentItem,
        [EnumMember(Value = "https://schema.org/parentOrganization")]
        ParentOrganization,
        [EnumMember(Value = "https://schema.org/parentService")]
        ParentService,
        [EnumMember(Value = "https://schema.org/parentTaxon")]
        ParentTaxon,
        [EnumMember(Value = "https://schema.org/parents")]
        Parents,
        [EnumMember(Value = "https://schema.org/partOfEpisode")]
        PartOfEpisode,
        [EnumMember(Value = "https://schema.org/partOfInvoice")]
        PartOfInvoice,
        [EnumMember(Value = "https://schema.org/partOfOrder")]
        PartOfOrder,
        [EnumMember(Value = "https://schema.org/partOfSeason")]
        PartOfSeason,
        [EnumMember(Value = "https://schema.org/partOfSeries")]
        PartOfSeries,
        [EnumMember(Value = "https://schema.org/partOfSystem")]
        PartOfSystem,
        [EnumMember(Value = "https://schema.org/partOfTVSeries")]
        PartOfTVSeries,
        [EnumMember(Value = "https://schema.org/partOfTrip")]
        PartOfTrip,
        [EnumMember(Value = "https://schema.org/participant")]
        Participant,
        [EnumMember(Value = "https://schema.org/partySize")]
        PartySize,
        [EnumMember(Value = "https://schema.org/passengerPriorityStatus")]
        PassengerPriorityStatus,
        [EnumMember(Value = "https://schema.org/passengerSequenceNumber")]
        PassengerSequenceNumber,
        [EnumMember(Value = "https://schema.org/pathophysiology")]
        Pathophysiology,
        [EnumMember(Value = "https://schema.org/pattern")]
        Pattern,
        [EnumMember(Value = "https://schema.org/payload")]
        Payload,
        [EnumMember(Value = "https://schema.org/paymentAccepted")]
        PaymentAccepted,
        [EnumMember(Value = "https://schema.org/paymentDue")]
        PaymentDue,
        [EnumMember(Value = "https://schema.org/paymentDueDate")]
        PaymentDueDate,
        [EnumMember(Value = "https://schema.org/paymentMethod")]
        PaymentMethod,
        [EnumMember(Value = "https://schema.org/paymentMethodId")]
        PaymentMethodId,
        [EnumMember(Value = "https://schema.org/paymentStatus")]
        PaymentStatus,
        [EnumMember(Value = "https://schema.org/paymentUrl")]
        PaymentUrl,
        [EnumMember(Value = "https://schema.org/penciler")]
        Penciler,
        [EnumMember(Value = "https://schema.org/percentile10")]
        Percentile10,
        [EnumMember(Value = "https://schema.org/percentile25")]
        Percentile25,
        [EnumMember(Value = "https://schema.org/percentile75")]
        Percentile75,
        [EnumMember(Value = "https://schema.org/percentile90")]
        Percentile90,
        [EnumMember(Value = "https://schema.org/performTime")]
        PerformTime,
        [EnumMember(Value = "https://schema.org/performer")]
        Performer,
        [EnumMember(Value = "https://schema.org/performerIn")]
        PerformerIn,
        [EnumMember(Value = "https://schema.org/performers")]
        Performers,
        [EnumMember(Value = "https://schema.org/permissionType")]
        PermissionType,
        [EnumMember(Value = "https://schema.org/permissions")]
        Permissions,
        [EnumMember(Value = "https://schema.org/permitAudience")]
        PermitAudience,
        [EnumMember(Value = "https://schema.org/permittedUsage")]
        PermittedUsage,
        [EnumMember(Value = "https://schema.org/petsAllowed")]
        PetsAllowed,
        [EnumMember(Value = "https://schema.org/phoneticText")]
        PhoneticText,
        [EnumMember(Value = "https://schema.org/photo")]
        Photo,
        [EnumMember(Value = "https://schema.org/photos")]
        Photos,
        [EnumMember(Value = "https://schema.org/physicalRequirement")]
        PhysicalRequirement,
        [EnumMember(Value = "https://schema.org/physiologicalBenefits")]
        PhysiologicalBenefits,
        [EnumMember(Value = "https://schema.org/pickupLocation")]
        PickupLocation,
        [EnumMember(Value = "https://schema.org/pickupTime")]
        PickupTime,
        [EnumMember(Value = "https://schema.org/playMode")]
        PlayMode,
        [EnumMember(Value = "https://schema.org/playerType")]
        PlayerType,
        [EnumMember(Value = "https://schema.org/playersOnline")]
        PlayersOnline,
        [EnumMember(Value = "https://schema.org/polygon")]
        Polygon,
        [EnumMember(Value = "https://schema.org/populationType")]
        PopulationType,
        [EnumMember(Value = "https://schema.org/position")]
        Position,
        [EnumMember(Value = "https://schema.org/positiveNotes")]
        PositiveNotes,
        [EnumMember(Value = "https://schema.org/possibleComplication")]
        PossibleComplication,
        [EnumMember(Value = "https://schema.org/possibleTreatment")]
        PossibleTreatment,
        [EnumMember(Value = "https://schema.org/postOfficeBoxNumber")]
        PostOfficeBoxNumber,
        [EnumMember(Value = "https://schema.org/postOp")]
        PostOp,
        [EnumMember(Value = "https://schema.org/postalCode")]
        PostalCode,
        [EnumMember(Value = "https://schema.org/postalCodeBegin")]
        PostalCodeBegin,
        [EnumMember(Value = "https://schema.org/postalCodeEnd")]
        PostalCodeEnd,
        [EnumMember(Value = "https://schema.org/postalCodePrefix")]
        PostalCodePrefix,
        [EnumMember(Value = "https://schema.org/postalCodeRange")]
        PostalCodeRange,
        [EnumMember(Value = "https://schema.org/potentialAction")]
        PotentialAction,
        [EnumMember(Value = "https://schema.org/potentialUse")]
        PotentialUse,
        [EnumMember(Value = "https://schema.org/preOp")]
        PreOp,
        [EnumMember(Value = "https://schema.org/predecessorOf")]
        PredecessorOf,
        [EnumMember(Value = "https://schema.org/pregnancyCategory")]
        PregnancyCategory,
        [EnumMember(Value = "https://schema.org/pregnancyWarning")]
        PregnancyWarning,
        [EnumMember(Value = "https://schema.org/prepTime")]
        PrepTime,
        [EnumMember(Value = "https://schema.org/preparation")]
        Preparation,
        [EnumMember(Value = "https://schema.org/prescribingInfo")]
        PrescribingInfo,
        [EnumMember(Value = "https://schema.org/prescriptionStatus")]
        PrescriptionStatus,
        [EnumMember(Value = "https://schema.org/previousItem")]
        PreviousItem,
        [EnumMember(Value = "https://schema.org/previousStartDate")]
        PreviousStartDate,
        [EnumMember(Value = "https://schema.org/price")]
        Price,
        [EnumMember(Value = "https://schema.org/priceComponent")]
        PriceComponent,
        [EnumMember(Value = "https://schema.org/priceComponentType")]
        PriceComponentType,
        [EnumMember(Value = "https://schema.org/priceCurrency")]
        PriceCurrency,
        [EnumMember(Value = "https://schema.org/priceRange")]
        PriceRange,
        [EnumMember(Value = "https://schema.org/priceSpecification")]
        PriceSpecification,
        [EnumMember(Value = "https://schema.org/priceType")]
        PriceType,
        [EnumMember(Value = "https://schema.org/priceValidUntil")]
        PriceValidUntil,
        [EnumMember(Value = "https://schema.org/primaryImageOfPage")]
        PrimaryImageOfPage,
        [EnumMember(Value = "https://schema.org/primaryPrevention")]
        PrimaryPrevention,
        [EnumMember(Value = "https://schema.org/printColumn")]
        PrintColumn,
        [EnumMember(Value = "https://schema.org/printEdition")]
        PrintEdition,
        [EnumMember(Value = "https://schema.org/printPage")]
        PrintPage,
        [EnumMember(Value = "https://schema.org/printSection")]
        PrintSection,
        [EnumMember(Value = "https://schema.org/procedure")]
        Procedure,
        [EnumMember(Value = "https://schema.org/procedureType")]
        ProcedureType,
        [EnumMember(Value = "https://schema.org/processingTime")]
        ProcessingTime,
        [EnumMember(Value = "https://schema.org/processorRequirements")]
        ProcessorRequirements,
        [EnumMember(Value = "https://schema.org/producer")]
        Producer,
        [EnumMember(Value = "https://schema.org/produces")]
        Produces,
        [EnumMember(Value = "https://schema.org/productGroupID")]
        ProductGroupID,
        [EnumMember(Value = "https://schema.org/productID")]
        ProductID,
        [EnumMember(Value = "https://schema.org/productSupported")]
        ProductSupported,
        [EnumMember(Value = "https://schema.org/productionCompany")]
        ProductionCompany,
        [EnumMember(Value = "https://schema.org/productionDate")]
        ProductionDate,
        [EnumMember(Value = "https://schema.org/proficiencyLevel")]
        ProficiencyLevel,
        [EnumMember(Value = "https://schema.org/programMembershipUsed")]
        ProgramMembershipUsed,
        [EnumMember(Value = "https://schema.org/programName")]
        ProgramName,
        [EnumMember(Value = "https://schema.org/programPrerequisites")]
        ProgramPrerequisites,
        [EnumMember(Value = "https://schema.org/programType")]
        ProgramType,
        [EnumMember(Value = "https://schema.org/programmingLanguage")]
        ProgrammingLanguage,
        [EnumMember(Value = "https://schema.org/programmingModel")]
        ProgrammingModel,
        [EnumMember(Value = "https://schema.org/propertyID")]
        PropertyID,
        [EnumMember(Value = "https://schema.org/proprietaryName")]
        ProprietaryName,
        [EnumMember(Value = "https://schema.org/proteinContent")]
        ProteinContent,
        [EnumMember(Value = "https://schema.org/provider")]
        Provider,
        [EnumMember(Value = "https://schema.org/providerMobility")]
        ProviderMobility,
        [EnumMember(Value = "https://schema.org/providesBroadcastService")]
        ProvidesBroadcastService,
        [EnumMember(Value = "https://schema.org/providesService")]
        ProvidesService,
        [EnumMember(Value = "https://schema.org/publicAccess")]
        PublicAccess,
        [EnumMember(Value = "https://schema.org/publicTransportClosuresInfo")]
        PublicTransportClosuresInfo,
        [EnumMember(Value = "https://schema.org/publication")]
        Publication,
        [EnumMember(Value = "https://schema.org/publicationType")]
        PublicationType,
        [EnumMember(Value = "https://schema.org/publishedBy")]
        PublishedBy,
        [EnumMember(Value = "https://schema.org/publishedOn")]
        PublishedOn,
        [EnumMember(Value = "https://schema.org/publisher")]
        Publisher,
        [EnumMember(Value = "https://schema.org/publisherImprint")]
        PublisherImprint,
        [EnumMember(Value = "https://schema.org/publishingPrinciples")]
        PublishingPrinciples,
        [EnumMember(Value = "https://schema.org/purchaseDate")]
        PurchaseDate,
        [EnumMember(Value = "https://schema.org/qualifications")]
        Qualifications,
        [EnumMember(Value = "https://schema.org/quarantineGuidelines")]
        QuarantineGuidelines,
        [EnumMember(Value = "https://schema.org/query")]
        Query,
        [EnumMember(Value = "https://schema.org/quest")]
        Quest,
        [EnumMember(Value = "https://schema.org/question")]
        Question,
        [EnumMember(Value = "https://schema.org/rangeIncludes")]
        RangeIncludes,
        [EnumMember(Value = "https://schema.org/ratingCount")]
        RatingCount,
        [EnumMember(Value = "https://schema.org/ratingExplanation")]
        RatingExplanation,
        [EnumMember(Value = "https://schema.org/ratingValue")]
        RatingValue,
        [EnumMember(Value = "https://schema.org/readBy")]
        ReadBy,
        [EnumMember(Value = "https://schema.org/readonlyValue")]
        ReadonlyValue,
        [EnumMember(Value = "https://schema.org/realEstateAgent")]
        RealEstateAgent,
        [EnumMember(Value = "https://schema.org/recipe")]
        Recipe,
        [EnumMember(Value = "https://schema.org/recipeCategory")]
        RecipeCategory,
        [EnumMember(Value = "https://schema.org/recipeCuisine")]
        RecipeCuisine,
        [EnumMember(Value = "https://schema.org/recipeIngredient")]
        RecipeIngredient,
        [EnumMember(Value = "https://schema.org/recipeInstructions")]
        RecipeInstructions,
        [EnumMember(Value = "https://schema.org/recipeYield")]
        RecipeYield,
        [EnumMember(Value = "https://schema.org/recipient")]
        Recipient,
        [EnumMember(Value = "https://schema.org/recognizedBy")]
        RecognizedBy,
        [EnumMember(Value = "https://schema.org/recognizingAuthority")]
        RecognizingAuthority,
        [EnumMember(Value = "https://schema.org/recommendationStrength")]
        RecommendationStrength,
        [EnumMember(Value = "https://schema.org/recommendedIntake")]
        RecommendedIntake,
        [EnumMember(Value = "https://schema.org/recordLabel")]
        RecordLabel,
        [EnumMember(Value = "https://schema.org/recordedAs")]
        RecordedAs,
        [EnumMember(Value = "https://schema.org/recordedAt")]
        RecordedAt,
        [EnumMember(Value = "https://schema.org/recordedIn")]
        RecordedIn,
        [EnumMember(Value = "https://schema.org/recordingOf")]
        RecordingOf,
        [EnumMember(Value = "https://schema.org/recourseLoan")]
        RecourseLoan,
        [EnumMember(Value = "https://schema.org/referenceQuantity")]
        ReferenceQuantity,
        [EnumMember(Value = "https://schema.org/referencesOrder")]
        ReferencesOrder,
        [EnumMember(Value = "https://schema.org/refundType")]
        RefundType,
        [EnumMember(Value = "https://schema.org/regionDrained")]
        RegionDrained,
        [EnumMember(Value = "https://schema.org/regionsAllowed")]
        RegionsAllowed,
        [EnumMember(Value = "https://schema.org/relatedAnatomy")]
        RelatedAnatomy,
        [EnumMember(Value = "https://schema.org/relatedCondition")]
        RelatedCondition,
        [EnumMember(Value = "https://schema.org/relatedDrug")]
        RelatedDrug,
        [EnumMember(Value = "https://schema.org/relatedLink")]
        RelatedLink,
        [EnumMember(Value = "https://schema.org/relatedStructure")]
        RelatedStructure,
        [EnumMember(Value = "https://schema.org/relatedTherapy")]
        RelatedTherapy,
        [EnumMember(Value = "https://schema.org/relatedTo")]
        RelatedTo,
        [EnumMember(Value = "https://schema.org/releaseDate")]
        ReleaseDate,
        [EnumMember(Value = "https://schema.org/releaseNotes")]
        ReleaseNotes,
        [EnumMember(Value = "https://schema.org/releaseOf")]
        ReleaseOf,
        [EnumMember(Value = "https://schema.org/releasedEvent")]
        ReleasedEvent,
        [EnumMember(Value = "https://schema.org/relevantOccupation")]
        RelevantOccupation,
        [EnumMember(Value = "https://schema.org/relevantSpecialty")]
        RelevantSpecialty,
        [EnumMember(Value = "https://schema.org/remainingAttendeeCapacity")]
        RemainingAttendeeCapacity,
        [EnumMember(Value = "https://schema.org/renegotiableLoan")]
        RenegotiableLoan,
        [EnumMember(Value = "https://schema.org/repeatCount")]
        RepeatCount,
        [EnumMember(Value = "https://schema.org/repeatFrequency")]
        RepeatFrequency,
        [EnumMember(Value = "https://schema.org/repetitions")]
        Repetitions,
        [EnumMember(Value = "https://schema.org/replacee")]
        Replacee,
        [EnumMember(Value = "https://schema.org/replacer")]
        Replacer,
        [EnumMember(Value = "https://schema.org/replyToUrl")]
        ReplyToUrl,
        [EnumMember(Value = "https://schema.org/reportNumber")]
        ReportNumber,
        [EnumMember(Value = "https://schema.org/representativeOfPage")]
        RepresentativeOfPage,
        [EnumMember(Value = "https://schema.org/requiredCollateral")]
        RequiredCollateral,
        [EnumMember(Value = "https://schema.org/requiredGender")]
        RequiredGender,
        [EnumMember(Value = "https://schema.org/requiredMaxAge")]
        RequiredMaxAge,
        [EnumMember(Value = "https://schema.org/requiredMinAge")]
        RequiredMinAge,
        [EnumMember(Value = "https://schema.org/requiredQuantity")]
        RequiredQuantity,
        [EnumMember(Value = "https://schema.org/requirements")]
        Requirements,
        [EnumMember(Value = "https://schema.org/requiresSubscription")]
        RequiresSubscription,
        [EnumMember(Value = "https://schema.org/reservationFor")]
        ReservationFor,
        [EnumMember(Value = "https://schema.org/reservationId")]
        ReservationId,
        [EnumMember(Value = "https://schema.org/reservationStatus")]
        ReservationStatus,
        [EnumMember(Value = "https://schema.org/reservedTicket")]
        ReservedTicket,
        [EnumMember(Value = "https://schema.org/responsibilities")]
        Responsibilities,
        [EnumMember(Value = "https://schema.org/restPeriods")]
        RestPeriods,
        [EnumMember(Value = "https://schema.org/restockingFee")]
        RestockingFee,
        [EnumMember(Value = "https://schema.org/result")]
        Result,
        [EnumMember(Value = "https://schema.org/resultComment")]
        ResultComment,
        [EnumMember(Value = "https://schema.org/resultReview")]
        ResultReview,
        [EnumMember(Value = "https://schema.org/returnFees")]
        ReturnFees,
        [EnumMember(Value = "https://schema.org/returnLabelSource")]
        ReturnLabelSource,
        [EnumMember(Value = "https://schema.org/returnMethod")]
        ReturnMethod,
        [EnumMember(Value = "https://schema.org/returnPolicyCategory")]
        ReturnPolicyCategory,
        [EnumMember(Value = "https://schema.org/returnPolicyCountry")]
        ReturnPolicyCountry,
        [EnumMember(Value = "https://schema.org/returnPolicySeasonalOverride")]
        ReturnPolicySeasonalOverride,
        [EnumMember(Value = "https://schema.org/returnShippingFeesAmount")]
        ReturnShippingFeesAmount,
        [EnumMember(Value = "https://schema.org/review")]
        Review,
        [EnumMember(Value = "https://schema.org/reviewAspect")]
        ReviewAspect,
        [EnumMember(Value = "https://schema.org/reviewBody")]
        ReviewBody,
        [EnumMember(Value = "https://schema.org/reviewCount")]
        ReviewCount,
        [EnumMember(Value = "https://schema.org/reviewRating")]
        ReviewRating,
        [EnumMember(Value = "https://schema.org/reviewedBy")]
        ReviewedBy,
        [EnumMember(Value = "https://schema.org/reviews")]
        Reviews,
        [EnumMember(Value = "https://schema.org/riskFactor")]
        RiskFactor,
        [EnumMember(Value = "https://schema.org/risks")]
        Risks,
        [EnumMember(Value = "https://schema.org/roleName")]
        RoleName,
        [EnumMember(Value = "https://schema.org/roofLoad")]
        RoofLoad,
        [EnumMember(Value = "https://schema.org/rsvpResponse")]
        RsvpResponse,
        [EnumMember(Value = "https://schema.org/runsTo")]
        RunsTo,
        [EnumMember(Value = "https://schema.org/runtime")]
        Runtime,
        [EnumMember(Value = "https://schema.org/runtimePlatform")]
        RuntimePlatform,
        [EnumMember(Value = "https://schema.org/rxcui")]
        Rxcui,
        [EnumMember(Value = "https://schema.org/safetyConsideration")]
        SafetyConsideration,
        [EnumMember(Value = "https://schema.org/salaryCurrency")]
        SalaryCurrency,
        [EnumMember(Value = "https://schema.org/salaryUponCompletion")]
        SalaryUponCompletion,
        [EnumMember(Value = "https://schema.org/sameAs")]
        SameAs,
        [EnumMember(Value = "https://schema.org/sampleType")]
        SampleType,
        [EnumMember(Value = "https://schema.org/saturatedFatContent")]
        SaturatedFatContent,
        [EnumMember(Value = "https://schema.org/scheduleTimezone")]
        ScheduleTimezone,
        [EnumMember(Value = "https://schema.org/scheduledPaymentDate")]
        ScheduledPaymentDate,
        [EnumMember(Value = "https://schema.org/scheduledTime")]
        ScheduledTime,
        [EnumMember(Value = "https://schema.org/schemaVersion")]
        SchemaVersion,
        [EnumMember(Value = "https://schema.org/schoolClosuresInfo")]
        SchoolClosuresInfo,
        [EnumMember(Value = "https://schema.org/screenCount")]
        ScreenCount,
        [EnumMember(Value = "https://schema.org/screenshot")]
        Screenshot,
        [EnumMember(Value = "https://schema.org/sdDatePublished")]
        SdDatePublished,
        [EnumMember(Value = "https://schema.org/sdLicense")]
        SdLicense,
        [EnumMember(Value = "https://schema.org/sdPublisher")]
        SdPublisher,
        [EnumMember(Value = "https://schema.org/season")]
        Season,
        [EnumMember(Value = "https://schema.org/seasonNumber")]
        SeasonNumber,
        [EnumMember(Value = "https://schema.org/seasons")]
        Seasons,
        [EnumMember(Value = "https://schema.org/seatNumber")]
        SeatNumber,
        [EnumMember(Value = "https://schema.org/seatRow")]
        SeatRow,
        [EnumMember(Value = "https://schema.org/seatSection")]
        SeatSection,
        [EnumMember(Value = "https://schema.org/seatingCapacity")]
        SeatingCapacity,
        [EnumMember(Value = "https://schema.org/seatingType")]
        SeatingType,
        [EnumMember(Value = "https://schema.org/secondaryPrevention")]
        SecondaryPrevention,
        [EnumMember(Value = "https://schema.org/securityClearanceRequirement")]
        SecurityClearanceRequirement,
        [EnumMember(Value = "https://schema.org/securityScreening")]
        SecurityScreening,
        [EnumMember(Value = "https://schema.org/seeks")]
        Seeks,
        [EnumMember(Value = "https://schema.org/seller")]
        Seller,
        [EnumMember(Value = "https://schema.org/sender")]
        Sender,
        [EnumMember(Value = "https://schema.org/sensoryRequirement")]
        SensoryRequirement,
        [EnumMember(Value = "https://schema.org/sensoryUnit")]
        SensoryUnit,
        [EnumMember(Value = "https://schema.org/serialNumber")]
        SerialNumber,
        [EnumMember(Value = "https://schema.org/seriousAdverseOutcome")]
        SeriousAdverseOutcome,
        [EnumMember(Value = "https://schema.org/serverStatus")]
        ServerStatus,
        [EnumMember(Value = "https://schema.org/servesCuisine")]
        ServesCuisine,
        [EnumMember(Value = "https://schema.org/serviceArea")]
        ServiceArea,
        [EnumMember(Value = "https://schema.org/serviceAudience")]
        ServiceAudience,
        [EnumMember(Value = "https://schema.org/serviceLocation")]
        ServiceLocation,
        [EnumMember(Value = "https://schema.org/serviceOperator")]
        ServiceOperator,
        [EnumMember(Value = "https://schema.org/serviceOutput")]
        ServiceOutput,
        [EnumMember(Value = "https://schema.org/servicePhone")]
        ServicePhone,
        [EnumMember(Value = "https://schema.org/servicePostalAddress")]
        ServicePostalAddress,
        [EnumMember(Value = "https://schema.org/serviceSmsNumber")]
        ServiceSmsNumber,
        [EnumMember(Value = "https://schema.org/serviceType")]
        ServiceType,
        [EnumMember(Value = "https://schema.org/serviceUrl")]
        ServiceUrl,
        [EnumMember(Value = "https://schema.org/servingSize")]
        ServingSize,
        [EnumMember(Value = "https://schema.org/sha256")]
        Sha256,
        [EnumMember(Value = "https://schema.org/sharedContent")]
        SharedContent,
        [EnumMember(Value = "https://schema.org/shippingDestination")]
        ShippingDestination,
        [EnumMember(Value = "https://schema.org/shippingDetails")]
        ShippingDetails,
        [EnumMember(Value = "https://schema.org/shippingLabel")]
        ShippingLabel,
        [EnumMember(Value = "https://schema.org/shippingRate")]
        ShippingRate,
        [EnumMember(Value = "https://schema.org/shippingSettingsLink")]
        ShippingSettingsLink,
        [EnumMember(Value = "https://schema.org/sibling")]
        Sibling,
        [EnumMember(Value = "https://schema.org/siblings")]
        Siblings,
        [EnumMember(Value = "https://schema.org/signDetected")]
        SignDetected,
        [EnumMember(Value = "https://schema.org/signOrSymptom")]
        SignOrSymptom,
        [EnumMember(Value = "https://schema.org/significance")]
        Significance,
        [EnumMember(Value = "https://schema.org/significantLink")]
        SignificantLink,
        [EnumMember(Value = "https://schema.org/significantLinks")]
        SignificantLinks,
        [EnumMember(Value = "https://schema.org/size")]
        Size,
        [EnumMember(Value = "https://schema.org/sizeGroup")]
        SizeGroup,
        [EnumMember(Value = "https://schema.org/sizeSystem")]
        SizeSystem,
        [EnumMember(Value = "https://schema.org/skills")]
        Skills,
        [EnumMember(Value = "https://schema.org/sku")]
        Sku,
        [EnumMember(Value = "https://schema.org/slogan")]
        Slogan,
        [EnumMember(Value = "https://schema.org/smiles")]
        Smiles,
        [EnumMember(Value = "https://schema.org/smokingAllowed")]
        SmokingAllowed,
        [EnumMember(Value = "https://schema.org/sodiumContent")]
        SodiumContent,
        [EnumMember(Value = "https://schema.org/softwareAddOn")]
        SoftwareAddOn,
        [EnumMember(Value = "https://schema.org/softwareHelp")]
        SoftwareHelp,
        [EnumMember(Value = "https://schema.org/softwareRequirements")]
        SoftwareRequirements,
        [EnumMember(Value = "https://schema.org/softwareVersion")]
        SoftwareVersion,
        [EnumMember(Value = "https://schema.org/sourceOrganization")]
        SourceOrganization,
        [EnumMember(Value = "https://schema.org/sourcedFrom")]
        SourcedFrom,
        [EnumMember(Value = "https://schema.org/spatial")]
        Spatial,
        [EnumMember(Value = "https://schema.org/spatialCoverage")]
        SpatialCoverage,
        [EnumMember(Value = "https://schema.org/speakable")]
        Speakable,
        [EnumMember(Value = "https://schema.org/specialCommitments")]
        SpecialCommitments,
        [EnumMember(Value = "https://schema.org/specialOpeningHoursSpecification")]
        SpecialOpeningHoursSpecification,
        [EnumMember(Value = "https://schema.org/specialty")]
        Specialty,
        [EnumMember(Value = "https://schema.org/speechToTextMarkup")]
        SpeechToTextMarkup,
        [EnumMember(Value = "https://schema.org/speed")]
        Speed,
        [EnumMember(Value = "https://schema.org/spokenByCharacter")]
        SpokenByCharacter,
        [EnumMember(Value = "https://schema.org/sponsor")]
        Sponsor,
        [EnumMember(Value = "https://schema.org/sport")]
        Sport,
        [EnumMember(Value = "https://schema.org/sportsActivityLocation")]
        SportsActivityLocation,
        [EnumMember(Value = "https://schema.org/sportsEvent")]
        SportsEvent,
        [EnumMember(Value = "https://schema.org/sportsTeam")]
        SportsTeam,
        [EnumMember(Value = "https://schema.org/spouse")]
        Spouse,
        [EnumMember(Value = "https://schema.org/stage")]
        Stage,
        [EnumMember(Value = "https://schema.org/stageAsNumber")]
        StageAsNumber,
        [EnumMember(Value = "https://schema.org/starRating")]
        StarRating,
        [EnumMember(Value = "https://schema.org/startDate")]
        StartDate,
        [EnumMember(Value = "https://schema.org/startOffset")]
        StartOffset,
        [EnumMember(Value = "https://schema.org/startTime")]
        StartTime,
        [EnumMember(Value = "https://schema.org/status")]
        Status,
        [EnumMember(Value = "https://schema.org/steeringPosition")]
        SteeringPosition,
        [EnumMember(Value = "https://schema.org/step")]
        Step,
        [EnumMember(Value = "https://schema.org/stepValue")]
        StepValue,
        [EnumMember(Value = "https://schema.org/steps")]
        Steps,
        [EnumMember(Value = "https://schema.org/storageRequirements")]
        StorageRequirements,
        [EnumMember(Value = "https://schema.org/streetAddress")]
        StreetAddress,
        [EnumMember(Value = "https://schema.org/strengthUnit")]
        StrengthUnit,
        [EnumMember(Value = "https://schema.org/strengthValue")]
        StrengthValue,
        [EnumMember(Value = "https://schema.org/structuralClass")]
        StructuralClass,
        [EnumMember(Value = "https://schema.org/study")]
        Study,
        [EnumMember(Value = "https://schema.org/studyDesign")]
        StudyDesign,
        [EnumMember(Value = "https://schema.org/studyLocation")]
        StudyLocation,
        [EnumMember(Value = "https://schema.org/studySubject")]
        StudySubject,
        [EnumMember(Value = "https://schema.org/subEvent")]
        SubEvent,
        [EnumMember(Value = "https://schema.org/subEvents")]
        SubEvents,
        [EnumMember(Value = "https://schema.org/subOrganization")]
        SubOrganization,
        [EnumMember(Value = "https://schema.org/subReservation")]
        SubReservation,
        [EnumMember(Value = "https://schema.org/subStageSuffix")]
        SubStageSuffix,
        [EnumMember(Value = "https://schema.org/subStructure")]
        SubStructure,
        [EnumMember(Value = "https://schema.org/subTest")]
        SubTest,
        [EnumMember(Value = "https://schema.org/subTrip")]
        SubTrip,
        [EnumMember(Value = "https://schema.org/subjectOf")]
        SubjectOf,
        [EnumMember(Value = "https://schema.org/subtitleLanguage")]
        SubtitleLanguage,
        [EnumMember(Value = "https://schema.org/successorOf")]
        SuccessorOf,
        [EnumMember(Value = "https://schema.org/sugarContent")]
        SugarContent,
        [EnumMember(Value = "https://schema.org/suggestedAge")]
        SuggestedAge,
        [EnumMember(Value = "https://schema.org/suggestedAnswer")]
        SuggestedAnswer,
        [EnumMember(Value = "https://schema.org/suggestedGender")]
        SuggestedGender,
        [EnumMember(Value = "https://schema.org/suggestedMaxAge")]
        SuggestedMaxAge,
        [EnumMember(Value = "https://schema.org/suggestedMeasurement")]
        SuggestedMeasurement,
        [EnumMember(Value = "https://schema.org/suggestedMinAge")]
        SuggestedMinAge,
        [EnumMember(Value = "https://schema.org/suitableForDiet")]
        SuitableForDiet,
        [EnumMember(Value = "https://schema.org/superEvent")]
        SuperEvent,
        [EnumMember(Value = "https://schema.org/supersededBy")]
        SupersededBy,
        [EnumMember(Value = "https://schema.org/supply")]
        Supply,
        [EnumMember(Value = "https://schema.org/supplyTo")]
        SupplyTo,
        [EnumMember(Value = "https://schema.org/supportingData")]
        SupportingData,
        [EnumMember(Value = "https://schema.org/surface")]
        Surface,
        [EnumMember(Value = "https://schema.org/target")]
        Target,
        [EnumMember(Value = "https://schema.org/targetCollection")]
        TargetCollection,
        [EnumMember(Value = "https://schema.org/targetDescription")]
        TargetDescription,
        [EnumMember(Value = "https://schema.org/targetName")]
        TargetName,
        [EnumMember(Value = "https://schema.org/targetPlatform")]
        TargetPlatform,
        [EnumMember(Value = "https://schema.org/targetPopulation")]
        TargetPopulation,
        [EnumMember(Value = "https://schema.org/targetProduct")]
        TargetProduct,
        [EnumMember(Value = "https://schema.org/targetUrl")]
        TargetUrl,
        [EnumMember(Value = "https://schema.org/taxID")]
        TaxID,
        [EnumMember(Value = "https://schema.org/taxonRank")]
        TaxonRank,
        [EnumMember(Value = "https://schema.org/taxonomicRange")]
        TaxonomicRange,
        [EnumMember(Value = "https://schema.org/teaches")]
        Teaches,
        [EnumMember(Value = "https://schema.org/telephone")]
        Telephone,
        [EnumMember(Value = "https://schema.org/temporal")]
        Temporal,
        [EnumMember(Value = "https://schema.org/temporalCoverage")]
        TemporalCoverage,
        [EnumMember(Value = "https://schema.org/termCode")]
        TermCode,
        [EnumMember(Value = "https://schema.org/termDuration")]
        TermDuration,
        [EnumMember(Value = "https://schema.org/termsOfService")]
        TermsOfService,
        [EnumMember(Value = "https://schema.org/termsPerYear")]
        TermsPerYear,
        [EnumMember(Value = "https://schema.org/text")]
        Text,
        [EnumMember(Value = "https://schema.org/textValue")]
        TextValue,
        [EnumMember(Value = "https://schema.org/thumbnail")]
        Thumbnail,
        [EnumMember(Value = "https://schema.org/thumbnailUrl")]
        ThumbnailUrl,
        [EnumMember(Value = "https://schema.org/tickerSymbol")]
        TickerSymbol,
        [EnumMember(Value = "https://schema.org/ticketNumber")]
        TicketNumber,
        [EnumMember(Value = "https://schema.org/ticketToken")]
        TicketToken,
        [EnumMember(Value = "https://schema.org/ticketedSeat")]
        TicketedSeat,
        [EnumMember(Value = "https://schema.org/timeOfDay")]
        TimeOfDay,
        [EnumMember(Value = "https://schema.org/timeRequired")]
        TimeRequired,
        [EnumMember(Value = "https://schema.org/timeToComplete")]
        TimeToComplete,
        [EnumMember(Value = "https://schema.org/tissueSample")]
        TissueSample,
        [EnumMember(Value = "https://schema.org/title")]
        Title,
        [EnumMember(Value = "https://schema.org/titleEIDR")]
        TitleEIDR,
        [EnumMember(Value = "https://schema.org/toLocation")]
        ToLocation,
        [EnumMember(Value = "https://schema.org/toRecipient")]
        ToRecipient,
        [EnumMember(Value = "https://schema.org/tocContinuation")]
        TocContinuation,
        [EnumMember(Value = "https://schema.org/tocEntry")]
        TocEntry,
        [EnumMember(Value = "https://schema.org/tongueWeight")]
        TongueWeight,
        [EnumMember(Value = "https://schema.org/tool")]
        Tool,
        [EnumMember(Value = "https://schema.org/torque")]
        Torque,
        [EnumMember(Value = "https://schema.org/totalJobOpenings")]
        TotalJobOpenings,
        [EnumMember(Value = "https://schema.org/totalPaymentDue")]
        TotalPaymentDue,
        [EnumMember(Value = "https://schema.org/totalPrice")]
        TotalPrice,
        [EnumMember(Value = "https://schema.org/totalTime")]
        TotalTime,
        [EnumMember(Value = "https://schema.org/tourBookingPage")]
        TourBookingPage,
        [EnumMember(Value = "https://schema.org/touristType")]
        TouristType,
        [EnumMember(Value = "https://schema.org/track")]
        Track,
        [EnumMember(Value = "https://schema.org/trackingNumber")]
        TrackingNumber,
        [EnumMember(Value = "https://schema.org/trackingUrl")]
        TrackingUrl,
        [EnumMember(Value = "https://schema.org/tracks")]
        Tracks,
        [EnumMember(Value = "https://schema.org/trailer")]
        Trailer,
        [EnumMember(Value = "https://schema.org/trailerWeight")]
        TrailerWeight,
        [EnumMember(Value = "https://schema.org/trainName")]
        TrainName,
        [EnumMember(Value = "https://schema.org/trainNumber")]
        TrainNumber,
        [EnumMember(Value = "https://schema.org/trainingSalary")]
        TrainingSalary,
        [EnumMember(Value = "https://schema.org/transFatContent")]
        TransFatContent,
        [EnumMember(Value = "https://schema.org/transcript")]
        Transcript,
        [EnumMember(Value = "https://schema.org/transitTime")]
        TransitTime,
        [EnumMember(Value = "https://schema.org/transitTimeLabel")]
        TransitTimeLabel,
        [EnumMember(Value = "https://schema.org/translationOfWork")]
        TranslationOfWork,
        [EnumMember(Value = "https://schema.org/translator")]
        Translator,
        [EnumMember(Value = "https://schema.org/transmissionMethod")]
        TransmissionMethod,
        [EnumMember(Value = "https://schema.org/travelBans")]
        TravelBans,
        [EnumMember(Value = "https://schema.org/trialDesign")]
        TrialDesign,
        [EnumMember(Value = "https://schema.org/tributary")]
        Tributary,
        [EnumMember(Value = "https://schema.org/typeOfBed")]
        TypeOfBed,
        [EnumMember(Value = "https://schema.org/typeOfGood")]
        TypeOfGood,
        [EnumMember(Value = "https://schema.org/typicalAgeRange")]
        TypicalAgeRange,
        [EnumMember(Value = "https://schema.org/typicalCreditsPerTerm")]
        TypicalCreditsPerTerm,
        [EnumMember(Value = "https://schema.org/typicalTest")]
        TypicalTest,
        [EnumMember(Value = "https://schema.org/underName")]
        UnderName,
        [EnumMember(Value = "https://schema.org/unitCode")]
        UnitCode,
        [EnumMember(Value = "https://schema.org/unitText")]
        UnitText,
        [EnumMember(Value = "https://schema.org/unnamedSourcesPolicy")]
        UnnamedSourcesPolicy,
        [EnumMember(Value = "https://schema.org/unsaturatedFatContent")]
        UnsaturatedFatContent,
        [EnumMember(Value = "https://schema.org/uploadDate")]
        UploadDate,
        [EnumMember(Value = "https://schema.org/upvoteCount")]
        UpvoteCount,
        [EnumMember(Value = "https://schema.org/url")]
        Url,
        [EnumMember(Value = "https://schema.org/urlTemplate")]
        UrlTemplate,
        [EnumMember(Value = "https://schema.org/usageInfo")]
        UsageInfo,
        [EnumMember(Value = "https://schema.org/usedToDiagnose")]
        UsedToDiagnose,
        [EnumMember(Value = "https://schema.org/userInteractionCount")]
        UserInteractionCount,
        [EnumMember(Value = "https://schema.org/usesDevice")]
        UsesDevice,
        [EnumMember(Value = "https://schema.org/usesHealthPlanIdStandard")]
        UsesHealthPlanIdStandard,
        [EnumMember(Value = "https://schema.org/utterances")]
        Utterances,
        [EnumMember(Value = "https://schema.org/validFor")]
        ValidFor,
        [EnumMember(Value = "https://schema.org/validFrom")]
        ValidFrom,
        [EnumMember(Value = "https://schema.org/validIn")]
        ValidIn,
        [EnumMember(Value = "https://schema.org/validThrough")]
        ValidThrough,
        [EnumMember(Value = "https://schema.org/validUntil")]
        ValidUntil,
        [EnumMember(Value = "https://schema.org/value")]
        Value,
        [EnumMember(Value = "https://schema.org/valueAddedTaxIncluded")]
        ValueAddedTaxIncluded,
        [EnumMember(Value = "https://schema.org/valueMaxLength")]
        ValueMaxLength,
        [EnumMember(Value = "https://schema.org/valueMinLength")]
        ValueMinLength,
        [EnumMember(Value = "https://schema.org/valueName")]
        ValueName,
        [EnumMember(Value = "https://schema.org/valuePattern")]
        ValuePattern,
        [EnumMember(Value = "https://schema.org/valueReference")]
        ValueReference,
        [EnumMember(Value = "https://schema.org/valueRequired")]
        ValueRequired,
        [EnumMember(Value = "https://schema.org/variableMeasured")]
        VariableMeasured,
        [EnumMember(Value = "https://schema.org/variantCover")]
        VariantCover,
        [EnumMember(Value = "https://schema.org/variesBy")]
        VariesBy,
        [EnumMember(Value = "https://schema.org/vatID")]
        VatID,
        [EnumMember(Value = "https://schema.org/vehicleConfiguration")]
        VehicleConfiguration,
        [EnumMember(Value = "https://schema.org/vehicleEngine")]
        VehicleEngine,
        [EnumMember(Value = "https://schema.org/vehicleIdentificationNumber")]
        VehicleIdentificationNumber,
        [EnumMember(Value = "https://schema.org/vehicleInteriorColor")]
        VehicleInteriorColor,
        [EnumMember(Value = "https://schema.org/vehicleInteriorType")]
        VehicleInteriorType,
        [EnumMember(Value = "https://schema.org/vehicleModelDate")]
        VehicleModelDate,
        [EnumMember(Value = "https://schema.org/vehicleSeatingCapacity")]
        VehicleSeatingCapacity,
        [EnumMember(Value = "https://schema.org/vehicleSpecialUsage")]
        VehicleSpecialUsage,
        [EnumMember(Value = "https://schema.org/vehicleTransmission")]
        VehicleTransmission,
        [EnumMember(Value = "https://schema.org/vendor")]
        Vendor,
        [EnumMember(Value = "https://schema.org/verificationFactCheckingPolicy")]
        VerificationFactCheckingPolicy,
        [EnumMember(Value = "https://schema.org/version")]
        Version,
        [EnumMember(Value = "https://schema.org/video")]
        Video,
        [EnumMember(Value = "https://schema.org/videoFormat")]
        VideoFormat,
        [EnumMember(Value = "https://schema.org/videoFrameSize")]
        VideoFrameSize,
        [EnumMember(Value = "https://schema.org/videoQuality")]
        VideoQuality,
        [EnumMember(Value = "https://schema.org/volumeNumber")]
        VolumeNumber,
        [EnumMember(Value = "https://schema.org/warning")]
        Warning,
        [EnumMember(Value = "https://schema.org/warranty")]
        Warranty,
        [EnumMember(Value = "https://schema.org/warrantyPromise")]
        WarrantyPromise,
        [EnumMember(Value = "https://schema.org/warrantyScope")]
        WarrantyScope,
        [EnumMember(Value = "https://schema.org/webCheckinTime")]
        WebCheckinTime,
        [EnumMember(Value = "https://schema.org/webFeed")]
        WebFeed,
        [EnumMember(Value = "https://schema.org/weight")]
        Weight,
        [EnumMember(Value = "https://schema.org/weightTotal")]
        WeightTotal,
        [EnumMember(Value = "https://schema.org/wheelbase")]
        Wheelbase,
        [EnumMember(Value = "https://schema.org/width")]
        Width,
        [EnumMember(Value = "https://schema.org/winner")]
        Winner,
        [EnumMember(Value = "https://schema.org/wordCount")]
        WordCount,
        [EnumMember(Value = "https://schema.org/workExample")]
        WorkExample,
        [EnumMember(Value = "https://schema.org/workFeatured")]
        WorkFeatured,
        [EnumMember(Value = "https://schema.org/workHours")]
        WorkHours,
        [EnumMember(Value = "https://schema.org/workLocation")]
        WorkLocation,
        [EnumMember(Value = "https://schema.org/workPerformed")]
        WorkPerformed,
        [EnumMember(Value = "https://schema.org/workPresented")]
        WorkPresented,
        [EnumMember(Value = "https://schema.org/workTranslation")]
        WorkTranslation,
        [EnumMember(Value = "https://schema.org/workload")]
        Workload,
        [EnumMember(Value = "https://schema.org/worksFor")]
        WorksFor,
        [EnumMember(Value = "https://schema.org/worstRating")]
        WorstRating,
        [EnumMember(Value = "https://schema.org/xpath")]
        Xpath,
        [EnumMember(Value = "https://schema.org/yearBuilt")]
        YearBuilt,
        [EnumMember(Value = "https://schema.org/yearlyRevenue")]
        YearlyRevenue,
        [EnumMember(Value = "https://schema.org/yearsInOperation")]
        YearsInOperation,
        [EnumMember(Value = "https://schema.org/yield")]
        Yield
    }
}
