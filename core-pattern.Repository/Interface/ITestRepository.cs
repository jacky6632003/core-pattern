using core_pattern.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Repository.Interface
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestDataModel>> GetTest();
    }
}