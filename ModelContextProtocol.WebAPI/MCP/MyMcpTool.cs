using ModelContextProtocol.Server;
using ModelContextProtocol.WebAPI.Models;
using ModelContextProtocol.WebAPI.Services;
using System.ComponentModel;

namespace ModelContextProtocol.WebAPI.MCP;

[McpServerToolType]
public static class MyMcpTool
{
    [McpServerTool,Description("Verilen şehir bilgiisne göre o şehrin sıcaklığını döndürür")]
    public static Weather GetWeather([Description("Şehir bilgisi")]  string city, WeatherServices weatherServices,IHttpContextAccessor httpContextAccessor)
    {
        var res = weatherServices.Get(city);
        return res;
    }

    [McpServerTool, Description("Personellerin tarih bazlı satış listesini döndürür")]
    public static List<Sale> GetSales()
    {
        return SaleServices.Sales;
    }
    [McpServerTool, Description("Yapılacak Ödemelerin Son tarihlerini ve firma bilgilerini döndürür")]
    public static List<Payment> GetPayments()
    {
        return PaymentServices.Payments;
    }
}
