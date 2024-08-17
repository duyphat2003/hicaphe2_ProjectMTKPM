using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Adapter
{
    public class HiCaPheDatabaseAdapter : ISanPhamDataProvider
    {
        ISanPhamDataProvider _sanPhamAdapter;

        public HiCaPheDatabaseAdapter(ISanPhamDataProvider sanPhamAdapter)
        {
            _sanPhamAdapter = sanPhamAdapter;
        }

        public List<string> LaySanPhamMoi(int soLuong)
        {
            return _sanPhamAdapter.LaySanPhamMoi(soLuong);
        }
     
    }
}