namespace hicaphe2.Controllers
{
    public interface IDeleteDrinkVisitor
    {
        void Visit(DrinkCombo drinkCombo, string maSP);
    }
}