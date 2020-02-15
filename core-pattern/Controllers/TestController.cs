using AutoMapper;
using core_pattern.Controllers.ViewModels;
using core_pattern.Service.Interface;
using core_pattern.Service.ResultModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestService _testService;

        public TestController(IMapper mapper, ITestService testService)
        {
            this._mapper = mapper;
            this._testService = testService;
        }

        [HttpGet]
        public async Task<IEnumerable<TestViewModel>> Gettest()
        {
            var data = await this._testService.GetTest();
            var result = this._mapper.Map<IEnumerable<TestResultModel>, IEnumerable<TestViewModel>>(data);

            return result;
        }
    }
}