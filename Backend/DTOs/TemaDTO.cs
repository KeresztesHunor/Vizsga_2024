using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class TemaDTO
    {
        public int? Id { get; set; }
        [Required] public string TemaNev { get; set; }
    }
}
