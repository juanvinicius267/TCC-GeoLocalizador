using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoLocalizador.BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HarborController : ControllerBase
    {
        private readonly HarborServices _context;
        public HarborController(HarborServices context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<Harbor>> _result;
            try
            {
                _result = _context.Get();
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<List<Harbor>>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Result<Harbor> _result;
            try
            {
                _result = _context.GetById(id);
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<Harbor>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPost]
        public ActionResult Set([FromBody] Harbor harbor)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Set(harbor);
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Harbor harbor)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Update(id,harbor);
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Delete(id);
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<bool>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
    }
}
