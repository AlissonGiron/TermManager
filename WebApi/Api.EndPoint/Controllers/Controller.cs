using System;
using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Infrastructure.Helpers;
using Api.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Api.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller<T> : ControllerBase where T : class, IModel, new()
    {
        protected IServiceBase _service;

        public Controller(IServiceBase service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Read<T>();
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            return new JsonResult(_service.FirstOrDefault<T>(t => t.Id == id), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            return Create(entity);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(int id, [FromBody] T entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            T entity = _service.FirstOrDefault<T>(t => t.Id == id);
            return Delete(entity);
        }

        protected IActionResult Create<TItem>(TItem entity) where TItem : class, new()
        {
            try
            {
                _service.Create(entity);
                _service.Save();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected IActionResult Edit<TItem>(TItem entity) where TItem : class, new()
        {
            try
            {
                _service.Edit(entity);
                _service.Save();

                return Ok("Editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected IActionResult Delete<TItem>(TItem entity) where TItem : class, new()
        {
            try
            {
                _service.Delete(entity);
                _service.Save();

                return Ok("Deletado com sucesso");
            }
            catch(DbUpdateException ex)
            {
                return BadRequest("Erro ao excluir o item, provavelmente existem referências a ele no sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected IActionResult Read<TItem>(Query<TItem> query = null) where TItem : class, new()
        {
            return new JsonResult(_service.Read<TItem>(query), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
