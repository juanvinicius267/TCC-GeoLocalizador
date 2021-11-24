using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using System.Collections.Generic;

namespace GeoLocalizador.BE.Services
{
    public class HarborServices
    {
        private readonly HarborDao _context;
        public HarborServices(HarborDao context)
        {
            this._context = context;
        }
        public Result<List<Harbor>> Get()
        {
            return new Result<List<Harbor>>(_context.Get());
        }
        public Result<Harbor> GetById(int id)
        {
            return new Result<Harbor>(_context.GetById(id));
        }
        public Result<bool> Set(Harbor harbor)
        {
            return new Result<bool>(_context.Set(harbor));
        }
        public Result<bool> Update(int id, Harbor harbor)
        {
            return new Result<bool>(_context.Update(id, harbor));
        }
        public Result<bool> Delete(int id)
        {
            return new Result<bool>(_context.Delete(id));
        }
    }
}
