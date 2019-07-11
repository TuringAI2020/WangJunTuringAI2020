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
        public  RES SaveToDo(string idStr, string title, string content)
        {
            try
            {
                var db = ModelEF.GetInst();
                var titleId = GUID.FromStringToGuid("Title");
                var contentId = GUID.FromStringToGuid("Content");
                YunFormInst titleInst = null;
                YunFormInst contentInst = null;
                if (GUID.IsGuid(idStr))
                {
                    var id = Guid.Parse(idStr);
                    var oldInst = db.YunFormInsts.Where(p => p.ID == id);
                    if (null != oldInst)
                    {

                        titleInst = oldInst.FirstOrDefault(p => p.PropertyID == titleId);
                        titleInst.PropertyValueString = title;
                        titleInst.UpdateTime = DateTime.Now;

                        contentInst = oldInst.FirstOrDefault(p => p.PropertyID == contentId);
                        contentInst.PropertyValueString = title;
                        contentInst.UpdateTime = DateTime.Now;
                    }
                }
                else
                {
                    titleInst = new YunFormInst {ID=  Guid.NewGuid(), CreateTime = DateTime.Now, PropertyID = titleId, PropertyValueString = title };

                    contentInst = new YunFormInst { ID = Guid.NewGuid(), CreateTime = DateTime.Now, PropertyID = contentId, PropertyValueString = content };
                    db.YunFormInsts.Add(titleInst);
                    db.YunFormInsts.Add(contentInst);
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
