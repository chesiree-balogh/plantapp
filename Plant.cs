using System;

namespace plantapp
{
  public class Plant
  {
    public int Id { get; set; }
    public string Species { get; set; }
    public string LocatedPlant { get; set; }
    public DateTime PlantDate { get; set; } = DateTime.Now;
    public DateTime LastWaterDate { get; set; } = DateTime.Now;
    public string LightNeeded { get; set; }
    public string WaterNeeded { get; set; }
  }
}