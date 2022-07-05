using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController(ILogger<EventoController> logger)
        {

        }

        public IEnumerable<Evento> _evento = new Evento[] {


                new Evento(){
                EventoId = 1 ,
                Tema = "Angular 11 e dotnet 5",
                Local  = "BH",
                Lote = "1 Lote",
                QtdPessoas = 99,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "foto.png"

            },
                            new Evento{
                EventoId = 2,
                Tema = "Angular e suas novidades",
                Local  = "BH",
                Lote = "1 Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "foto.png"

            }
        };




        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);

        }

        [HttpPost]
        public string Post()
        {
            return "exemplo post";

        }

        [HttpPut]
        public string Put()
        {
            return "exemplo put";

        }

        [HttpDelete]
        public string Delete()
        {
            return "exemplo delete";

        }
    }
}

