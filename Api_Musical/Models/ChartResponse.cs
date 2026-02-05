namespace Api_Musical.Models
{
    public class ChartResponse
    {
        public DeezerResponse<Cancion>? tracks { get; set; }
        public DeezerResponse<Artista>? artists { get; set; }
    }
}
