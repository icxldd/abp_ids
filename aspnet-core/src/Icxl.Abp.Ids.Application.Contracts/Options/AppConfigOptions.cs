namespace Icxl.Abp.Ids.Options
{
    public class AuthServer
    {
        public string Authority { get; set; }
    }

    public class AppConfigOptions
    {
        public AuthServer AuthServer { get; set; }
    }
}