using Microsoft.AspNetCore.Components;

namespace OjedaGrowShop.Helper
{
    public class AuthorizationHelper
    {
        public bool IsAdmin { get; set; } = false;

        public EventCallback<bool> EventCallback { get; set; }
    }

   
}
