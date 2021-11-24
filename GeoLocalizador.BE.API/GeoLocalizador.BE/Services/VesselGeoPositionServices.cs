using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class VesselGeoPositionServices
    {
        private readonly VesselGeoPositionDao _context;
        public VesselGeoPositionServices(VesselGeoPositionDao context)
        {
            this._context = context;
        }
        public Result<List<VesselGeoPosition>> Get()
        {
            return new Result<List<VesselGeoPosition>>(_context.Get());
        }
        public Result<VesselGeoPosition> GetById(int id)
        {
            return new Result<VesselGeoPosition>(_context.GetById(id));
        }
        public Result<bool> Set(VesselGeoPosition position)
        {
            return new Result<bool>(_context.Set(position));
        }
        public Result<bool> Update(int id, VesselGeoPosition position)
        {
            return new Result<bool>(_context.Update(id, position));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
