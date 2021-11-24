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
    [Route("api/[controller]")]
    [ApiController]
    public class VesselInfoController : ControllerBase
    {
        private readonly VesselInfoServices _context;
        public VesselInfoController(VesselInfoServices context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<VesselInfo>> _result = _context.Get();
            if (_result.Success == true)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Result<VesselInfo> _result = _context.GetById(id);
            if (_result.Success == true)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }
        [HttpPost]
        public ActionResult Set([FromBody] VesselInfo vessel)
        {
            Result<bool> _result = _context.Set(vessel);
            if (_result.Success == true)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] VesselInfo vessel)
        {
            Result<bool> _result = _context.Update(id, vessel);
            if (_result.Success == true)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Result<bool> _result = _context.Delete(id);
            if (_result.Success == true)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }
    }
}
