using Microsoft.Extensions.Configuration;

namespace tagisApi.Lambda
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }
}