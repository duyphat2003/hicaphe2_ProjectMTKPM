using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hicaphe2.Models
{
    /// <summary>
    /// Factory Method Pattern
    /// </summary>
    public interface ILogin<T>
    {
        //Get
        ActionResult DangNhap();
        //Post
        ActionResult DangNhap(T x);
    }
}