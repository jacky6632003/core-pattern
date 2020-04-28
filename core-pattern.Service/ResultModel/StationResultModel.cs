using System;
using System.Collections.Generic;
using System.Text;

namespace core_pattern.Service.ResultModel
{
    public class StationResultModel
    {
        public string StationUID { get; set; }
        public string StationID { get; set; }
        public string AuthorityID { get; set; }
        public StationnameResultModel StationName { get; set; }
        public StationpositionResultModel StationPosition { get; set; }
        public StationaddressResultModel StationAddress { get; set; }
        public int BikesCapacity { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class StationnameResultModel
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class StationpositionResultModel
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }

    public class StationaddressResultModel
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}