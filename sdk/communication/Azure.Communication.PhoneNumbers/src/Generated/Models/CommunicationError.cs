// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.Models
{
    /// <summary> The Communication Services error. </summary>
    internal partial class CommunicationError
    {
        /// <summary> Initializes a new instance of CommunicationError. </summary>
        /// <param name="code"> The error code. </param>
        /// <param name="message"> The error message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        internal CommunicationError(string code, string message)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Code = code;
            Message = message;
            Details = new ChangeTrackingList<CommunicationError>();
        }

        /// <summary> Initializes a new instance of CommunicationError. </summary>
        /// <param name="code"> The error code. </param>
        /// <param name="message"> The error message. </param>
        /// <param name="target"> The error target. </param>
        /// <param name="details"> Further details about specific errors that led to this error. </param>
        /// <param name="innerError"> The inner error if any. </param>
        internal CommunicationError(string code, string message, string target, IReadOnlyList<CommunicationError> details, CommunicationError innerError)
        {
            Code = code;
            Message = message;
            Target = target;
            Details = details;
            InnerError = innerError;
        }

        /// <summary> The error code. </summary>
        public string Code { get; }
        /// <summary> The error message. </summary>
        public string Message { get; }
        /// <summary> The error target. </summary>
        public string Target { get; }
        /// <summary> Further details about specific errors that led to this error. </summary>
        public IReadOnlyList<CommunicationError> Details { get; }
        /// <summary> The inner error if any. </summary>
        public CommunicationError InnerError { get; }
    }
}
