using Business.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Api;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoApis.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IBusinessUsuario logger ;
        public ItemController(IBusinessUsuario logger)
        {
            this.logger = logger;
        }


        [HttpGet]
        [Route("api/Usuario/{idUsuario}")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObtenUsuarioxId(int idUsuario)
        {
            var usuario = logger.GetUsuarioxId(idUsuario);
           if(usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObtenTodosUsuarios()
        {
            var usuario = logger.GetTodosUsuarios();
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
