namespace Icxl.Abp.Ids.Authorize
{
    public class QQLoginDto
    {
        public string headImageUrl { get; set; }
        public int sex { get; set; }
        public string name { get; set; }
        public IdsConnectTokenDto tokenDto { get; set; }
    }
}