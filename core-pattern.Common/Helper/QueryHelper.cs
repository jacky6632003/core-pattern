using core_pattern.Common.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace core_pattern.Common.Helper
{
    public static class QueryHelper
    {
        /// <summary>
        /// 取得分頁並排序.
        /// </summary>
        /// <param name="cases">The cases.</param>
        /// <param name="paging">The paging information.</param>
        /// <returns></returns>
        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            ref PageInfoModel paging)
        {
            if (paging == null)
            {
                throw new ArgumentException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            // 如果沒有指定查詢欄位就使用 第一個欄位
            var orderColumn = paging.OrderColumnName ?? typeof(TData).GetProperties().Take(1).Select(x => x.Name).First();
            if (paging.PageIndex == 0 && paging.PageSize == 0)
            {
                paging.PageIndex = 1;
                paging.PageSize = resultList.Count();
            }

            // 排序
            var property = typeof(TData).GetProperty(
                orderColumn,
                BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);

            if (property != null)
            {
                if (paging.Descending)
                {
                    resultList = resultList.OrderByDescending(column => property.GetValue(column, null));
                }
                else
                {
                    resultList = resultList.OrderBy(column => property.GetValue(column, null));
                }
            }

            // 取出欄位並分頁
            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }

        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            Func<TData, object> order,
            ref PageInfoModel paging)
        {
            if (paging == null)
            {
                throw new ArgumentException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            // 如果沒有指定查詢欄位就使用 CaseNo
            if (paging.PageIndex == 0 && paging.PageSize == 0)
            {
                paging.PageIndex = 1;
                paging.PageSize = resultList.Count();
            }

            // 排序
            if (paging.Descending)
            {
                resultList = resultList.OrderByDescending(order);
            }
            else
            {
                resultList = resultList.OrderBy(order);
            }

            // 取出欄位並分頁
            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }

        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            Func<TData, object> first,
            Func<TData, object> second,
            ref PageInfoModel paging)
        {
            if (paging == null)
            {
                throw new ArgumentException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            // 如果沒有指定查詢欄位就使用 CaseNo
            if (paging.PageIndex == 0 && paging.PageSize == 0)
            {
                paging.PageIndex = 1;
                paging.PageSize = resultList.Count();
            }

            // 排序
            if (paging.Descending)
            {
                resultList = resultList.OrderByDescending(first).ThenByDescending(second);
            }
            else
            {
                resultList = resultList.OrderBy(first).OrderBy(second);
            }

            // 取出欄位並分頁
            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }

        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            Func<TData, object> first,
            Func<TData, object> second,
            Func<TData, object> third,
            ref PageInfoModel paging)
        {
            if (paging == null)
            {
                throw new ArgumentException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            // 如果沒有指定查詢欄位就使用 CaseNo
            if (paging.PageIndex == 0 && paging.PageSize == 0)
            {
                paging.PageIndex = 1;
                paging.PageSize = resultList.Count();
            }

            // 排序
            if (paging.Descending)
            {
                resultList = resultList.OrderByDescending(first).OrderByDescending(second).OrderByDescending(third);
            }
            else
            {
                resultList = resultList.OrderBy(first).OrderBy(second).OrderBy(third);
            }

            // 取出欄位並分頁
            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }
    }
}