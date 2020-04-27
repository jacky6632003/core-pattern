using core_pattern.Repository.ConditionModel;
using core_pattern.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Repository.Interface
{
    public interface IStationRepository
    {
        Task<IEnumerable<StationDataModel>> Station(StationConditionModel para);
    }
}