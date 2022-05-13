using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System.Linq;
using System;

namespace project.Client.Services.Helpers
{
    public static class JsonHelpers<T>
    {
        public static List<T> DeserializeJson(string jsonObject)
        {
            return JsonSerializer.Deserialize<List<T>>(jsonObject, JsonHelpers.GetSerializerOption());
        }
        public static string SerializeList(List<T> list)
        {
            return JsonSerializer.Serialize(list, JsonHelpers.GetSerializerOption());
        }
    }
    public static class JsonHelpers
    {
        public static string SerializeList(List<string> strings)
        {
            return JsonSerializer.Serialize(strings, GetSerializerOption());
        }

        public static JsonSerializerOptions GetSerializerOption()
        {
            return new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = false
            };
        }
    }
}
