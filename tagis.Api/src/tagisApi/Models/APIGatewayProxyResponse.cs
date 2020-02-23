using Newtonsoft.Json;

namespace tagisApi.Models
{
    public class TypedAPIGatewayProxyResponse<T> : Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public T RawBody { get; }
        
        public TypedAPIGatewayProxyResponse(int SpecifiedStatusCode, T TypedBody)
        {
            StatusCode = SpecifiedStatusCode;
            RawBody = TypedBody;
            Body = JsonConvert.SerializeObject(TypedBody);
        }
    }
}