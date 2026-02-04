namespace Api_Musical.Models
{
    public class DeezerResponse
    {
        public List<Cancion>? Data { get; set; }

        public DeezerResponse? tracks { get; set; }
    }
}
