﻿using Ga_AGV.BLL;
using Ga_AGV.Model.Commonality;
using Ga_AGV.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ga_AGV.Core.API
{
    public class AgvlogController : ApiController
    {
        private Ga_agvlogBLL ga_AgvlogBLL = new Ga_agvlogBLL();

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="limit">页面大小</param>
        /// <param name="offset">当前页</param>
        /// <returns></returns>
        [HttpGet]
        public JsonData<Ga_agvloginfo> Log(int limit, int offset, string query_log_time, string query_start_time, string query_end_time, string query_agv_num, string query_task_status, string query_agv_status)
        {
            int PageCount = 0;
            JsonData<Ga_agvloginfo> data = new JsonData<Ga_agvloginfo>
            {
                rows = ga_AgvlogBLL.Ga_AgvloginfosBLL(ref PageCount, limit, offset, query_log_time, query_start_time, query_end_time, query_agv_num, query_task_status, query_agv_status),
                total = PageCount
            };
            return data;
        }
    }
}