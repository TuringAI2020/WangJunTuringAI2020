namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    public partial class YunToken
    {
        public RES Login(string loginID,string password)
        {
            return RES.OK(new YunToken { Name = "汪俊", Description = "汪俊，加油！一定成功！", ID = new Guid(MD5.ToMD5Bytes("汪俊")) });
        }
    }
}
