namespace DemoApi.CommonModel
{



    public class CommonJsonResponse
    {
        //status 1=success,0=failed,-1=warning
        public int responseStatus { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }
        public int page { get; set; }
        public int totalRecord { get; set; }
    }
}
