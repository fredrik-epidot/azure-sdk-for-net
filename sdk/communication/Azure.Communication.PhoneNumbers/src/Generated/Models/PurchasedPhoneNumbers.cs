// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.PhoneNumbers.Models
{
    /// <summary> The list of purchased phone numbers. </summary>
    internal partial class PurchasedPhoneNumbers
    {
        /// <summary> Initializes a new instance of PurchasedPhoneNumbers. </summary>
        /// <param name="phoneNumbers"> Represents a list of phone numbers. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumbers"/> is null. </exception>
        internal PurchasedPhoneNumbers(IEnumerable<PurchasedPhoneNumber> phoneNumbers)
        {
            if (phoneNumbers == null)
            {
                throw new ArgumentNullException(nameof(phoneNumbers));
            }

            PhoneNumbers = phoneNumbers.ToList();
        }

        /// <summary> Initializes a new instance of PurchasedPhoneNumbers. </summary>
        /// <param name="phoneNumbers"> Represents a list of phone numbers. </param>
        /// <param name="nextLink"> Represents the URL link to the next page of phone number results. </param>
        internal PurchasedPhoneNumbers(IReadOnlyList<PurchasedPhoneNumber> phoneNumbers, string nextLink)
        {
            PhoneNumbers = phoneNumbers;
            NextLink = nextLink;
        }

        /// <summary> Represents a list of phone numbers. </summary>
        public IReadOnlyList<PurchasedPhoneNumber> PhoneNumbers { get; }
        /// <summary> Represents the URL link to the next page of phone number results. </summary>
        public string NextLink { get; }
    }
}
