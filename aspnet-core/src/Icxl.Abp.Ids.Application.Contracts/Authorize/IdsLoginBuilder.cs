namespace Icxl.Abp.Ids.Authorize
{
    public class IdsLoginBuilder
    {
        public static object BuilberPhoneLogin(string phoneNumber, string veifyCode)
        {
            return new
            {
                grant_type = IdsLoginConst.PHONE_LOGIN_TYPE,
                scope = IdsLoginConst.PHONE_LOGIN_SCOPE,
                client_id = IdsLoginConst.PHONE_LOGIN_CLIENT_ID,
                client_secret = IdsLoginConst.PHONE_LOGIN_CLIENT_SECRET,
                phoneNumber = phoneNumber,
                veifyCode = veifyCode
            };
        }


        public static object BuilberQQLogin(string qq, IdsAuthConst.ESex sex,string name)
        {
            return new
            {
                grant_type = IdsLoginConst.QQ_LOGIN_TYPE,
                scope = IdsLoginConst.QQ_LOGIN_SCOPE,
                client_id = IdsLoginConst.QQ_LOGIN_CLIENT_ID,
                client_secret = IdsLoginConst.QQ_LOGIN_CLIENT_SECRET,
                qq = qq,
                sex = sex,
                name = name
            };
        }
    }
}