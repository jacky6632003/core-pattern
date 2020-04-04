using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace core_pattern.Repository.DataModel
{
    public class TestDataModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Blog 編號
        /// </summary>
        public int BlogId { get; set; }

        /// <summary>
        /// Blog Url
        /// </summary>

        public string Url { get; set; }
    }
}