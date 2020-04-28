using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Controllers.ViewModels
{
    public class StationViewModel
    {
        public string StationUID { get; set; }
        public string StationID { get; set; }
        public string AuthorityID { get; set; }
        public StationnameViewModel StationName { get; set; }
        public StationpositionViewModel StationPosition { get; set; }
        public StationaddressViewModel StationAddress { get; set; }
        public int BikesCapacity { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class StationnameViewModel
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class StationpositionViewModel
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }

    public class StationaddressViewModel
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}