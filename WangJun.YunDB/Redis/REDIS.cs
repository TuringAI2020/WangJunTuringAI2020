using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.YunDB
{
    /// <summary>
    /// Redis服务
    /// </summary>
    public partial class REDIS
    {
        protected ConnectionMultiplexer redisClient = null;

        protected IDatabase GetRedis() {
            var db = this.redisClient.GetDatabase();
            return db;
        }

        protected IServer GetServer()
        {
            var svr = this.redisClient.GetServer("localhost",6379);
            return svr;
        }

        /// <summary>
        /// 创建一个实例
        /// </summary>
        /// <returns></returns>
        public static REDIS CreateInstance() {
            var inst = new REDIS();
            var config = ConfigurationOptions.Parse("localhost");
            config.AllowAdmin = true;
            inst.redisClient = ConnectionMultiplexer.Connect(config);
            return inst;
        }

        public RES SaveToDisk() {
            return null;
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RES SaveToDB(string key,object value,string prefix="") {
            var res = RES.New;
            var fullKey = string.Format("{0}_{1}",prefix,key);
            var db = this.GetRedis();
            db.StringSet(fullKey, JSON.ToJson(value));
            return res.SetAsOK();
        }

        public RES ClearDB() {
            var res = RES.New;
            var svr = this.GetServer();
            svr.FlushAllDatabases();
            return res;
        }

        /// <summary>
        /// 获取所有的Key
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys() {
            var svr = this.GetServer();
            var keys = svr.Keys(0, "*", int.MaxValue).Select(p=>p.ToString());
            return keys.ToList();
        }

        /// <summary>
        /// 是否存在指定的键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public RES HasKey(string key, string prefix = "") {
            var res = RES.New;
            var fullKey = string.Format("{0}_{1}", prefix, key);
            var db = this.GetRedis();
            res.DATA = db.KeyExists(fullKey);
            return res.SetAsOK();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public RES GetFromDB(string key,string prefix = "") {
            var res = RES.New;
            var fullKey = string.Format("{0}_{1}", prefix, key);
            var db = this.GetRedis();
            var resJson = db.StringGet(fullKey);
            return res.SetAsOK(resJson);
        }

        public RES GetFromDB<T>(string key, string prefix = "")
        {
            var res = RES.New;
            var fullKey = string.Format("{0}_{1}", prefix, key);
            var db = this.GetRedis();
            var resJson = db.StringGet(fullKey);
            var resData = JSON.ToObject<T>(resJson);
            return res.SetAsOK(res);
        }

        /// <summary>
        /// 从数据库中移除
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public RES RemoveFromDB(string key, string prefix = "") {
            var res = RES.New;
            var fullKey = string.Format("{0}_{1}", prefix, key);
            var db = this.GetRedis();
            db.KeyDelete(fullKey);
            return res.SetAsOK();
        }
         


        public object PushToStack() {
            return null;
        }

        public object PopFromStack() {
            return null;
        }

        public RES SaveToSet() {
            return null;
        }

        public RES SaveToSortSet()
        {
            return null;
        }


    }
}
