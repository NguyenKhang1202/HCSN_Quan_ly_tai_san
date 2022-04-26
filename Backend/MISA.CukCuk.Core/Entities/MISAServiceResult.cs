using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    public class MISAServiceResult
    {
        public string? UserMsg { get; set; } = null;
        public string? DevMsg { get; set; } = null;
        public object? Data { get; set; } = null;
    }
}
