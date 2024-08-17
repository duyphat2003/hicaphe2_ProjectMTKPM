using hicaphe2.Models.vistor_pattern;

public class DrinkPriceVisitor : IDrinkVisitor
{
    public double TotalPrice { get; private set; }

    public void Visit(DrinkInfo drinkInfo)
    {
        TotalPrice += drinkInfo.Dongia;
    }
    public void Visit(DrinkCombo drinkCombo)
    {
        foreach (var drink in drinkCombo.Drinks)
        {
            drink.Accept(this);
        }
    }
}