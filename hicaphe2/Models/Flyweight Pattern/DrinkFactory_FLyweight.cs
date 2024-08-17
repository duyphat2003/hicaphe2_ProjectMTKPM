using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Flyweight_Pattern
{
    public class DrinkFactory_FLyweight
    {
        Dictionary<int, IDrink_Flyweight> drinks = new Dictionary<int, IDrink_Flyweight>();

        public IDrink_Flyweight GetDrinkFromDrinkFactory(int loaiSP)
        {
            IDrink_Flyweight drinkCategory = null;
            if(drinks.ContainsKey(loaiSP))
            {
                drinkCategory = drinks[loaiSP];
            }
            else
            {
                switch(loaiSP)
                {
                    case 1:
                        drinkCategory = new Coffee_Flyweight();
                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:

                        break;

                    case 6:

                        break;
                }
            }
            return drinkCategory;
        }
    }
}