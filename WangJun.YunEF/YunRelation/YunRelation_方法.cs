using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 云关系
    /// </summary>
    public partial class YunRelation
    {

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public RES Save()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();

            if (this.ID == Guid.Empty)
            {
                this.ID = Guid.NewGuid();
                db.YunRelations.Add(this);
            }
            else {
                var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == this.ID);
                if (null != currentEntity)
                {
                    currentEntity.Name = this.Name;
                }
            }

            db.SaveChanges();
            return res.SetAsOK();
        }

        /// <summary>
        /// 移动至
        /// </summary>
        /// <returns></returns>
        public RES MoveTo(string currentId, string newGroupId)
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var currentNode = db.YunRelations.FirstOrDefault(p => p.ID == new Guid(currentId));
            var newGroupNode = db.YunRelations.FirstOrDefault(p => p.ID == new Guid(newGroupId));
            if (null != currentNode)
            {
                currentNode.GroupID = new Guid(newGroupId);
                currentNode.GroupName = newGroupNode.Name;
            }

            db.SaveChanges();

            return res.SetAsOK();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public RES Delete()
        {
            var res = RES.New;

            return res.SetAsOK();
        }

        /// <summary>
        /// 创建树
        /// </summary>
        /// <returns></returns>
        public RES BuildMap()
        {
            var res = RES.New;

            return res.SetAsOK();
        }

    }
}
