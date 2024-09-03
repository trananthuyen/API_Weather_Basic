namespace UseAPI_Weather_Basic.ServiceContracts
{
    public interface IWeather
    {
        Task<Dictionary<string, object>> GetWeatherLocation(string location);
    }
}
