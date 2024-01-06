using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
/// Factory Method Pattern
/// </summary>
namespace hicaphe2.Models
{
    public abstract class DangNhapFactory<T>
    {
        public abstract ILogin<T> CreateLogin();
    }
}