using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using hicaphe2.Models;
using hicaphe2.Models.Builder_Pattern;
using hicaphe2.Models.StrategyPattern;
using hicaphe2.Models.vistor_pattern;
using Stripe;

namespace hicaphe2.Controllers
{
    public class GioHangController : Controller 
    {

        SanXuatSP sanXuatSP = new SanXuatSP(); // ---
        public List<MatHangMua> LayGioHang()
        {
            List<MatHangMua> gioHang = Session["GioHang"] as List<MatHangMua>;
            if (gioHang == null)
            {
                gioHang = new List<MatHangMua>();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }

        #region Nhật
        public ActionResult ThemSanPhamVaoGio(string MaSP)
        {
            List<MatHangMua> gioHang = LayGioHang();
            MatHangMua sanPham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (sanPham == null)
            {
                sanPham = new MatHangMua(MaSP);

                #region Visitor Pattern
                if(drinkCombo == null)
                    drinkCombo = new DrinkCombo();

                drinkCombo.AddDrink(new DrinkInfo()
                {
                    TenSP = sanPham.TenSP,
                    MaSP = sanPham.MaSP,
                    Hinhminhhoa = sanPham.Hinhminhhoa,
                    Kichthuoc = sanPham.Kichthuoc,
                    SoLuong = sanPham.SoLuong,
                    Dongia = sanPham.Dongia,
                    Loai = sanPham.Loai,
                });
                drinkVisitor = new DrinkPriceVisitor();
                drinkVisitor.Visit(drinkCombo);
                #endregion

                TaoSanPham taoSanPham = new TaoSanPham();
                switch (sanPham.Loai)
                {
                    case 1:
                    case 2:
                    case 3:
                        IBuilderSanPham drink = new Drink(sanPham.MaSP);
                        sanXuatSP.Constructor(drink, sanPham.TenSP, new Tuple<int, int, int>(0, 0, 255));
                        taoSanPham = drink.GetSanPham();
                        break;
                    case 4:
                    case 5:
                    case 6:
                        IBuilderSanPham food = new Food(sanPham.MaSP);
                        sanXuatSP.Constructor(food, sanPham.TenSP, new Tuple<int, int, int>(0, 255, 0));
                        taoSanPham = food.GetSanPham();
                        break;
                }
                gioHang.Add(taoSanPham.matHangMua());
            }
            else
            {
                sanPham.SoLuong++;
            }

            return RedirectToAction("Details", "HiCaPhe", new { id = MaSP });
        }
        #endregion

        private int TinhTongSL()
        {
            int tongSL = 0;
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang != null)
                tongSL = gioHang.Sum(sp => sp.SoLuong);
            return tongSL;
        }

        private double TinhTongTien()
        {
            double TongTien = 0;
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang != null)
                TongTien = gioHang.Sum(sp => sp.ThanhTien());
            return TongTien;
        }


        #region Nhật
        DrinkCombo drinkCombo;
        IDrinkVisitor drinkVisitor;
        public ActionResult HienThiGioHang()
        {
            List<MatHangMua> gioHang = LayGioHang();

            #region Visitor Pattern
            if (drinkCombo == null)
                drinkCombo = new DrinkCombo();

            foreach (var mathang in gioHang)
            {
                drinkCombo.AddDrink(new DrinkInfo()
                {
                    TenSP = mathang.TenSP,
                    MaSP = mathang.MaSP,
                    Hinhminhhoa = mathang.Hinhminhhoa,
                    Kichthuoc = mathang.Kichthuoc,
                    SoLuong = mathang.SoLuong,
                    Dongia = mathang.Dongia,
                    Loai = mathang.Loai,
                });
            }

            drinkVisitor = new DrinkPriceVisitor();
            drinkVisitor.Visit(drinkCombo);
            #endregion
            if (gioHang == null || gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang);
        }
        #endregion

        public ActionResult GioHangPartial()
        {
           
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }

