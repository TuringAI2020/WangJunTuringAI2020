using System;
using System.Linq;

namespace WangJun.Yun
{
    public class YunToDo
    {
        /// <summary>
        /// 保存一个ToDo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public  RES SaveToDo(string idStr,string categoryIdStr, string title, string content)
        {
            try
            {
                var db = ModelEF.GetInst();
                var appId = GUID.FromStringToGuid("YunToDo"); 
                if (GUID.IsGuid(idStr))
                {
                    var id = Guid.Parse(idStr);
                    var categoryId = Guid.Parse(categoryIdStr);
                    var oldInst = db.YunBaseForms.FirstOrDefault(p => p.ID == id);
                    if (null != oldInst)
                    {
                        oldInst.CategoryID = categoryId;
                        oldInst.Title = title;
                        oldInst.Content = content;
                        oldInst.UpdateTime = DateTime.Now; 
                    }
                }
                else
                {
                    var newInst = new YunBaseForm {ID = Guid.NewGuid(), CategoryID=Guid.Parse(categoryIdStr), AppID = "云备忘", Title = title, Content = content, CreateTime = DateTime.Now, UpdateTime = DateTime.Now , Status=(int)ENUM.实体状态.正常 }; 
                    db.YunBaseForms.Add(newInst);
                }
                var rInt = db.SaveChanges();
                return RES.OK(rInt);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);
            }
        }

        public RES LoadDetail(string idStr)
        {
            try
            {
                if (GUID.IsGuid(idStr))
                {
                    var id = Guid.Parse(idStr);
                    var db = ModelEF.GetInst();
                    var entity = db.YunFormInsts.FirstOrDefault(p => p.ID == id);
                    return RES.OK(entity);
                }
                return RES.FAIL();
            }
            catch (Exception ex)
            {
                return RES.FAIL();
            }
        }


        public RES LoadList(string categoryIdStr)
        {
            try
            {
                var categoryId = Guid.Parse(categoryIdStr);
                var db = ModelEF.GetInst(); 
                var list = db.YunBaseForms.Where(p=>p.CategoryID==categoryId&&p.Status==(int)ENUM.实体状态.正常).OrderByDescending(p=>p.CreateTime).ToList();
                return RES.OK(list);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);
            }
        }

        public RES RemoveToDo(string idStr)
        {
            try
            {
                var db = ModelEF.GetInst();
                var appId = GUID.FromStringToGuid("YunToDo");
                if (GUID.IsGuid(idStr))
                {
                    var id = Guid.Parse(idStr); 
                    var oldInst = db.YunBaseForms.FirstOrDefault(p => p.ID == id);
                    if (null != oldInst)
                    {
                        oldInst.Status = (int)ENUM.实体状态.已删除;
                        oldInst.UpdateTime = DateTime.Now;
                    }
                } 
                var rInt = db.SaveChanges();
                return RES.OK(rInt);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);
            }
        }

        public RES FinishToDo(string idStr)
        {
            try
            {
                var db = ModelEF.GetInst();
                var appId = GUID.FromStringToGuid("YunToDo");
                if (GUID.IsGuid(idStr))
                {
                    var id = Guid.Parse(idStr); 
                    var oldInst = db.YunBaseForms.FirstOrDefault(p => p.ID == id);
                    if (null != oldInst)
                    {
                        oldInst.Status = (int)ENUM.实体状态.已完成;
                        oldInst.UpdateTime = DateTime.Now;
                    }
                }
                var rInt = db.SaveChanges();
                return RES.OK(rInt);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);
            }

        }

    }
}
