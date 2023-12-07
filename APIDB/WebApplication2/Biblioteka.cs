namespace WebApplication2
{
    public class Biblioteka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Ksiazki>? Ksiazki { get; set; }
    }
}
