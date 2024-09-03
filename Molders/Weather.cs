namespace UseAPI_Weather_Basic.Molders
{
    public class Weather
    {
        public Location_Infor location_Infor { get; set; }
        public string? last_updated { get; set; }
        public double? temp_c {  get; set; }
        public double? wind_kph { get; set; }
        public int? humidity { get; set; }
        public int? cloud {  get; set; }
        public double? uv {  get; set; }

    }
}
