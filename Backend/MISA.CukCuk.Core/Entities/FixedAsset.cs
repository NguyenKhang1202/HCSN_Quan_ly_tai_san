using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class FixedAsset
    {
        public Guid fixed_asset_id { get; set; }
        public string? fixed_asset_name { get; set; }
        public string? fixed_asset_code { get; set; }
        public string department_code { get; set; }
        public string fixed_asset_category_code { get; set; }
        public string department_name { get; set; }
        public string fixed_asset_category_name { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
        public int life_time { get; set; }
        public decimal depreciation_rate { get; set; }
        public decimal depreciation_value { get; set; }
        public int tracked_year { get; set; }
        public DateTime purchase_date { get; set; }
        public DateTime production_date { get; set; }
        public int active { get; set; }
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }
}
