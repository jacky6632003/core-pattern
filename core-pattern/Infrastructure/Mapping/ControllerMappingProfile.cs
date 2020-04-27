using AutoMapper;
using core_pattern.Controllers.Parameters;
using core_pattern.Controllers.ViewModels;
using core_pattern.Service.InfoModel;
using core_pattern.Service.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Mapping
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<TestResultModel, TestViewModel>();

            this.CreateMap<StationResultModel, StationViewModel>();

            this.CreateMap<StationParameter, StationInfoModel>();
        }
    }
}