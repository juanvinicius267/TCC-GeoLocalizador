using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GeoLocalizador.BE.Controllers
{
    [Route("raspberry")]
    [ApiController]
    public class RaspberryController : ControllerBase
    {
        private readonly GeoContext _context;
        private readonly ConvertDateTime _time;
        public RaspberryController(GeoContext context)
        {
            _context = context;
            _time = new ConvertDateTime();
        }
        
        [HttpGet("geo-location")]
        public ActionResult Set2([FromQuery] string param)
        {
            try
            {
                string[] dadosDoCadastro = param.ToString().Split(',');
                TruckGeoPosition _geo = new TruckGeoPosition
                {
                    IdTruck = 1004,
                    Longitude = dadosDoCadastro[1],
                    Latitude = dadosDoCadastro[0],
                    Course = dadosDoCadastro[5],
                    Speed = dadosDoCadastro[4],                    
                    Altitude = dadosDoCadastro[3],
                    Temperature = dadosDoCadastro[10],
                    Humidity = dadosDoCadastro[11],
                    RunStatus = dadosDoCadastro[7],
                    GnssSat = dadosDoCadastro[8],
                    GlonasSat = dadosDoCadastro[9],
                    FixMode = dadosDoCadastro[6],
                    LogDate = _time.ConvertUtcToBrasilia(DateTime.UtcNow)
                };
                _context.TruckGeoPositions.Add(_geo);
                _context.SaveChanges();
                return Ok();
                   
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
            
        }
        [HttpGet("rfid-logs")]
        public ActionResult SetRfidData([FromQuery] string param)
        {
            try
            {
                string[] dadosDoCadastro = param.ToString().Split(',');
                RfidLog _log = new RfidLog
                {
                    IdNumber = dadosDoCadastro[0],
                    Text = dadosDoCadastro[1],
                    RecordDateTime = _time.ConvertUtcToBrasilia(DateTime.UtcNow)
                };
                _context.RfidLogs.Add(_log);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return Problem(e.ToString());
            }
            
        }
        [HttpGet("get-rfid-data")]
        public ActionResult GetRfidData()
        {
            try
            {                
                return Ok(_context.RfidLogs.ToList());
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }

        }
    }
}
