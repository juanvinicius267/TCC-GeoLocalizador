using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeoLocalizador.BE.Shared
{
    public class ConvertDateTime 
    {
        public DateTime ConvertUtcToBrasilia(DateTime utc)
        {
            ReadOnlyCollection<TimeZoneInfo> timeZines = TimeZoneInfo.GetSystemTimeZones();
            TimeZoneInfo brasiliaTimeZone = timeZines
                .FirstOrDefault(t => t.DisplayName == "(UTC-03:00) Brasilia");
            if (brasiliaTimeZone == null)
            {
                brasiliaTimeZone = timeZines
                .FirstOrDefault(t => t.BaseUtcOffset.Hours == -03);
            }
            return TimeZoneInfo.ConvertTimeFromUtc(utc, brasiliaTimeZone).AddMinutes(30);
        }
    }
}
