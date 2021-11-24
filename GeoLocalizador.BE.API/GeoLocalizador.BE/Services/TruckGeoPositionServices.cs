using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class TruckGeoPositionServices
    {
        private readonly TruckGeoPositionDao _context;
        public TruckGeoPositionServices(TruckGeoPositionDao context)
        {
            this._context = context;
        }
        public Result<List<TruckGeoPosition>> Get()
        {
            return new Result<List<TruckGeoPosition>>(_context.Get());
        }
        public Result<List<TruckInformationResponse>> GetTravels()
        {
            return new Result<List<TruckInformationResponse>>(_context.GetTravels());
        }
        public Result<TruckGeoPosition> GetById(int id)
        {
            return new Result<TruckGeoPosition>(_context.GetById(id));
        }
        public Result<bool> Set(TruckGeoPosition truckGeoPosition)
        {
            return new Result<bool>(_context.Set(truckGeoPosition));
        }
        public Result<bool> Update(int id, TruckGeoPosition truckGeoPosition)
        {
            return new Result<bool>(_context.Update(id, truckGeoPosition));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
