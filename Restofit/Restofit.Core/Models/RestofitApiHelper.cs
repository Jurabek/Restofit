using Xamarin.Forms;

namespace Restofit.Core.Models
{
    public static class RestofitApiHelper
    {
        public static string Address
        {
            get
            {
                if(Device.OS == TargetPlatform.iOS)
                {
                    return "http://192.168.127.1:8080";
                }
                else if(Device.OS == TargetPlatform.Android)
                {
                    return "http://10.71.34.1:8080";
                }
                return "http://localhost:8080";
            } 
        }        
    }
}
