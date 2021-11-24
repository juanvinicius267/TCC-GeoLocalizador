using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class TruckTravelServices
    {
        private readonly TruckTravelDao _context;
        public TruckTravelServices(TruckTravelDao context)
        {
            this._context = context;
        }
        public Result<List<TruckTravel>> Get()
        {
            return new Result<List<TruckTravel>>(_context.Get());
        }
        public Result<TruckTravel> GetById(int id)
        {
            return new Result<TruckTravel>(_context.GetById(id));
        }
        public Result<bool> Set(TruckTravel truckTravel)
        {
            return new Result<bool>(_context.Set(truckTravel));
        }
        public Result<bool> Update(int id, TruckTravel truckTravel)
        {
            return new Result<bool>(_context.Update(id, truckTravel));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
