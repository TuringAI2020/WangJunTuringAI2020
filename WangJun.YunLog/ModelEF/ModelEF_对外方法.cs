using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public partial class ModelEF : DbContext
    {
        public static ModelEF GetInst() {
            var inst = new ModelEF();
            return inst;
        }

 
        public List<Dictionary<string, object>> ExecuteSQL(string sql,object param)
        {
            var paramaArray= new List<SqlParameter>();
            if (param is string)
            {
                var paramaDict = JSON.ToObject<Dictionary<string,object>>(param.ToString());
                foreach (var item in paramaDict)
                {
                    paramaArray.Add(new SqlParameter(item.Key, item.Value));
                }

            }
            //else if (param is object[])
            //{
            //    paramaArray = param as object[];
            //}
            else if (null == param) {
                paramaArray = null;
            }


            var db = ModelEF.GetInst().Database;
            var res = db.SqlQuery<Dictionary<string, object>>(sql, paramaArray.ToArray()).ToList();
            db.Connection.Close();
            return res;
        }
    }
}
