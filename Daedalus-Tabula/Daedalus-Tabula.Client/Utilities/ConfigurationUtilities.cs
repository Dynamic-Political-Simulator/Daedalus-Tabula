using Radzen;
using Microsoft.AspNetCore.Components;

public class ConfigurationUtilities
{
    public static void ConfigureCommonServices(IServiceCollection services)
    {
        services.AddSingleton<SpriteService>();
        services.AddScoped<UXEvents>();
        services.AddScoped<BrowserService>();
        services.AddScoped<ContextMenuService>();
        services.AddScoped<DialogService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<NotificationService>();
        services.AddAuthorizationCore();
        
    }
}

