using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Controllers.ViewModels
{
    public class StationViewModel
    {
        public Station[] Property1 { get; set; }
    }

    public class Station
    {
        public string StationUID { get; set; }
        public string StationID { get; set; }
        public string AuthorityID { get; set; }
        public Stationname StationName { get; set; }
        public Stationposition StationPosition { get; set; }
        public Stationaddress StationAddress { get; set; }
        public int BikesCapacity { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class Stationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Stationposition
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }

    public class Stationaddress
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}