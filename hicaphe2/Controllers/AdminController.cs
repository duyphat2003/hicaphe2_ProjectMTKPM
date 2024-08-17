using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hicaphe2.Models;
using PagedList;
using System.IO;
using System.Net;
using System.Data.Entity;
using hicaphe2.Models.Factory_Method_Pattern;
using hicaphe2.Models.Proxy_Pattern;
using hicaphe2.Models.Composite_Pattern;
using hicaphe2.Models.State_Pattern;
using hicaphe2.Models.Facade_Pattern;

namespace hicaphe2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");
            return View();
        }

        DangNhapFactory<ADMIN> dangNhapFactory;
        ILogin<ADMIN> admin;
        void CreateLogin()
        {
            dangNhapFactory = new DangNhapAdmin();
            admin = dangNhapFactory.CreateLogin();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            String taiKhoan = Session["Admin"] as String;
            CreateLogin();
            if (admin.DangNhap(taiKhoan))
                return Redirect("/HiCaPhe/Index");
            else
                return View();
        }
        object taikhoan;
        [HttpPost]
        public ActionResult DangNhap(ADMIN x)
        {
            CreateLogin();
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(x.UserAdmin))
                    ModelState.AddModelError(string.Empty, "User name không được để trống");
                if (string.IsNullOrEmpty(x.PassAdmin))
                    ModelState.AddModelError(string.Empty, "Password không được để trống");
                //Kiểm tra có admin này hay chưa
                //var adminDB = HiCaPheDatabase.Instance.database.ADMIN.FirstOrDefault(ad => ad.UserAdmin == x.UserAdmin && ad.PassAdmin == x.PassAdmin);
                if (!admin.DangNhap(x, ref taikhoan))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                else
                {
                    //taikhoan = adminDB;
                    Session["Admin"] = taikhoan;
                    ViewBag.ThongBao = "Đăng nhập admin thành công";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        #region Proxy Pattern
        SanPhamManagement sanPhamManagement;
        #endregion

        CompositeProduct compositeProduct;
        public ActionResult SanPham(int? page, string timkiemchuoi, double minPrice = double.MinValue, double maxPrice = double.MaxValue)
        {
            compositeProduct = new CompositeProduct();

            #region Prototype Pattern
            SanPhamX sanPhamX = HiCaPheController.sanPhamFactory.GetAdminSP();
            #endregion

            #region Composite Pattern
            List<SANPHAM> spList = sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice, out int pageSize, out int pageNum);

            foreach (var p in spList)
            {
                Product product = new Product(p.MaSP, p.TenSP, p.Kichthuoc, p.Donvitinh, p.MaLoaiSP, (decimal)p.Dongia, p.Mota, p.Hinhminhhoa, p.Soluongban);
                compositeProduct.AddProduct(product);
            }
            ViewBag.List = compositeProduct.GetList().ToList();
            return View(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice));
            #endregion

            #region Proxy Pattern
            //sanPhamManagement = new Proxy();
            //List<SANPHAM> listSP = sanPhamManagement.FilterSanPham_Name(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice, out int pageSize, out int pageNum), timkiemchuoi);


            //return View(listSP.ToPagedList(pageNum, pageSize));
            #endregion

            #region Prototype Pattern
            return View(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice));
            #endregion
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            #region Singleton
            ViewBag.MaLoaiSP = new SelectList(HiCaPheDatabase.Instance.database.LOAISP.ToList(), "MaLoaiSP", "TenLoaiSP");
            #endregion
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SANPHAM sanpham, HttpPostedFileBase Hinhminhhoa)
        {
            #region Singleton
            ViewBag.MaLoaiSP = new SelectList(HiCaPheDatabase.Instance.database.LOAISP.ToList(), "MaLoaiSP", "TenLoaiSP");
            #endregion
            if (Hinhminhhoa == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {


                    var fileName = Path.GetFileName(Hinhminhhoa.FileName);

                    //Tao duong dan toi file
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                    //Kiem tra hinh da ton tai trong he thong chua
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình đã tồn tại";

                    }
                    else
                    {
                        Hinhminhhoa.SaveAs(path);
                    }
                    //sanpham.Hinhminhhoa = fileName;
                    #region FacadePattern
                    ProductFacade productFacade = new ProductFacade(fileName, sanpham.MaSP, sanpham.TenSP, sanpham.Kichthuoc, sanpham.Donvitinh, sanpham.Dongia, sanpham.Mota, sanpham.Hinhminhhoa, sanpham.MaLoaiSP, sanpham.Soluongban);
                    productFacade.ConstructProduct(sanpham);
                    #endregion
                    #region Singleton
                    HiCaPheDatabase.Instance.database.SANPHAM.Add(sanpham);
                    HiCaPheDatabase.Instance.database.SaveChanges();
                    #endregion
                }
                return RedirectToAction("Sanpham");
            }
        }
        public ActionResult ChiTietSanPham(string id)
        {
            #region Singleton
            var sanpham = HiCaPheDatabase.Instance.database.SANPHAM.FirstOrDefault(s => s.MaSP == id);
            #endregion
            if (sanpham == null) // khong thay san pham
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        // GET: Products/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            #region Singleton
            SANPHAM product = HiCaPheDatabase.Instance.database.SANPHAM.Find(id);
            #endregion
            if (product == null)
                return HttpNotFound();
            #region Singleton
            ViewBag.MaLoaiSP = new SelectList(HiCaPheDatabase.Instance.database.LOAISP, "MaLoaiSP", "TenLoaiSP", product.MaLoaiSP);
            #endregion
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Kichthuoc,Donvitinh,Dongia,Mota,Hinhminhhoa,MaLoaiSP,Soluongban")] SANPHAM product, HttpPostedFileBase Hinhminhhoa)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Hinhminhhoa.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                Hinhminhhoa.SaveAs(path);
                product.Hinhminhhoa = fileName;
                #region Singleton



                HiCaPheDatabase.Instance.database.Entry(product).State = EntityState.Modified;
                HiCaPheDatabase.Instance.database.SaveChanges();
                #endregion
                return RedirectToAction("SANPHAM");
            }
            #region Singleton
            ViewBag.MaLoaiSP = new SelectList(HiCaPheDatabase.Instance.database.LOAISP, "MaLoaiSP", "TenLoaiSP", product.MaLoaiSP);
            #endregion
            return View(product);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            #region Singleton
            SANPHAM product = HiCaPheDatabase.Instance.database.SANPHAM.Find(id);
            #endregion
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            #region Singleton
            SANPHAM product = HiCaPheDatabase.Instance.database.SANPHAM.Find(id);
            HiCaPheDatabase.Instance.database.SANPHAM.Remove(product);
            HiCaPheDatabase.Instance.database.SaveChanges();
            #endregion
            return RedirectToAction("SANPHAM");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        HiCaPheDatabase.Instance.database.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public ActionResult QuanLyDonHang()
        {
            #region Singleton
            // Lấy danh sách đơn hàng từ cơ sở dữ liệu (hoặc bất kỳ logic nào phù hợp)
            var danhSachDonHang = HiCaPheDatabase.Instance.database.DONDATHANG.ToList();
            #endregion
            return View(danhSachDonHang);
        }
        public ActionResult ChiTietDonHang(int soDonHang)
        {
            #region Singleton
            // Lấy thông tin đơn hàng từ cơ sở dữ liệu
            var donHang = HiCaPheDatabase.Instance.database.DONDATHANG.SingleOrDefault(dh => dh.SODH == soDonHang);
            #endregion
            if (donHang == null)
            {
                return HttpNotFound();
            }

            return View(donHang);
        }
        public ActionResult XacNhanDonHang(int soDonHang)
        {
            #region Singleton
            var donHang = HiCaPheDatabase.Instance.database.DONDATHANG.SingleOrDefault(dh => dh.SODH == soDonHang);
            #endregion
            if (donHang == null)
            {
                return HttpNotFound();
            }

            // Kiểm tra xem đơn hàng đã được xác nhận chưa
            if ((bool)donHang.Dagiao)
            {
                // Nếu đã xác nhận, bạn có thể thực hiện các xử lý hoặc trả về trang thông báo tùy thuộc vào yêu cầu của bạn.
                return View(donHang);
            }

            #region State Pattern
            //Cập nhật trạng thái đơn hàng State Pattern
            if (donHang != null)
            {
                Order order = new Order(new PendingState());
                order.ApproveOrder(donHang);
                // Lưu thay đổi vào cơ sở dữ liệu
                #region Singleton
                HiCaPheDatabase.Instance.database.SaveChanges();
                #endregion
            }
            #endregion
            // Cập nhật trạng thái đơn hàng
            //donHang.Dagiao = true;
            //donHang.Ngaygiaohang = DateTime.Now;

            // Lưu thay đổi vào cơ sở dữ liệu
            #region Singleton
            HiCaPheDatabase.Instance.database.SaveChanges();
            #endregion
            // Thêm thông điệp vào TempData
            TempData["XacNhanDonHangSuccess"] = "Đơn hàng của quý khách đã được xác nhận.";
            // Chuyển hướng về trang quản lý đơn hàng hoặc trang chi tiết đơn hàng đã xác nhận
            return RedirectToAction("QuanLyDonHang");
        }
        public ActionResult HuyDonHang(int soDonHang)
        {
            #region Singleton
            var donHang = HiCaPheDatabase.Instance.database.DONDATHANG.SingleOrDefault(dh => dh.SODH == soDonHang);
            #endregion
            if (donHang == null)
            {
                return HttpNotFound();
            }

            if (donHang.Dahuy ?? false)
            {
                // Nếu đã xác nhận, bạn có thể thực hiện các xử lý hoặc trả về trang thông báo tùy thuộc vào yêu cầu của bạn.
                return View("DonHangDaHuy", donHang);
            }

            //Ap dụng State Pattern
            if (donHang != null)
            {
                Order order = new Order(new PendingState());
                order.CancelOrder(donHang);
                #region Singleton
                // Lưu thay đổi vào cơ sở dữ liệu
                HiCaPheDatabase.Instance.database.SaveChanges();
                #endregion
            }


            // Thực hiện xử lý hủy đơn hàng (cập nhật trạng thái, gửi thông báo, v.v.)
            //donHang.Dagiao = false; // Đặt lại trạng thái là chưa giao
            //donHang.Ngaygiaohang = null; // Đặt lại ngày giao hàng
            //donHang.Dahuy = true; // Đặt trạng thái đã hủy
            #region Singleton
            // Lưu thay đổi vào cơ sở dữ liệu
            HiCaPheDatabase.Instance.database.SaveChanges();
            #endregion
            // Thêm thông điệp vào TempData
            TempData["HuyDonHangSuccess"] = "Đơn hàng của quý khách đã bị từ chối.";

            // Chuyển hướng về trang quản lý đơn hàng hoặc trang chi tiết đơn hàng đã hủy
            return RedirectToAction("QuanLyDonHang");
        }


    }
}