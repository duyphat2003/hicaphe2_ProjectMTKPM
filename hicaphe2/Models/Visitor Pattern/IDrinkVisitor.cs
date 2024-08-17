using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.vistor_pattern
{
    public interface IDrinkVisitor
    {
        void Visit(DrinkInfo drinkInfo);
        void Visit(DrinkCombo drinkCombo);
    }
}
