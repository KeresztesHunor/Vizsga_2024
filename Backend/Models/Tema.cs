using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Tema
    {
        [Key] public int Id { get; set; }
        public string TemaNev { get; set; }

        public List<Szavak> _Szavak { get; set; }
    }
}
