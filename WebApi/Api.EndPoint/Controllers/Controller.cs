using System;
using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Infrastructure.Helpers;
using Api.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Api.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller<T> : ControllerBase where T : ModelBase, new()
    {
        private IServiceBase _service;

        public Controller(IServiceBase service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            var entities = _service.Read<T>();

            return new JsonResult(entities, new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost("filter")]
        public virtual IActionResult Filter([FromBody] SlimQuery query)
        {
            var entities = _service.Read<T>();

            return new JsonResult(entities, new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var entity = _service.FirstOrDefault<T>(t => t.Id == id);

            return new JsonResult(entity);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            try {
                _service.Create(entity);
                _service.Save();

                return Ok("Criado com sucesso");
            }
            catch(Exception ex) 
            {
                // Todo: Retornar uma mensagem de exceção melhor
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(int id, [FromBody] T entity)
        {
            try {
                entity.Id = id;

                _service.Edit(entity);
                _service.Save();

                return Ok("Editado com sucesso");
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try {
                var entity = _service.FirstOrDefault<T>(t => t.Id == id);

                _service.Delete(entity);
                _service.Save();

                return Ok("Deletado com sucesso");
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
