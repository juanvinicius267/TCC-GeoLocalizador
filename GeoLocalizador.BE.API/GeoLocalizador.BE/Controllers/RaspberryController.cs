using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeoLocalizador.BE.Controllers
{
    [Route("raspberry")]
    [ApiController]
    public class RaspberryController : ControllerBase
    {
        private readonly GeoContext _context;
        public RaspberryController(GeoContext context)
        {
            _context = context;
        }
        [HttpPost("set-data")]
        public int Set([FromQuery] object param)
        {

            string[] dadosDoCadastro = param.ToString().Split(',');
            TruckGeoPosition _geo = new TruckGeoPosition
            {
                Longitude = dadosDoCadastro[0],
                Latitude = dadosDoCadastro[1],
                Speed = 0,
                Satellites = 0,
                Altitude = 0,
                GeoSep = 0,
                RefStationId = "",
                LogDate = DateTime.Now
            };
            _context.TruckGeoPositions.Add(_geo);
            return _context.SaveChanges();
        }
        [HttpGet("set-data-2")]
        public int Set2([FromQuery] string param)
        {
            string[] dadosDoCadastro = param.ToString().Split(',');
            TruckGeoPosition _geo = new TruckGeoPosition
            {
                IdTruck = 2,
                Longitude = dadosDoCadastro[1],
                Latitude = dadosDoCadastro[0],
                Speed = 0,
                Satellites = 0,
                Altitude = 0,
                GeoSep = 0,
                RefStationId = "",
                LogDate = DateTime.Now
            };
            _context.TruckGeoPositions.Add(_geo);
            return _context.SaveChanges();
        }
    }
}
