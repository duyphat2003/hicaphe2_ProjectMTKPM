using hicaphe2.Models.vistor_pattern;

public class DrinkInfo : IDrink
{
    public string MaSP { get; set; }
    public string TenSP { get; set; }
    public string Hinhminhhoa { get; set; }
    public string Kichthuoc { get; set; }
    public int SoLuong { get; set; }
    public double Dongia { get; set; }
    public int Loai { get; set; }

    public void Accept(IDrinkVisitor visitor)
    {
        visitor.Visit(this);
    }
}