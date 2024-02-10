using System.Runtime.InteropServices;

namespace pokemon.Exceptions
{
    public class OwnerNoutFoundException : Exception
    {
        public OwnerNoutFoundException([Optional] Exception inner) : base("Owner not found", inner)
        {

        }
    }
}
