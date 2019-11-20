using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.NET
{
    public partial class Person : ILegalEntity
    {
        bool ILegalEntity.IsPerson => true;

        bool ILegalEntity.IsOrganization => false;

        /// <summary>
        /// For convenience when using ILegalEntity, GivenName and FamilyName are used as Name if no name is provided.
        /// </summary>
        string ILegalEntity.DisplayName
        {
            get {
                return this.Name ?? this.LegalName ?? this.GivenName + " " + this.FamilyName;
            }
        }
    }
}
