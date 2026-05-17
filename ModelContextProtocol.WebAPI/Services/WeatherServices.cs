using ModelContextProtocol.WebAPI.Models;

namespace ModelContextProtocol.WebAPI.Services;

public sealed class WeatherServices
{
    public static List<Weather> Weathers { get; set; } = new()
    {
        new()
        {
            City = "Ankara",
            Temp = 6
        },
        new()
        {
            City = "Antalya",
            Temp = 7
        },
        new()
        {
            City = "İstanbul",
            Temp = 34
        },
    };

    public Weather Get(string city)
    {
        var weather = Weathers.FirstOrDefault(x => x.City == city);
        if (weather == null)
        {
            throw new ArgumentNullException(nameof(weather));
           
        }
        return weather;
    }
}
