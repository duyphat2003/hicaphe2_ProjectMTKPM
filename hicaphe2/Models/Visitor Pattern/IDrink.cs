using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.vistor_pattern
{
    public interface IDrink
    {
        void Accept(IDrinkVisitor visitor);
    }
}
