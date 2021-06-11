using Microsoft.AspNetCore.Mvc;
using MISA.HCSH.Core.Interface.IService;
using System;

namespace MISA.HCSN.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MisaBaseController<T> : ControllerBase
    {
        private IBaseService<T> _baseServie;

        public MisaBaseController(IBaseService<T> baseService)
        {
            _baseServie = baseService;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var responseResult = _baseServie.GetEntities();
            return Ok(responseResult);
        }

        // GET api/<BaseController>/5
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var responseResult = _baseServie.GetById(entityId);

            return Ok(responseResult);
        }

        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var responseResult = _baseServie.Insert(entity);

            return Ok(responseResult);
        }

        // PUT api/<BaseController>/5
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var responseResult = _baseServie.Update(entity);
            return Ok(responseResult);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var responseResult = _baseServie.Delete(entityId);
            return Ok(responseResult);
        }
    }
}
