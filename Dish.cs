namespace Vargas
{
  public enum Course { STARTER = 0, MAIN = 1, DESSERT = 2 };

  public class Dish
  {
    string _name;

    public string name{
      set{
        if(value == null || value.ToString()== "" ){
          _name = "Plat du jour";
        }
        else{
          _name = value;
        }
      }
      get{
        return _name;
      }
    }

    Course _course;
    public Course course
    {
      set
      {
        _course = value;
      }
      get
      {
        return _course;
      }
    }

    int _calories;
    public int calories{
      set{
        _calories = value < 0 ? 0 : value;
      }
      get { return _calories; }
    }

    int _price;
    public int price
    {
      set
      {
        _price = value < 1 ? 1 : value;
      }
      get { return _price; }
    }

    bool _vegan;
    public bool vegan{
      set{ _vegan = value; }
      get { return _vegan; }
    }
    public Dish()
    {
      this.name = "";
      this.course = Course.MAIN;
      this.calories = 0;
      this.price = 0;
      this.vegan = false;
    }

    public Dish(string name, Course crs, int calories, int price, bool veg){
      this.name = name;
      this.course = crs;
      this.calories = calories;
      this.price = price;
      this.vegan = veg;
    }
  }

}
