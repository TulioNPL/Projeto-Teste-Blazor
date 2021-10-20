using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Server.Data;
using ProjetoTeste.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class TimeController : ControllerBase

    {
        private readonly ILogger<TimeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public TimeController(ILogger<TimeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Time> Lista = _applicationDbContext.Times.ToList();
            return Ok(Lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id)
        {
            Time time = _applicationDbContext.Times.FirstOrDefault(j => j.Id == id);
            return Ok(time);
        }

        [HttpPost]
        public IActionResult AddTime(Time time)
        {
            try
            {
                _applicationDbContext.Times.Add(time);
                _applicationDbContext.SaveChanges();
                return Ok(time);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult EditTime(Time time)
        {
            try
            {
                _applicationDbContext.Times.Update(time);
                _applicationDbContext.SaveChanges();
                return Ok(time);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DelTime([FromRoute] int id)
        {
            try
            {
                Time j = _applicationDbContext.Times.FirstOrDefault(x => x.Id == id);

                if (j != null)
                {
                    _applicationDbContext.Times.Remove(j);
                    _applicationDbContext.SaveChanges();
                    return Ok(j);
                }
                else
                {
                    return NotFound("Id inexistente");
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
