using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Interfaces
{
    public interface ElementInterface
    {
        ICollection<ElementDto> GetAllElements();
        
        bool IsElementExist(int id);

        ICollection<ElementOnPokemonDto> GetPokemonByElements(int elementId);
    }
}
