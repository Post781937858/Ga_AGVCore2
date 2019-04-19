﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga_AGV.Model.Commonality
{
    /// <summary>
    /// JSON数据对象
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
    }

    public class JsonFile : JsonResult
    {
        public string Data { get; set; }
    }



    public class Json<T> where T : class
    {
        public T Data { get; set; }

        public string Value { get; set; }
    }

}
