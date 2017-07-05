using System;
namespace Vargas
{
  public delegate bool SelectDish(Dish dish);

  public class Customer
  {
    string _name;
    public string Name
    {
      set
      {
        if (value == null || value.ToString() == "")
          _name = "John Doe";
        else
          _name = value;
      }
      get { return _name; }
    }

    public SelectDish preferences;

    public Customer()
    {
      Name = "";
    }

    public Customer(string name)
    {
      Name = name;
    }

    public Customer(string name, SelectDish pref)
    {
      Name = name;
      preferences = pref;
    }
  }
}
