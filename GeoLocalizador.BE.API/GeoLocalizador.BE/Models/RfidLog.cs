using System;
using System.ComponentModel.DataAnnotations;

namespace GeoLocalizador.BE.Models
{
    public class RfidLog
    {
        [Key]
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string Text { get; set; }
        public DateTime RecordDateTime { get; set; }
    }
}
