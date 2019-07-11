using System;

namespace WangJun.Yun
{
    /// <summary>
    /// 云服务客户端
    /// </summary>
    public class YunClient
    {
        protected string appId = null;

        #region 获取一个实例
        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static YunClient GetInstance(string appId, string appSecret)
        {
            var inst = new YunClient();
            return inst;
        }
        #endregion

        #region 写入云日志
        /// <summary>
        /// 写入云日志
        /// </summary>
        /// <param name="position"></param>
        /// <param name="msg"></param>
        /// <param name="param"></param>
        /// <param name="remark"></param>
        /// <param name="summary"></param>
        /// <param name="typeID"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public RES SaveLog(string position, string msg, string param, string remark, string summary, int typeID, string typeName)
        {
            try
            {
                var log = new { CreateTime = DateTime.Now, Position = position, Msg = msg, Param = param, Remark = remark, Summary = summary, TypeID = typeID, TypeName = typeName, AppID = this.appId };
                var res = HTTP.POST("http://localhost:6003/LogAPI.ashx", null, JSON.ToJson(new
                {
                    TargetClass = "YunLog",
                    Method = "Save",
                    Param = new { },
                    InputParamArray = new string[] { JSON.ToJson(log) }
                }));
                return RES.OK(res);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);
            }
        }
        #endregion
    }
}
