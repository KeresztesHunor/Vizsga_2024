using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Szavak
    {
        [Key] public int Id { get; set; }
        public string Angol { get; set; }
        public string Magyar { get; set; }
        public int TemaId { get; set; }

        [ForeignKey(nameof(TemaId))] public Tema _Tema { get; set; }
    }
}
