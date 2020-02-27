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
        Console.WriteLine($"Which would you like to do with your plants? (V)iew, (A)dd, (R)emove, (W)atered date, (N)eeds water, (L)ocation or (Quit)?");
        var input = Console.ReadLine().ToLower();

        //Plant Species 
        if (input == "v")
        {

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


        // else if (input == "r")
        // {
        //   Console.WriteLine($"Which plant Id would you like to remove?");
        //   var removePlant = Console.ReadLine().ToLower();

        //   var plantToDelete = db.Plants.First(plant => plant.Id == );
        //   db.Plants.Remove(plantToDelete);
        //   db.SaveChanges();
        // }


        // else if (input == "w")
        // {

        // }


        // else if (input == "n")
        // {

        // }


        // else if (input == "l")
        // {

        // }


        else if (input == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}