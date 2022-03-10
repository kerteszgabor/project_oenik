using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace project.Client.Services.Helpers
{
    public static class JsonHelpers
    {
        public static string SerializeList(List<string> strings)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = false
            };

            return JsonSerializer.Serialize(strings, options);
        }
    }
}
