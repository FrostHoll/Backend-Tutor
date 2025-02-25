using System.Text.Json.Serialization;
using System.Text.Json;
using System.Globalization;

namespace BackendTutor.Utils
{
    public class StringToDecimalJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (decimal.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {

                return result;
            }

            throw new JsonException($"Ошибка конвертации {reader.GetString()} в decimal.");
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
