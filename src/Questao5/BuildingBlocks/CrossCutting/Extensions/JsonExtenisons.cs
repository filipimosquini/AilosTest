using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Questao5.BuildingBlocks.CrossCutting.Extensions;

public static class JsonExtenisons
{
    public static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        TypeNameHandling = TypeNameHandling.None,
        Converters = (IList<JsonConverter>)new JsonConverter[1]
        {
            (JsonConverter)new StringEnumConverter()
        }
    };

    public static T FromJson<T>(this string json)
        => string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject<T>(json);


    public static T FromJson<T>(this string json, JsonSerializerSettings jsonSerializerSettings)
        => string.IsNullOrWhiteSpace(json) ? default : 
            jsonSerializerSettings != null ? 
                JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings) 
                : throw new ArgumentNullException(nameof(jsonSerializerSettings));

    public static string ToJson(this object source)
        => source == null
            ? (string)null
            : JsonConvert.SerializeObject(source, Formatting.Indented, JsonSerializerSettings);
}