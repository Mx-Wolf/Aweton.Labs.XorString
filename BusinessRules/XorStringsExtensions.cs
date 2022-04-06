using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aweton.Labs.XorString.BusinessRules;

public static class XorStringsExtensions
{
  public static IServiceCollection AddXorStrings(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<XorStringAlphabet>(configuration.GetSection("Alphabet"));
    services.Configure<XorStringInput>((v) => v.LicenseKey = configuration.GetSection("MiceLicenseKey").Value);
    services.Configure<SerializerSettings>(configuration.GetSection("Encoding"));
    services.AddSingleton<IXorSerializer, XorSerializer>();
    services.AddSingleton<IProcessArrays, ProcessArrays>();
    services.AddTransient<IXorStrings, XorStrings>();
    return services;
  }
}