        #region Nhật
        public ActionResult XoaMatHang(string MaSP)
        {
            List<MatHangMua> gioHang = LayGioHang();
            var sanpham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (sanpham != null)
            {
                IDeleteDrinkVisitor RemoveDrink = new DeleteDrinkVisitor();
                RemoveDrink.Visit(drinkCombo, MaSP);

                gioHang.RemoveAll(s => s.MaSP == sanpham.MaSP);
                return RedirectToAction("HienThiGioHang");
            }
            if (gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            return RedirectToAction("HienThiGioHang");
        }
        #endregion

        public ActionResult CapNhatMatHang(string MaSP, int SoLuong)
        {
            List<MatHangMua> gioHang = LayGioHang();
            var sanpham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (gioHang != null)
                sanpham.SoLuong = SoLuong;
            return RedirectToAction("HienThiGioHang");
        }

        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("DangNhap", "NguoiDung");
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang == null || gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang);
        }

        private readonly IPaymentStrategy _paymentStrategy;

        public GioHangController()
        {
            var factory = new PaymentStrategyFactory();
            _paymentStrategy = factory.CreatePaymentStrategy("OnlinePayment");
        }


        [HttpGet]
        public ActionResult CreateCheckOutSession()
        {
            // Lấy thông tin giỏ hàng và đơn hàng
            List<MatHangMua> gioHang = LayGioHang();
            TAIKHOANKHACHHANG khach = Session["TaiKhoan"] as TAIKHOANKHACHHANG;
            DONDATHANG order = new DONDATHANG();
            order.MaTK = khach.MaTK;
            order.NgayDH = DateTime.Now;
            order.Trigia = (decimal)TinhTongTien();
            order.Dagiao = false;
            order.Tennguoinhan = khach.HoTenKH;
            order.Diachinhan = khach.DiachiKH;
            order.Dienthoainhan = khach.SDT;
            order.HTThanhtoan = false;
            order.HTGiaohang = false;

            // Thực hiện thanh toán sử dụng chiến lược thanh toán (Stripe)
            _paymentStrategy.ProcessPayment(gioHang, order);

            // Lưu thông tin đơn hàng vào cơ sở dữ liệu

            foreach (var sanpham in gioHang)
            {
                CTDATHANG chitiet = new CTDATHANG();
                chitiet.SODH = order.SODH;
                chitiet.MaSP = sanpham.MaSP;
                chitiet.Soluong = sanpham.SoLuong;
                chitiet.Dongia = (decimal)sanpham.Dongia;
                HiCaPheDatabase.Instance.database.CTDATHANG.Add(chitiet);
            }

            //Xóa giỏ hàng
            Session["GioHang"] = null;

            // Chuyển hướng đến URL của trang thanh toán của Stripe
            return View();
        }

        [HttpPost]
        public ActionResult DongYDatHang(string paymentMethod)
        {
            // Lấy thông tin khách hàng và giỏ hàng
            TAIKHOANKHACHHANG khach = Session["TaiKhoan"] as TAIKHOANKHACHHANG;
            List<MatHangMua> gioHang = LayGioHang();

            DONDATHANG order = new DONDATHANG();
            order.MaTK = khach.MaTK;
            order.NgayDH = DateTime.Now;
            order.Trigia = (decimal)TinhTongTien();
            order.Dagiao = false;
            order.Tennguoinhan = khach.HoTenKH;
            order.Diachinhan = khach.DiachiKH;
            order.Dienthoainhan = khach.SDT;
            order.HTThanhtoan = false;
            order.HTGiaohang = false;

            IPaymentStrategy paymentStrategy;


            if (paymentMethod == "OnlinePayment")
            {
                paymentStrategy = new ThanhToanOnline();
                paymentStrategy.ProcessPayment(gioHang, order);
                return new HttpStatusCodeResult(303);

            }
            else
            {
                paymentStrategy = new ThanhToanTienMat();
                paymentStrategy.ProcessPayment(gioHang, order);
                return RedirectToAction("HoanThanhDonDathang", "GioHang");
            }

        }

        public ActionResult HoanThanhDonDatHang()
        {
            // Kiểm tra xem người dùng đã chọn thanh toán online hay không
            if (Session["PhuongThucThanhToan"] != null && Session["PhuongThucThanhToan"].ToString() == "OnlinePayment")
            {
                var factory = new PaymentStrategyFactory();
                IPaymentStrategy thanhToanOnline = factory.CreatePaymentStrategy("OnlinePayment");

                // Thực hiện thanh toán online chỉ khi người dùng chọn thanh toán online
                List<MatHangMua> gioHang = LayGioHang();
                double tongTien = TinhTongTien(); // Tính tổng tiền đơn hàng

                TAIKHOANKHACHHANG khach = Session["TaiKhoan"] as TAIKHOANKHACHHANG;
                DONDATHANG order = new DONDATHANG();
                order.MaTK = khach.MaTK;
                order.NgayDH = DateTime.Now;
                order.Trigia = (decimal)TinhTongTien();
                order.Dagiao = false;
                order.Tennguoinhan = khach.HoTenKH;
                order.Diachinhan = khach.DiachiKH;
                order.Dienthoainhan = khach.SDT;
                order.HTThanhtoan = false;
                order.HTGiaohang = false;

                foreach (var sanpham in gioHang)
                {
                    CTDATHANG chitiet = new CTDATHANG();
                    chitiet.SODH = order.SODH;
                    chitiet.MaSP = sanpham.MaSP;
                    chitiet.Soluong = sanpham.SoLuong;
                    chitiet.Dongia = (decimal)sanpham.Dongia;
                    HiCaPheDatabase.Instance.database.CTDATHANG.Add(chitiet);
                }

                HiCaPheDatabase.Instance.database.DONDATHANG.Add(order);
                HiCaPheDatabase.Instance.database.SaveChanges();

                // Chuyển hướng đến phương thức thanh toán online
                thanhToanOnline.ProcessPayment(gioHang, order);
                return new HttpStatusCodeResult(303);
            }

            Session["GioHang"] = null;
            // Nếu người dùng chọn thanh toán khác, hiển thị trang hoàn thành đơn đặt hàng
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }       
    }
}