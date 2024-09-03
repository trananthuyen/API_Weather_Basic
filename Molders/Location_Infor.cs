namespace UseAPI_Weather_Basic.Molders
{
    public class Location_Infor
    {
        public string? nameCity { get; set; }
        public string?  region { get; set; }
        public string? country { get; set; }
        public double? latitude { get; set; } // vi do
        public double? longitude { get; set; } // kinh do
        public string? timeZone { get; set; }
        public string? localTime { get; set; }
    }
}
