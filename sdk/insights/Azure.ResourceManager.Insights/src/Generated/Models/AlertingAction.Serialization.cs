// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Insights.Models
{
    public partial class AlertingAction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("severity");
            writer.WriteStringValue(Severity.ToString());
            if (Optional.IsDefined(AznsAction))
            {
                writer.WritePropertyName("aznsAction");
                writer.WriteObjectValue(AznsAction);
            }
            if (Optional.IsDefined(ThrottlingInMin))
            {
                writer.WritePropertyName("throttlingInMin");
                writer.WriteNumberValue(ThrottlingInMin.Value);
            }
            writer.WritePropertyName("trigger");
            writer.WriteObjectValue(Trigger);
            writer.WritePropertyName("odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static AlertingAction DeserializeAlertingAction(JsonElement element)
        {
            AlertSeverity severity = default;
            Optional<AzNsActionGroup> aznsAction = default;
            Optional<int> throttlingInMin = default;
            TriggerCondition trigger = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("severity"))
                {
                    severity = new AlertSeverity(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("aznsAction"))
                {
                    aznsAction = AzNsActionGroup.DeserializeAzNsActionGroup(property.Value);
                    continue;
                }
                if (property.NameEquals("throttlingInMin"))
                {
                    throttlingInMin = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("trigger"))
                {
                    trigger = TriggerCondition.DeserializeTriggerCondition(property.Value);
                    continue;
                }
                if (property.NameEquals("odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new AlertingAction(odataType, severity, aznsAction.Value, Optional.ToNullable(throttlingInMin), trigger);
        }
    }
}