namespace pokemon.Models.dto
{
    public class AddPokemonDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public int Power { get; set; }
        public List<int> elementIds { get; set; }
    }
}
