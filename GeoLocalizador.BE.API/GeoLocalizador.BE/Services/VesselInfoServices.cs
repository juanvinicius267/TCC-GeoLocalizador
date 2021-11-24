using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class VesselInfoServices
    {
        private readonly VesselInfoDao _context;
        public VesselInfoServices(VesselInfoDao context)
        {
            this._context = context;
        }
        public Result<List<VesselInfo>> Get()
        {
            return new Result<List<VesselInfo>>(_context.Get());
        }
        public Result<VesselInfo> GetById(int id)
        {
            return new Result<VesselInfo>(_context.GetById(id));
        }
        public Result<bool> Set(VesselInfo vessel)
        {
            return new Result<bool>(_context.Set(vessel));
        }
        public Result<bool> Update(int id, VesselInfo vessel)
        {
            return new Result<bool>(_context.Update(id, vessel));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
