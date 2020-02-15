using core_pattern.Repository.DataModel;
using core_pattern.Repository.Helper;
using core_pattern.Repository.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace core_pattern.Repository.Implement
{
    public class TestRepository : ITestRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public TestRepository(IDatabaseHelper databaseHelper)
        {
            this._databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<TestDataModel>> GetTest()
        {
            //using (SqlConnection conn = (_databaseHelper.GetConnection(this._databaseHelper.WLDOConnectionString)) as SqlConnection)
            //{
            //    var result = await conn.QueryAsync<TestDataModel>(GetTestSQL());
            //    return result;
            //}

            var s = this._databaseHelper.WLDOConnectionString;
            var aa = this._databaseHelper.MySQLConnectionString;
            List<TestDataModel> result = new List<TestDataModel>();
            result.Add(new TestDataModel { BlogId = 1, Url = "aaaa" });
            result.Add(new TestDataModel { BlogId = 2, Url = "aaaa" });
            return result;
        }

        private string GetTestSQL()
        {
            string sql = $@"
";
            return sql;
        }
    }
}