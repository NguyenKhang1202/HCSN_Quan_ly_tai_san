using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class FixedAssetCategory
    {
        public Guid fixed_asset_category_id { get; set; }
        public string? fixed_asset_category_code { get; set; }
        public string? fixed_asset_category_name { get; set; }
        public decimal depreciation_rate { get; set; }
        public int life_time { get; set; }
        public string? description { get; set; }
        public string? created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }
}
