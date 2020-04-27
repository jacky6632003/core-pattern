using core_pattern.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Controllers.Parameters
{
    public class StationParameter
    {
        /// <summary>
        /// 欲查詢縣市
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public CityEnum City { get; set; }

        /// <summary>
        /// 挑選
        /// </summary>
        /// <value>
        /// The select.
        /// </value>
        public string select { get; set; }

        /// <summary>
        ///過濾
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string filter { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string orderby { get; set; }

        /// <summary>
        /// 取前幾筆
        /// </summary>
        /// <value>
        /// The top.
        /// </value>
        public int top { get; set; }

        /// <summary>
        /// 跳過前幾筆
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        public string skip { get; set; }

        /// <summary>
        /// 空間過濾
        /// </summary>
        /// <value>
        /// The spatial filter.
        /// </value>
        public string spatialFilter { get; set; }
    }
}