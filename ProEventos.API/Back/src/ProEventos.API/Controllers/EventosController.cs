using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;


namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    
    {
      
      



        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)

        {              
            _eventoService = eventoService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var eventos = await _eventoService.GetAllEventosAsync(true);
                 if(eventos == null) return NotFound("nenhum evento encotrado");
                 return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
            }



        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try
            {
                 var evento = await _eventoService.GetEventoByIdAsync(id, true);
                 if(evento == null) return NotFound("Evento por id não encotrado");
                 return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
            }

        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string Tema)
        {
             try
            {
                 var evento = await _eventoService.GetAllEventoByTemaAsync(tema, true);
                 if(evento == null) return NotFound("Evento por tema não encotrado");
                 return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
             try
            {
                 var evento = await _eventoService.AddEventos(model);
                 if(evento == null) return BadRequest("Erro ao tentar adicionar eventos");
                 return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar adicionar eventos. Erro {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
                   try
            {
                 var evento = await _eventoService.UpdateEventos(id, model);
                 if(evento == null) return BadRequest("Erro ao atualizar eventos");
                 return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar atualizar eventos. Erro {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
               try
            {
                if(await _eventoService.DeleteEvento(id))
                    return Ok ("Deletado");
                else
                    return BadRequest("Evento não deletado");
                
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCode.Status505InternalServerError, 
                $"Erro ao tentar deletar eventos. Erro {ex.Message}");
            }

        }
    }
}

