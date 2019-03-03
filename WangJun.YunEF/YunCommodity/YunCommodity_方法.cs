namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    /// <summary>
    /// ����Ʒ
    /// </summary>

    [NotMapped]
    public partial class YunCommodity : YunForm
    {
        public static YunCommodity GetInst()
        {
            return new YunCommodity();
        }

        /// <summary>
        /// ����һ����Ʒ��Ϣ ID,Code
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RES Get(string keyword)
        {
            if (GUID.IsGuid(keyword))
            {
                var db = ModelEF.GetInst();
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid);
                var inst = ModelEF.GetInst().YunForms.FirstOrDefault(p => p.ID == Guid.Parse(keyword));
                return RES.New.SetAsOK(inst);
            }
            return RES.New.SetAsFail();
        }

        ///�����Ʒ�Ƿ����
        public RES Exsit(string keyword)
        {
            var res = this.Get(keyword);
            return res.SetAsOK(null == res.DATA);

        }

        /// 
        ///����һ����Ʒ
        public RES Save(YunCommodity newData)
        {
            var newVal = JSON.ToObject<YunForm>(JSON.ToJson(newData));
            var db = ModelEF.GetInst() ;
            var oldVal = db.YunForms.FirstOrDefault(p => p.ID == newVal.ID);
            if (null == oldVal)
            {
                newVal.InitialDateTime();
                var inst = db.YunForms.Add(newVal);
                db.SaveChanges();
                return RES.New.SetAsOK(newVal);
            }
            else
            {

                var properties = newVal.GetType().GetProperties().ToList();
                properties.ForEach(p =>
                {
                    var targetProperty = oldVal.GetType().GetProperty(p.Name);
                    if (null != targetProperty && targetProperty.CanWrite)
                    {
                        targetProperty.SetValue(oldVal, p.GetValue(newVal));
                    }
                });
                db.SaveChanges();
                return RES.New.SetAsOK(oldVal);
            }
             
        }
        ///ɾ����Ʒ
        public RES Remove(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid);
                if (null != val)
                {
                    val.Status = (int)ENUM.EntityStatus.��ɾ��;
                }
                db.SaveChanges();
            }
            
            return RES.New.SetAsOK();
        }


        ///�¼�
        public RES OffShelves(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid);
                if (null != val)
                {
                    val.ValueI01 = (int)ENUM.CommodityStatus.�¼�;
                }
                db.SaveChanges();
            }

            return RES.New.SetAsOK();
        }

        /// 
        ///�ϼ�
        public RES OnShelves(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid );
                if (null != val)
                {
                    val.ValueI01 = (int)ENUM.CommodityStatus.�ϼ�;
                }
                db.SaveChanges();
            }

            return RES.New.SetAsOK();
        }
        ///������������Ϣ
        public RES RefOrderCount(string keyword)
        {
            return RES.New.SetAsOK();
        }
    }
}
