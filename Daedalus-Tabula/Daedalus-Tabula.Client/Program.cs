using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
ConfigurationUtilities.ConfigureCommonServices(builder.Services);

await builder.Build().RunAsync();


