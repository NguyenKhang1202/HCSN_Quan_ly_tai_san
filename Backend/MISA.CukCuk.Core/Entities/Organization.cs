using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class Organization
    {
        public Guid organization_id { get; set; }
        public string? organization_code { get; set; }
        public string? organization_name { get; set; }
        public string? description { get; set; }
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }
}
