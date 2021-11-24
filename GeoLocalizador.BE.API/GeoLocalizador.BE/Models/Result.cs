using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeoLocalizador.BE.Models
{
    public class Result<T> : Result
    {
        public Result()
        {
        }

        public Result(T data)
        {
            Errors = new List<string>();
            Data = data;
        }

        //** this attribute is intended to prevent xml serialization exceptions when the application starts
        [XmlIgnore]
        public T Data { get; set; }
    }

    public class Result
    {
        public Result()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErros(List<string> errors)
        {
            Errors.AddRange(errors);
        }

        public bool Success { get { return Errors.Count == 0; } }
        public List<string> Errors { get; protected set; }
    }
}
