using System;
using System.Collections.Generic;
using System.Text;

namespace core_pattern.Common.PageModel
{
    public class PageViewModel<T>
    {
        /// <summary>
        /// 分頁查詢結果
        /// </summary>
        public IEnumerable<T> result { get; set; }

        /// <summary>
        /// 分頁明細
        /// </summary>
        public PageingViewModel paging { get; set; }
    }
}