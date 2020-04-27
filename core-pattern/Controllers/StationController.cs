using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core_pattern.Controllers.Parameters;
using core_pattern.Controllers.ViewModels;
using core_pattern.Service.InfoModel;
using core_pattern.Service.Interface;
using core_pattern.Service.ResultModel;
using Microsoft.AspNetCore.Mvc;

namespace core_pattern.Controllers
{
    [Route("api/[controller]")]
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly IMapper _mapper;

        public StationController(IStationService stationService, IMapper mapper)
        {
            this._stationService = stationService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("Station")]
        public async Task<IEnumerable<StationViewModel>> Station(StationParameter para)
        {
            var info = this._mapper.Map<StationParameter, StationInfoModel>(para);
            var data = await this._stationService.Station(info);

            var result = this._mapper.Map<IEnumerable<StationResultModel>, IEnumerable<StationViewModel>>(data);
            return result;
        }
    }
}