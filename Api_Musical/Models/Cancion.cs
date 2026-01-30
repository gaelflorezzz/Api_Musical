namespace Api_Musical.Models
{
    public class Cancion
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string preview { get; set; }
        public int duracion { get; set; }

        public String getTittle()
        {
            return titulo;
        }

    }
}
