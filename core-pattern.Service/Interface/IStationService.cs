using core_pattern.Service.InfoModel;
using core_pattern.Service.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Service.Interface
{
    public interface IStationService
    {
        Task<IEnumerable<StationResultModel>> Station(StationInfoModel para);
    }
}