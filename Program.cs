using System;
using System.Linq;

namespace plantapp
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new plantappContext();

      Console.WriteLine("Welcome to Plant App");
      var newPlant = new Plant();
      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine($"Which would you like to do with your plants? (V)iew, (A)dd, (R)emove, (W)atered date, (N)eeds water, (L)ocation or (Q)uit?");
        var input = Console.ReadLine().ToLower();

        //Plant Species 
        if (input == "v")
        {
          var viewCurrentPlants = db.Plants.OrderBy(p => p.LocatedPlant == "");
          foreach (var plant in viewCurrentPlants)
          {
            Console.WriteLine($" Your {plant.Species} is planted at/in {plant.LocatedPlant}.");
          }
        }


        else if (input == "a")
        {
          Console.WriteLine($"What species of plant do you want to add?");
          newPlant.Species = Console.ReadLine().ToLower();

          Console.WriteLine($"Where did you plant it?");
          newPlant.LocatedPlant = Console.ReadLine().ToLower();

          //How Much Light Needed
          Console.WriteLine($"How much light does it need?");
          newPlant.LightNeeded = Console.ReadLine().ToLower();

          //How Much Water Needed
          Console.WriteLine($"How often does it need to be watered?");
          newPlant.WaterNeeded = Console.ReadLine().ToLower();

          db.Plants.Add(newPlant);
          db.SaveChanges();
        }


        else if (input == "r")
        {
          Console.WriteLine($"Which plant Id would you like to remove?");
          var removePlant = int.Parse(Console.ReadLine());
          var plantToRemove = db.Plants.FirstOrDefault(plant => plant.Id == removePlant);
          db.Plants.Remove(plantToRemove);
          db.SaveChanges();
        }


        else if (input == "w")
        {
          Console.WriteLine("Which plant ID would you like to water?");

          var plantWater = int.Parse(Console.ReadLine());
          var plantToWater = db.Plants.FirstOrDefault(plant => plant.Id == plantWater);
          plantToWater.LastWaterDate = DateTime.Now;
          db.SaveChanges();
        }


        else if (input == "n")
        {
          var plantsNeedWater = db.Plants.OrderBy(p => p.LastWaterDate);
          foreach (var plant in plantsNeedWater)
          {
            Console.WriteLine($" Your {plant.Species} wasn't watered today.");
          }
        }


        else if (input == "l")
        {
          Console.WriteLine("From which location would you like to see your list of plants?");
          var location = Console.ReadLine().ToLower();

          var plantLocation = db.Plants.Where(p => p.LocatedPlant == location);
          foreach (var plant in plantLocation)
          {
            Console.WriteLine($" Your {plant.Species} is planted in/at {plant.LocatedPlant}.");
          }
        }

        else if (input == "q")
        {
          isRunning = false;
        }
      }
    }
  }
}