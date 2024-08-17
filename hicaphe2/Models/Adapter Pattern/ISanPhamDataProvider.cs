using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Adapter
{
    /// <summary>
    /// Apdater Pattern
    /// </summary>
    public interface ISanPhamDataProvider
    {
        List<string> LaySanPhamMoi(int soLuong);
    }
}