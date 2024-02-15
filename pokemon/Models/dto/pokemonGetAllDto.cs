namespace pokemon.Models.dto
{
    public class pokemonGetAllDto
    {
        public Pokemon pokemon { get; set; }
        public ICollection<string> elementName {  get; set; }
    }
}
