using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Server.Data;
using ProjetoTeste.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Server.Controllers {
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class JogadorController : ControllerBase {
        private readonly ILogger<JogadorController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public JogadorController(ILogger<JogadorController> logger, ApplicationDbContext applicationDbContext) {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll() {
            List<Jogador> Lista = _applicationDbContext.Jogadores.ToList();
            return Ok(Lista);
        }

        [HttpPost]
        public IActionResult AddJogador(Jogador jogador) {
            try {
                _applicationDbContext.Jogadores.Add(jogador);
                _applicationDbContext.SaveChanges();
                return Ok(jogador);
            } catch (Exception) {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult EditJogador(Jogador jogador) {
            try {
                _applicationDbContext.Jogadores.Update(jogador);
                _applicationDbContext.SaveChanges();
                return Ok(jogador);
            } catch (Exception) {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DelJogador([FromRoute] int id) {
            try {
                Jogador j = _applicationDbContext.Jogadores.FirstOrDefault(x => x.Id == id);

                if (j != null) {
                    _applicationDbContext.Jogadores.Remove(j);
                    _applicationDbContext.SaveChanges();
                    return Ok(j);
                } else {
                    return NotFound("Id inexistente");
                }
            } catch (Exception) {
                return BadRequest();
            }
        }
    }
}
