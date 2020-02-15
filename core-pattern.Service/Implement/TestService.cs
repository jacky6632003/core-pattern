using AutoMapper;
using core_pattern.Repository.DataModel;
using core_pattern.Repository.Interface;
using core_pattern.Service.Interface;
using core_pattern.Service.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Service.Implement
{
    public class TestService : ITestService
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;

        public TestService(IMapper mapper, ITestRepository testRepository)
        {
            this._mapper = mapper;
            this._testRepository = testRepository;
        }

        public async Task<IEnumerable<TestResultModel>> GetTest()
        {
            var data = await this._testRepository.GetTest();

            var result = this._mapper.Map<IEnumerable<TestDataModel>, IEnumerable<TestResultModel>>(data);

            return result;
        }
    }
}