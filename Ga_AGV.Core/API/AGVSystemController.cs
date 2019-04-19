﻿using Ga_AGV.BLL;
using Ga_AGV.Model.Commonality;
using Ga_AGV.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Ga_AGV.Core.API
{
    public class AGVSystemController : ApiController
    {
        private Ga_qrcodeBLL BLL = new Ga_qrcodeBLL();
        private Ga_agvMonitoringBLL agvMonitoring = new Ga_agvMonitoringBLL();

        /// <summary>
        /// 获取所有QR_Code数据
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonData<Ga_qrcode> QRCodeShow(int limit, int offset, string qrID, int qrStatus)
        {
            int pageCount = 0;
            try
            {
                if (qrID != null)
                {
                    int.Parse(qrID);
                }
            }
            catch (Exception)
            {
                return new JsonData<Ga_qrcode>();
                throw;
            }
            JsonData<Ga_qrcode> data = new JsonData<Ga_qrcode>
            {
                rows = BLL.Ga_QrcodeBLL(ref pageCount, limit, offset, qrID, qrStatus),
                total = pageCount
            };
            return data;
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EmptyQRCode()
        {
            if (BLL.Ga_EmptyQRcodeBLL())
            {
                return new JsonResult() { Message = "成功", Success = true };
            }
            else
            {
                return new JsonResult() { Message = "失败", Success = false };
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddQRCode_s([FromBody] Ga_map map)
        {
            if (BLL.Ga_Adds(map))
            {
                return new JsonResult() { Message = "添加成功", Success = true };
            }
            else
            {
                return new JsonResult() { Message = "添加失败", Success = false };
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddQRCode([FromBody] Ga_qrcode qrcode)
        {
            if (BLL.Ga_AddQRcodeBLL(qrcode))
            {
                return new JsonResult() { Message = "添加成功", Success = true };
            }
            else
            {
                return new JsonResult() { Message = "添加失败", Success = false };
            }
        }

        /// <summary>
        /// 更改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpQRCode([FromBody] Ga_qrcode qrcode)
        {
            if (BLL.Ga_UpQRcodeBLL(qrcode))
            {
                return new JsonResult() { Message = "修改成功", Success = true };
            }
            else
            {
                return new JsonResult() { Message = "修改失败", Success = false };
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelQRCode([FromBody] List<Ga_qrcode> qrcode)
        {
            if (BLL.Ga_DelQRcodeBLL(qrcode))
            {
                return new JsonResult() { Message = "删除成功", Success = true };
            }
            else
            {
                return new JsonResult() { Message = "删除失败", Success = false };
            }
        }

        #region 监控

        [HttpPost]
        public JsonData_map<Ga_qrcode> ShowPlace()
        {
            int mapX = 0; int mapY = 0;
            JsonData_map<Ga_qrcode> data = new JsonData_map<Ga_qrcode>
            {
                rows = agvMonitoring.BLLShowQRplace(ref mapX, ref mapY),
                map_X = mapX,
                map_Y = mapY
            };

            return data;
        }

        [HttpPost]
        public List<Jsontaskinfo> AGVlocation([FromBody] Ga_agv agvdata)
        {
            List<Jsontaskinfo> list = new List<Jsontaskinfo>
            {
                new Jsontaskinfo() { agvNum = 1, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "56", Task = "运输", taskStartQR = "20", taskEndQR = "50" },
                new Jsontaskinfo() { agvNum = 2, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "156", Task = "运输", taskStartQR = "20", taskEndQR = "50" },
                new Jsontaskinfo() { agvNum = 3, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "100", Task = "运输", taskStartQR = "20", taskEndQR = "50" },
                new Jsontaskinfo() { agvNum = 4, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "78", Task = "运输", taskStartQR = "20", taskEndQR = "50" },
                new Jsontaskinfo() { agvNum = 5, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "20", Task = "运输", taskStartQR = "20", taskEndQR = "50" },
                new Jsontaskinfo() { agvNum = 6, agvIsRunning = "在线", qrcode = "11", PBS = "区域3", agvHolder = "下降", Message = "障碍物检测", agvQR = "134", Task = "运输", taskStartQR = "20", taskEndQR = "50" }
            };
            return list;
        }

        #endregion 监控
    }
}