using System;
using System.Collections.Generic;

namespace Vargas
{
  public class Restaurant : IRestaurant
  {
    List<Dish> Menu;

    fillMenu leChef;

    public Restaurant()
    {
    }

    public Restaurant(fillMenu chef)
    {
      leChef = chef;
    }

    public void Open()
    {
      try
      {
        Menu = this.leChef();
        Console.WriteLine("We are open!");
      }
      catch
      {
        Console.WriteLine("Closed for the day :(");
      }
    }

    public void Welcome(Customer cus)
    {
      Console.WriteLine("Welcome " + cus.Name);
      Meal cusMeal = PlaceOrder(cus);
      Console.WriteLine(">> You had " + cusMeal.GetEnergy() + " calories and owe " + cusMeal.GetBill() + " Euros");
    }

    Meal PlaceOrder(Customer cus)
    {
      Meal meal = new Meal();
      meal.Start();
      foreach (Dish dish in Menu)
      {
        if (cus.preferences(dish))
        {
          Console.WriteLine("I'm having " + dish.name);
          meal.AddDish(dish);
        }
      }
      return meal;
    }

  }
}
