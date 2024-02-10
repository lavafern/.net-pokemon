using System.Runtime.InteropServices;

namespace pokemon.Exceptions
{
    public class PokemonNotFoundException : Exception
    {

        public PokemonNotFoundException([Optional] Exception inner) : base("Pokemon not found",inner)
        {
            
        }
    }
}
