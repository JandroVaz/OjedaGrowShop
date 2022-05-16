using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace OjedaGrowShop.Helper
{
    public static class JSHelper
    {
        public static MailServices mailServices { get; set; }

        public static string mailUser { get; set; } = string.Empty;
        public static string sendMailMessage { get; set; } = string.Empty;

        [JSInvokable]
        public static Task<bool> RunJS()
        {
            mailServices.SendEmailOutlook(mailUser, sendMailMessage);


            return Task.FromResult(true) ;
        }
    }
}
