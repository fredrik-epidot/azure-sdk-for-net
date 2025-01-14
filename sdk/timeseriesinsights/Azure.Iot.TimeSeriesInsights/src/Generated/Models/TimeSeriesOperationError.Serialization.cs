// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    public partial class TimeSeriesOperationError
    {
        internal static TimeSeriesOperationError DeserializeTimeSeriesOperationError(JsonElement element)
        {
            Optional<string> code = default;
            Optional<string> message = default;
            Optional<string> target = default;
            Optional<TimeSeriesOperationError> innerError = default;
            Optional<IReadOnlyList<TimeSeriesOperationErrorDetails>> details = default;
            IReadOnlyDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innerError"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    innerError = DeserializeTimeSeriesOperationError(property.Value);
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<TimeSeriesOperationErrorDetails> array = new List<TimeSeriesOperationErrorDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TimeSeriesOperationErrorDetails.DeserializeTimeSeriesOperationErrorDetails(item));
                    }
                    details = array;
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new TimeSeriesOperationError(code.Value, message.Value, target.Value, innerError.Value, Optional.ToList(details), additionalProperties);
        }
    }
}
