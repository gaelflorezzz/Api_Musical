namespace Api_Musical.Models
{
    public class Cancion
    {
        public long id { get; set; }
        public string? title { get; set; }
        public string? preview { get; set; }
        public int duration { get; set; }

        public int charts { get; set; }
        public Album? album { get; set; }
        public Artista? artist { get; set; }
    }
}
