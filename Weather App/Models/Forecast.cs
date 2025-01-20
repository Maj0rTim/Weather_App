using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_App.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string Type { get; set; }
        public int Temp { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
