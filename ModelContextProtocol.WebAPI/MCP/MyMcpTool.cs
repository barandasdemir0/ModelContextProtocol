using ModelContextProtocol.Server;
using ModelContextProtocol.WebAPI.Models;
using ModelContextProtocol.WebAPI.Services;
using System.ComponentModel;

namespace ModelContextProtocol.WebAPI.MCP;

[McpServerToolType]
public static class MyMcpTool
{
    [McpServerTool,Description("Verilen şehir bilgiisne göre o şehrin sıcaklığını döndürür")]
    public static Weather GetWeather([Description("Şehir bilgisi")]  string city, WeatherServices weatherServices)
    {
        var res = weatherServices.Get(city);
        return res;
    }
}
