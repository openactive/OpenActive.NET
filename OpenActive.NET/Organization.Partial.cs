using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.NET
{
    public partial class Organization : ILegalEntity
    {
        string ILegalEntity.GivenName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ILegalEntity.FamilyName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool ILegalEntity.IsPerson => false;
        bool ILegalEntity.IsOrganization => true;

        /// <summary>
        /// For convenience when using ILegalEntity, DisplayName uses maps to Name.
        /// </summary>
        string ILegalEntity.DisplayName
        {
            get
            {
                return this.Name ?? this.LegalName;
            }
        }
    }
}
