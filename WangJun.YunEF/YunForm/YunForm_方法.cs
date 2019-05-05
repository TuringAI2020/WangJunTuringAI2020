namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

 
    public partial class YunForm 
    {
        public static YunForm Parse(string jsonString) {
            var inst = JSON.ToObject<YunForm>(jsonString);
            return inst;
        }

        public virtual string ToJson()
        {
            var res = JSON.ToJson(this);
            return res;
        }

        /// <summary>
        /// 同步保存一个对象
        /// </summary>
        /// <returns></returns>
        public virtual RES Save()
        {
            var res = RES.New;

            if (Guid.Empty == this.ID)
            {
                this.ID = Guid.NewGuid();
                this.CreateTime = DateTime.Now;
                if (!this.Status.HasValue) { this.Status = (int)ENUM.实体状态.正常; }
            }
;

            var db = ModelEF.GetInst();
            db.YunForms.Add(this);
            db.SaveChanges();
            return res;
        } 

        public RES Remove()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunForms.FirstOrDefault(p => p.ID == this.ID);
            db.YunForms.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }

        public RES LoadList(long formType)
        {
            var res = RES.New;
            var db = ModelEF.GetInst();

            var query = from item in db.YunForms where formType == item.FormType  select item;
            res.DATA = query.ToList();
            return res.SetAsOK();
        }

        public RES LoadList_Article(string filter, string keyword, string parentNodeID,string permissionGroupID ,string sourceID, string createTime ,string updateTime, long pageIndex,long pageSize , long formType,long status,string columnArray,string orderby )
        {
            var res = RES.New;
            var db = ModelEF.GetInst();

            var query = from item in db.YunForms  select item;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p => p.Title.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(parentNodeID))
            {
                var guid_parentNodeID = Guid.Parse(parentNodeID);
                query = query.Where(p => p.ParentNodeID == guid_parentNodeID);
            }

            if (!string.IsNullOrWhiteSpace(permissionGroupID))
            {
                var guid_permissionGroupID = Guid.Parse(permissionGroupID);
                query = query.Where(p => p.PermissionGroupID == guid_permissionGroupID);
            }

            if (!string.IsNullOrWhiteSpace(sourceID))
            {
                var guid_sourceID = Guid.Parse(sourceID);
                query = query.Where(p => p.SourceID == guid_sourceID);
            }

            if (!string.IsNullOrWhiteSpace(createTime))
            {
                var _createTime = DateTime.Parse(createTime);
                query = query.Where(p => p.CreateTime == _createTime);
            }

            if (!string.IsNullOrWhiteSpace(updateTime))
            {
                var _updateTime = DateTime.Parse(updateTime);
                query = query.Where(p => p.UpdateTime == _updateTime);
            }

            if (0<formType)
            {
                var _formType = formType % int.MaxValue;
                query = query.Where(p => p.FormType == _formType);
            }

            if (0 < status)
            {
                var _status = status % int.MaxValue;
                query = query.Where(p => p.Status == _status);
            }

            if (0 <= pageIndex && 0<pageSize)
            {
                int _pageIndex =Convert.ToInt32(pageIndex % int.MaxValue);
                int _pageSize = Convert.ToInt32(pageSize % int.MaxValue);
                res.TotalCount = query.Count();
                res.PageSize = _pageSize;
                res.PageIndex = _pageIndex;
                query = query.OrderByDescending(p=>CreateTime).Skip(_pageIndex * _pageSize).Take(_pageSize);
            }


            res.DATA = query.ToList();
            return res.SetAsOK();
        }

        public RES Load(string id)
        {
            var db = ModelEF.GetInst();
            var guid = Guid.Parse(id);
            var query = from item in db.YunForms where item.ID == guid select item;
            return RES.New.SetAsOK(query.FirstOrDefault());
        }


        public void InitialDateTime()
        {
            if (!this.CreateTime.HasValue)
            {
                this.CreateTime = DateTime.Now;
            }

            if (!this.UpdateTime.HasValue)
            {
                this.UpdateTime = this.CreateTime;
            }

        }

        public RES LoadList_Comment(string sourceIDStr)
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var formType = (int)ENUM.ServiceType.云评论;
            var sourceID = Guid.Parse(sourceIDStr);
            var query = from item in db.YunForms where formType == item.FormType && sourceID == item.SourceID select item;
            res.DATA = query.ToList();
            return res.SetAsOK();
        }

    }
}
