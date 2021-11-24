using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TruckTravelController : ControllerBase
    {
        private readonly TruckTravelServices _context;
        public TruckTravelController(TruckTravelServices context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<TruckTravel>> _result;
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
                _result = new Result<List<TruckTravel>>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Result<TruckTravel> _result;
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
                _result = new Result<TruckTravel>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPost]
        public ActionResult Set([FromBody] TruckTravel value)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Set(value);
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
        public ActionResult Update(int id, [FromBody] TruckTravel value)
        {
            Result<bool> _result;
            try
            {
                _result = _context.Update(id, value);
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
