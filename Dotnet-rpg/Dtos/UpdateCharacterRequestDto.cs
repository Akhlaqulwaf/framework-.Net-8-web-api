using Dotnet_rpg.Models;

namespace Dotnet_rpg.Dtos
{
    public class UpdateCharacterRequestDto
    {
        public int id { get; set; }
        public string name { get; set; } = "frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligance { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
