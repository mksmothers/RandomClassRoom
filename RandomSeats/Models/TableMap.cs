using Microsoft.Build.Construction;

namespace RandomSeats.Models
{
    public class TableMap
    {
        public string Name { get; set; }    
        public List<string> Students { get; set; } = new List<string>();
    }
}
