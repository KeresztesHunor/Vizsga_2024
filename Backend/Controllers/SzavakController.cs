using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController, Route("szavak")]
    public class SzavakController(AppDbContext context) : ControllerBase()
    {
        AppDbContext context { get; } = context;

        [HttpGet]
        public IEnumerable<SzavakDTO> Get() => context.Szavak.ToList().ConvertAll(szavak => new SzavakDTO {
            Id = szavak.Id,
            Angol = szavak.Angol,
            Magyar = szavak.Magyar,
            TemaId = szavak.TemaId
        });

        [HttpGet("{id}")]
        public IEnumerable<SzavakJoinTema> Get([FromRoute] int id) => context
            .Szavak
            .Join(context.Tema, szavak => szavak.TemaId, tema => tema.Id, (szavak, tema) => new SzavakJoinTema {
                Id = szavak.Id,
                Angol = szavak.Angol,
                Magyar = szavak.Magyar,
                Tema = new TemaDTO {
                    Id = tema.Id,
                    TemaNev = tema.TemaNev
                }
            })
            .Where(szavakJoinTema => szavakJoinTema.Id == id)
        ;

        public class SzavakJoinTema
        {
            public int Id { get; set; }
            public string Angol { get; set; }
            public string Magyar { get; set; }
            public TemaDTO Tema { get; set; }
        }
    }
}
