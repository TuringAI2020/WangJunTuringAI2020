namespace WangJun.Yun
{
    using System;
    using System.Linq;


    /// <summary>
    /// ���ĵ�
    /// </summary>
    public partial class YunDocument
    {
        /// <summary>
        /// ��ȡһ��ʵ��
        /// </summary>
        /// <returns></returns>
        public static YunDocument GetInst()
        {
            var inst = new YunDocument();

            return inst;
        }

        public static YunDocument Parse(string jsonString)
        {
            var inst = JSON.ToObject<YunDocument>(jsonString);
            return inst;
        }

        public string ToJson()
        {
            return JSON.ToJson(this);
        }

        #region ����һ������
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <returns></returns>
        public RES Save()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            if (this.ID == Guid.Empty)
            {
                this.ID = Guid.NewGuid();
                this.CreateTime = DateTime.Now;
                this.UpdateTime = DateTime.Now;
                if (!this.Status.HasValue|| 0  == this.Status.Value)
                {
                    this.Status = (int)ENUM.EntityStatus.����;
                }
            }
            db.YunDocuments.Add(this);
            var task = db.SaveChangesAsync();
            if (0 < task.Result) {
                res.DATA = task.Result;
            }
            return (0 < task.Result) ? res.SetAsOK(task.Result) : res.SetAsFail(task.Result);
        }
        #endregion

        public RES Remove()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunDocuments.FirstOrDefault(p => p.ID == this.ID);
            db.YunDocuments.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }

        public RES Load()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunDocuments.FirstOrDefault(p => p.ID == this.ID);
            db.YunDocuments.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }
    }
}
