using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public abstract class AbstractKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AbstractKhachHang()
        {
            this.DONDATHANG = new HashSet<DONDATHANG>();
        }
        public int MaTK { get; set; }
        public string HoTenKH { get; set; }
        public string Email { get; set; }
        public string DiachiKH { get; set; }
        public string SDT { get; set; }
        public string Matkhau { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool Daduyet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANG { get; set; }
        public abstract TAIKHOANKHACHHANG MakeKhachHang();
    }
}