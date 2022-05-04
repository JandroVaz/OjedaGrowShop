using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace OjedaGrowShop.Helper
{
    public static class MatToastHelper
    {
        
        public static IMatToaster Toaster { get; set; }
        public static void Show(MatToastType type, string message, string title, string icon = "", bool showCloseButton = true, bool showProgressBar = true, int maximumOpacity = 100, int showTransitionDuration = 500, int visibleStateDuration = 5000, int hideTransitionDuration = 500, bool requireInteraction = false)
        {
            Toaster.Add(message, type, title, icon, config =>
            {
                config.ShowCloseButton = showCloseButton;
                config.ShowProgressBar = showProgressBar;
                config.MaximumOpacity = maximumOpacity;

                config.ShowTransitionDuration = showTransitionDuration;
                config.VisibleStateDuration = visibleStateDuration;
                config.HideTransitionDuration = hideTransitionDuration;

                config.RequireInteraction = requireInteraction;

            });
        }
    }
}
