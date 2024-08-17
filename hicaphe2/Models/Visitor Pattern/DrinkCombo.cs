using hicaphe2.Models.Builder_Pattern;
using hicaphe2.Models.vistor_pattern;
using System.Collections.Generic;

public class DrinkCombo : IDrink
{
    public List<IDrink> Drinks { get; set; }

    public DrinkCombo()
    {
        Drinks = new List<IDrink>();
    }

    public void AddDrink(IDrink drink)
    {
        Drinks.Add(drink);    
    }

    public void RemoveDrink(IDrink drink)
    {
        Drinks.Remove(drink);
    }

    public void Accept(IDrinkVisitor visitor)
    {
        visitor.Visit(this);
    }
}