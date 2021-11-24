using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class VesselTravelServices
    {
        private readonly VesselTravelDao _context;
        public VesselTravelServices(VesselTravelDao context)
        {
            this._context = context;
        }
        public Result<List<VesselTravel>> Get()
        {
            return new Result<List<VesselTravel>>(_context.Get());
        }
        public Result<VesselTravel> GetById(int id)
        {
            return new Result<VesselTravel>(_context.GetById(id));
        }
        public Result<bool> Set(VesselTravel vesselTravel)
        {
            return new Result<bool>(_context.Set(vesselTravel));
        }
        public Result<bool> Update(int id, VesselTravel vesselTravel)
        {
            return new Result<bool>(_context.Update(id, vesselTravel));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
