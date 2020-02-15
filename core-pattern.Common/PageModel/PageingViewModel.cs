using System;
using System.Collections.Generic;
using System.Text;

namespace core_pattern.Common.PageModel
{
    public class PageingViewModel
    {
        /// <summary>
        /// 分頁大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 目前頁面
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 總數
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 排序欄位
        /// </summary>
        public string OrderColumnName { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public bool Descending { get; set; }
    }
}