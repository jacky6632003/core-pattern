using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Validators
{
    /// <summary>
    /// Validator驗證失敗回傳MODEL
    /// </summary>
    public class ValidatorErrorResult
    {
        /// <summary>
        /// 驗證欄位名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 驗證失敗訊息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}