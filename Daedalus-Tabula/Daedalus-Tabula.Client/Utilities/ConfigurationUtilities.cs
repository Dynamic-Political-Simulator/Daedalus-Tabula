using Radzen;

public class ConfigurationUtilities
{
    public static void ConfigureCommonServices(IServiceCollection services)
    {
        services.AddSingleton<SpriteService>();
        services.AddSingleton<UXEvents>();
        services.AddScoped<ContextMenuService>();
        services.AddScoped<DialogService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<NotificationService>();
    }
}

