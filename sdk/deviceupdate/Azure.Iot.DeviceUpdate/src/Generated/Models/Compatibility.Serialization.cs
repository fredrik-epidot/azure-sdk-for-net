// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Iot.DeviceUpdate.Models
{
    public partial class Compatibility
    {
        internal static Compatibility DeserializeCompatibility(JsonElement element)
        {
            string deviceManufacturer = default;
            string deviceModel = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("deviceManufacturer"))
                {
                    deviceManufacturer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deviceModel"))
                {
                    deviceModel = property.Value.GetString();
                    continue;
                }
            }
            return new Compatibility(deviceManufacturer, deviceModel);
        }
    }
}
