global using AutoMapper;
using Dotnet_rpg.Models;

namespace Dotnet_rpg.Service.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{id = 1,name = "sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            var character = characters.Find(c => c.id == id);
            if (character is not null)
            {
                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            var character = characters.FirstOrDefault(c => c.id == updateCharacter.id);

            character.name = updateCharacter.name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strength = updateCharacter.Strength;
            character.Defense = updateCharacter.Defense;
            character.Intelligance = updateCharacter.Intelligance;
            character.Class = updateCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);

            return serviceResponse;
        }
    }
}
