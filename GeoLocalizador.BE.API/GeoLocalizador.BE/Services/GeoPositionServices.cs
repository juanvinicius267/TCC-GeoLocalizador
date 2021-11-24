using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class GeoPositionServices
    {
        private readonly GeoPositionDao _context;
        public GeoPositionServices(GeoPositionDao context)
        {
            this._context = context;
        }
        public Result<List<GeoPosition>> Get()
        {
            return new Result<List<GeoPosition>>(_context.Get());
        }
        public Result<GeoPosition> GetById(int id)
        {
            return new Result<GeoPosition>(_context.GetById(id));
        }
        public Result<bool> Set(GeoPosition geoPosition)
        {
            return new Result<bool>(_context.Set(geoPosition));
        }
        public Result<bool> Update(int id, GeoPosition geoPosition)
        {
            return new Result<bool>(_context.Update(id, geoPosition));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
