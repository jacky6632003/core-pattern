using AutoMapper;
using core_pattern.Repository.DataModel;
using core_pattern.Service.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace core_pattern.Service.Infrastructure.Mapping
{
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            this.CreateMap<TestDataModel, TestResultModel>();
        }
    }
}