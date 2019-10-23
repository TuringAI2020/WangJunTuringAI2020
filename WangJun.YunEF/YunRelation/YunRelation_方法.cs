using System;
using System.Linq;

namespace WangJun.Yun
{
    /// <summary>
    /// 云关系
    /// </summary>
    public partial class YunRelation
    {

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <returns></returns>
        public RES Save()
        {
            try
            {
                var db = ModelEF.GetInst();

                if (this.ID == Guid.Empty)
                {
                    this.ID = Guid.NewGuid();
                    db.YunRelations.Add(this);
                }
                else
                {
                    var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == this.ID);
                    if (null != currentEntity)
                    {
                        currentEntity.Name = this.Name;
                    }
                }

                db.SaveChangesAsync();
                return RES.OK();
            }
            catch (Exception ex)
            {
                return RES.FAIL();
            }
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootId"></param>
        /// <returns></returns>
        public RES LoadList(string rootId)
        {
            if (GUID.IsGuid(rootId))
            {
                var rootID = Guid.Parse(rootId);
                var db = ModelEF.GetInst();
                var res = db.YunRelations.Where(p => p.RootID == rootID);
                return RES.New.SetAsOK(res);
            }
            return RES.New.SetAsFail();
        }


        #region 创建一个根节点
        /// <summary>
        /// 创建一个根节点
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RES CreateRootNode(string name)
        {

            if (!string.IsNullOrWhiteSpace(name))
            {
                var inst = new YunRelation { CreateTime = DateTime.Now, Name = name, RootID = null, ParentID = null, UpdateTime = DateTime.Now };
                var res = inst.Save();
                return res;
            }
            return RES.FAIL();
        }
        #endregion

        #region 创建一个子节点
        /// <summary>
        /// 创建一个子节点
        /// </summary>
        /// <param name="rootId"></param>
        /// <param name="parentId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public RES CreateChildNode(string rootId, string parentId, string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && GUID.IsGuid(rootId) && GUID.IsGuid(parentId))
            {
                var inst = new YunRelation { CreateTime = DateTime.Now, Name = name, RootID = Guid.Parse(rootId), ParentID = Guid.Parse(parentId), UpdateTime = DateTime.Now };
                var res = inst.Save();
                return res;
            }
            return RES.FAIL();
        }
        #endregion

        #region 移除一个子节点
        /// <summary>
        /// 移除一个子节点
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public RES RemoveNode(string nodeId)
        {
            if (GUID.IsGuid(nodeId))
            {
                try
                {
                    var nId = Guid.Parse(nodeId);
                    var db = ModelEF.GetInst();
                    var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == nId);
                    if (null != currentEntity)
                    {
                        currentEntity.Status = (int)ENUM.实体状态.已删除;
                    }
                    db.SaveChangesAsync();
                    return RES.OK();
                }
                catch (Exception ex)
                {
                    return RES.FAIL();
                }

            }
            return RES.FAIL();
        }
        #endregion

        #region 修改一个子节点的信息
        /// <summary>
        /// 修改一个子节点的信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public RES RenameNode(string nodeId,string newName)
        {
            if (GUID.IsGuid(nodeId)&&!string.IsNullOrWhiteSpace(newName))
            {
                try
                {
                    var nId = Guid.Parse(nodeId);
                    var db = ModelEF.GetInst();
                    var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == nId);
                    if (null != currentEntity)
                    {
                        currentEntity.Name = newName;
                    }
                    db.SaveChangesAsync();
                    return RES.OK();
                }
                catch (Exception ex)
                {
                    return RES.FAIL();
                }

            }
            return RES.FAIL();
        }
        #endregion

        #region 获取当前节点信息
        /// <summary>
        /// 获取当前节点信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public RES GetCurrentNode(string nodeId)
        {
            if (GUID.IsGuid(nodeId))
            {
                try
                {
                    var nId = Guid.Parse(nodeId);
                    var db = ModelEF.GetInst();
                    var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == nId); 
                    return RES.OK(currentEntity);
                }
                catch (Exception ex)
                {
                    return RES.FAIL();
                }

            }
            return RES.FAIL();
        }
        #endregion

        #region 获取子节点集合
        /// <summary>
        /// 获取子节点集合
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public RES GetChildNodes(string nodeId)
        {
            if (GUID.IsGuid(nodeId))
            {
                try
                {
                    var nId = Guid.Parse(nodeId);
                    var db = ModelEF.GetInst();
                    var childNodes = db.YunRelations.Where(p => p.ParentID == nId);
                    return RES.OK(childNodes);
                }
                catch (Exception ex)
                {
                    return RES.FAIL();
                }

            }
            return RES.FAIL();
        }
        #endregion

        #region 获取整棵树
        /// <summary>
        /// 获取整棵树
        /// </summary>
        /// <returns></returns>
        public RES GetWholeTree(string rootID)
        {
            if (GUID.IsGuid(rootID))
            {
                try
                {
                    var nId = Guid.Parse(rootID);
                    var db = ModelEF.GetInst();
                    var nodes = db.YunRelations.Where(p => p.RootID == nId&&p.Status!=(int)ENUM.实体状态.已删除).ToList();
                    var rootNode = db.YunRelations.FirstOrDefault(p => p.ID == nId);
                    nodes.Add(rootNode); 
                    return RES.OK(nodes);
                }
                catch (Exception ex)
                {
                    return RES.FAIL(ex.Message+"-"+ex.InnerException.Message);
                }

            }
            return RES.FAIL();
        }
        #endregion

        #region 移动一个节点
        /// <summary>
        /// 移动一个节点
        /// </summary>
        /// <param name="nodeIdStr"></param>
        /// <param name="sourceParentIDStr"></param>
        /// <param name="targetParentNodeIDStr"></param>
        /// <returns></returns>
        public RES MoveNode(string nodeIdStr, string sourceParentIDStr, string targetParentNodeIDStr)
        {
            try
            {
                if (GUID.IsGuid(nodeIdStr) && GUID.IsGuid(sourceParentIDStr) && GUID.IsGuid(targetParentNodeIDStr))
                {
                    var currentNodeID = Guid.Parse(nodeIdStr);
                    var sourceParentNodeID = Guid.Parse(sourceParentIDStr);
                    var targetParentNodeID = Guid.Parse(targetParentNodeIDStr);
                    var db = ModelEF.GetInst();
                    var currentEntity = db.YunRelations.FirstOrDefault(p => p.ID == currentNodeID);
                    if (null != currentEntity)
                    {
                        currentEntity.ParentID = targetParentNodeID;
                    }
                    db.SaveChangesAsync();
                    return RES.OK();
                }
                return RES.FAIL();
            }
            catch (Exception ex)
            {
                return RES.FAIL();
            }
        } 
        #endregion

    }
}
