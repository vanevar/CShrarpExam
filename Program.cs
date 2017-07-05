using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Vargas
{
  class Program
  {
    string myXML = "";//"myMenu.xml";
    public static void Main(string[] args)
    {
      Program prog1 = new Program();
      prog1.Go();
    }

    public void Go(){
      IRestaurant quickLunch = new Restaurant(new fillMenu(FastFood));
      quickLunch.Open();

      Customer Jack = new Customer("Jack", new SelectDish(Rich));
      Jack.preferences += new SelectDish(Fatty);
      quickLunch.Welcome(Jack);

      Customer Tao = new Customer("Tao", new SelectDish(Vegan));
      //Tao.preferences += new SelectDish(x => x.course == Course.DESSERT);
      quickLunch.Welcome(Tao);

      Console.ReadLine();

    }

    public List<Dish> FastFood(){
      List<Dish> menu = new List<Dish>();
      if (myXML == "")
      {
        menu.Add(new Dish("Pique Macho", Course.MAIN, 380, 15, false));
        menu.Add(new Dish("Salad", Course.STARTER, 80, 8, true));
        menu.Add(new Dish("Apple", Course.DESSERT, 12, 2, true));
        menu.Add(new Dish("Arroz con leche", Course.DESSERT, 120, 5, false));
        menu.Add(new Dish("Silpancho", Course.MAIN, 300, 16, false));
        menu.Add(new Dish("Pastel de Quinoa", Course.MAIN, 150, 12, true));
      }
      else
      {
        XmlSerializer xs = new XmlSerializer(typeof(List<Dish>));
        using (StreamReader sr = new StreamReader(myXML))
        {
          menu = xs.Deserialize(sr) as List<Dish>;
        }  
      }
        return menu;
    }

    public bool Rich(Dish dish){
      if (dish.calories >= 50)
        return true;
      return false;
    }

    public bool Fatty(Dish dish)
    {
      if (dish.calories >= 80)
        return true;
      return false;
    }

    public bool Vegan(Dish dish)
    {
      if (dish.vegan)
        return true;
      return false;
    }

  }
}
