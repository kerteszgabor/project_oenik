using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace project.Client.Services.Helpers
{
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
