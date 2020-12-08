using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous.WebApi.NoSQL.Domains;
using Nyous.WebApi.NoSQL.Interfaces;

namespace Nyous.WebApi.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventosRepository _eventosRepository;

        public EventosController(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        [HttpPost]
        public IActionResult CreateEvento(EventoDomain input)
        {
            try
            {
                _eventosRepository.Create(input);
                return Ok("O evento foi cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllEventos()
        {
            try
            {
                return Ok(_eventosRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventoById(string id)
        {
            try
            {
                return Ok(_eventosRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvento(string id, EventoDomain input)
        {
            try
            {
                _eventosRepository.Update(id, input);
                return Ok("Evento alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(string id)
        {
            try
            {
                _eventosRepository.Remove(id);
                return Ok("Evento excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
