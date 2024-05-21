using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class SzavakDTO
    {
        public int? Id { get; set; }
        [Required] public string Angol { get; set; }
        [Required] public string Magyar { get; set; }
        [Required] public int TemaId { get; set; }
    }
}
