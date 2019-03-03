namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    /// <summary>
    /// 云商品
    /// </summary>

    [NotMapped]
    public partial class YunCommodity : YunForm
    {
        public static YunCommodity GetInst()
        {
            return new YunCommodity();
        }

        /// <summary>
        /// 检索一个商品信息 ID,Code
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

        ///检测商品是否存在
        public RES Exsit(string keyword)
        {
            var res = this.Get(keyword);
            return res.SetAsOK(null == res.DATA);

        }

        /// 
        ///保存一个商品
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
        ///删除商品
        public RES Remove(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid);
                if (null != val)
                {
                    val.Status = (int)ENUM.EntityStatus.已删除;
                }
                db.SaveChanges();
            }
            
            return RES.New.SetAsOK();
        }


        ///下架
        public RES OffShelves(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid);
                if (null != val)
                {
                    val.ValueI01 = (int)ENUM.CommodityStatus.下架;
                }
                db.SaveChanges();
            }

            return RES.New.SetAsOK();
        }

        /// 
        ///上架
        public RES OnShelves(string keyword)
        {
            var db = ModelEF.GetInst();
            if (GUID.IsGuid(keyword))
            {
                var guid = Guid.Parse(keyword);
                var val = db.YunForms.FirstOrDefault(p => p.ID == guid );
                if (null != val)
                {
                    val.ValueI01 = (int)ENUM.CommodityStatus.上架;
                }
                db.SaveChanges();
            }

            return RES.New.SetAsOK();
        }
        ///检测关联订单信息
        public RES RefOrderCount(string keyword)
        {
            return RES.New.SetAsOK();
        }
    }
}
