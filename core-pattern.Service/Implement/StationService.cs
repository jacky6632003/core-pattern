using AutoMapper;
using core_pattern.Repository.ConditionModel;
using core_pattern.Repository.DataModel;
using core_pattern.Repository.Interface;
using core_pattern.Service.InfoModel;
using core_pattern.Service.Interface;
using core_pattern.Service.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Service.Implement
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationService(IStationRepository stationRepository, IMapper mapper)
        {
            this._stationRepository = stationRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StationResultModel>> Station(StationInfoModel para)
        {
            var cond = this._mapper.Map<StationInfoModel, StationConditionModel>(para);
            var data = await this._stationRepository.Station(cond);

            var result = this._mapper.Map<IEnumerable<StationDataModel>, IEnumerable<StationResultModel>>(data);
            return result;
        }
    }
}