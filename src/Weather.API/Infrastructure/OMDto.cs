using System.Text.Json;

class OMResponse
{
    public CurrentDto?  current {get; set;}
    public HourlyDto?   hourly {get; set;}

}
class CurrentDto
{
    public DateTime     time {get; set;}
    public float        temperature_2m {get; set;}
    public float        surface_pressure {get; set;}
    public float        precipitation {get; set;}
    public int          weather_code {get; set;}
}

public class HourlyDto
{
    public List<DateTime>? time {get; set;}
    public List<float>? temperature_2m {get; set;}
    public List<float>? surface_pressure {get; set;}
    public List<float>? precipitation {get; set;}
    public List<int>?   weather_code {get; set;}    
}