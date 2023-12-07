namespace WebApplication2
{
    public class Ksiazki
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Autor { get; set; }
        public int rok { get; set;}
        public virtual List<Biblioteka>? Biblioteka { get; set; }
    }
}
