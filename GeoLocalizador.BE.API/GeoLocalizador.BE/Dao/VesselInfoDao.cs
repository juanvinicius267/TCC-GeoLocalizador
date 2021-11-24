using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class VesselInfoDao
    {
        private readonly GeoContext _context;
        public VesselInfoDao(GeoContext context)
        {
            _context = context;
        }
        public List<VesselInfo> Get()
        {
            return _context.VesselInfos
                 .ToList();
        }
        public VesselInfo GetById(int id)
        {
            return _context.VesselInfos
                .FirstOrDefault(h => h.IdNavio == id);
        }
        public bool Set(VesselInfo vessel)
        {
            _context.VesselInfos.Add(vessel);
            return _context.SaveChanges() > 0;
        }
        public bool Update(int id, VesselInfo vessel)
        {
            VesselInfo _vessel = _context.VesselInfos
                .FirstOrDefault(h => h.IdNavio == id);
            if (vessel != null)
            {
                _vessel.IMO = vessel.IMO;
                _vessel.Name = vessel.Name;
                _vessel.Vessel_Type_Generic = vessel.Vessel_Type_Generic;
                _vessel.Vessel_Type_Detailed = vessel.Vessel_Type_Detailed;
                _vessel.Status = vessel.Status;
                _vessel.MMSI = _vessel.MMSI;
                _vessel.Status = _vessel.Status;
                _vessel.Call_Sign = _vessel.Call_Sign;
                _vessel.Flag = _vessel.Flag;
                _vessel.Gross_Tonnage = _vessel.Gross_Tonnage;
                _vessel.LengthxBreadth = _vessel.LengthxBreadth;
                _vessel.Year_Built = _vessel.Year_Built;
                _vessel.Home_Port = _vessel.Home_Port;
                _vessel.Flag = _vessel.Flag;
                _vessel.LastChange = DateTime.Now;
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            VesselInfo vessel = _context.VesselInfos
                .FirstOrDefault(h => h.IdNavio == id);
            _context.VesselInfos.Remove(vessel);
            return _context.SaveChanges() > 0;
        }
    }
}
