using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoLocalizador.BE.Dao;

namespace GeoLocalizador.BE.Services
{
    public class TruckInfoServices
    {
        private readonly TruckInfoDao _context;
        public TruckInfoServices(TruckInfoDao context)
        {
            this._context = context;
        }
        public Result<List<TruckInfo>> Get()
        {
            return new Result<List<TruckInfo>>(_context.Get());
        }
        public Result<TruckInfo> GetById(int id)
        {
            return new Result<TruckInfo>(_context.GetById(id));
        }
        public Result<bool> Set(TruckInfo truckInfo)
        {
            return new Result<bool>(_context.Set(truckInfo));
        }
        public Result<bool> Update(int id, TruckInfo truckInfo)
        {
            return new Result<bool>(_context.Update(id, truckInfo));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
