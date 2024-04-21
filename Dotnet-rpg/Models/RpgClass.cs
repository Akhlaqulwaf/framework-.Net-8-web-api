using System.Text.Json.Serialization;

namespace Dotnet_rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,

        Healer = 2,

        Mage = 3,
    }
}
