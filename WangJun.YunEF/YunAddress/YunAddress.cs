using System;
using System.Linq;

namespace WangJun.Yun.YunAddress
{
    public class YunAddress
    {

        public RES SaveAddress(string userIdStr, string addressIdStr, string address, int status)
        {
            try
            {
                var db = ModelEF.GetInst();
                var addressId = Guid.Parse(addressIdStr);
                var proerptyName = "Address";
                var propertyId = new Guid(MD5.ToMD5Bytes(proerptyName));
                if (GUID.IsGuid(userIdStr) && GUID.IsGuid(addressIdStr) && !string.IsNullOrWhiteSpace(address))
                {

                    var oldVal = db.YunFormInsts.FirstOrDefault(p => p.ID == addressId);

                    if (null != oldVal)
                    {
                        oldVal.PropertyValueString = address;
                        oldVal.UpdateTime = DateTime.Now;
                    }
                }
                else
                {
                    var inst = new YunFormInst { ID = Guid.NewGuid(), PropertyID = propertyId, PropertyName = proerptyName, PropertyValueString = address, CreateTime = DateTime.Now };
                    db.YunFormInsts.Add(inst);
                }
                db.SaveChangesAsync();
                return RES.OK();
            }
            catch (Exception ex)
            {

                return RES.FAIL();
            }
        }

        public RES LoadAddressList(string userIdStr, string filter)
        {
            try
            {
                var db = ModelEF.GetInst(); 
                var proerptyName = "Address";
                var propertyId = new Guid(MD5.ToMD5Bytes(proerptyName)); 

                    var list = db.YunFormInsts.Where(p => p.PropertyID == propertyId).ToList();

                    return RES.OK(list);
            }
            catch (Exception ex)
            {

                return RES.FAIL();
            }
        }
    }
}
