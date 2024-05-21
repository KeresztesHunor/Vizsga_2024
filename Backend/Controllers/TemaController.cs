using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController, Route("tema")]
    public class TemaController(AppDbContext context) : ControllerBase()
    {
        AppDbContext context { get; } = context;

        [HttpGet]
        public IEnumerable<TemaDTO> Get() => context.Tema.ToList().ConvertAll(tema => new TemaDTO {
            Id = tema.Id,
            TemaNev = tema.TemaNev
        });
    }
}
