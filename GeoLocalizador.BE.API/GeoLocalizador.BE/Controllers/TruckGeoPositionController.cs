using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Response;
using GeoLocalizador.BE.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckGeoPositionController : ControllerBase
    {
        private readonly TruckGeoPositionServices _context;
        public TruckGeoPositionController(TruckGeoPositionServices context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<TruckGeoPosition>> _result;
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
                _result = new Result<List<TruckGeoPosition>>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpGet("get-travels")]
        public ActionResult GetTravels()
        {
            Result<List<TruckInformationResponse>> _result;
            try
            {
                _result = _context.GetTravels();
                if (_result.Success == true)
                {
                    return Ok(_result);
                }
                return BadRequest(_result);
            }
            catch (System.Exception err)
            {
                _result = new Result<List<TruckInformationResponse>>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Result<TruckGeoPosition> _result;
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
                _result = new Result<TruckGeoPosition>();
                _result.AddError(err.Message);
                return BadRequest(_result);
            }
        }
        [HttpPost]
        public ActionResult Set([FromBody] TruckGeoPosition value)
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
        public ActionResult Update(int id, [FromBody] TruckGeoPosition value)
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
