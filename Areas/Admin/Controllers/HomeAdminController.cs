using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLBanVaLiContext db = new QLBanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        // public IActionResult DanhMucSanPham()
        // {
        //     var lstsanpham = db.TDanhMucSps.ToList();
        //     return View(lstsanpham);
        // }
        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            // Console.WriteLine($"Nhận request với page={page}");
            int pageSize = 10;
            int pageNumber = (page == null || page < 1) ? 1 : page.Value;

            var lstSanpham = db.TDanhMucSps
                            .AsNoTracking()
                            .OrderBy(x => x.TenSp);

            int totalProducts = lstSanpham.Count(); // Tổng số sản phẩm
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize); // Tính tổng số trang

            var pagedProducts = lstSanpham
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Truyền thông tin phân trang vào View
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedProducts);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult Create()
        {
            // Console.WriteLine("Đã vào form thêm sản phẩm mới.");
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TDanhMucSp sanPham)
        {
            // Console.WriteLine("Người dùng đã bấm nút Create.");
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
                // Console.WriteLine("Sản phẩm đã được lưu vào database.");
                return RedirectToAction("DanhMucSanPham");
            }
            // Console.WriteLine("Dữ liệu không hợp lệ, quay lại form.");
            return View(sanPham);
        }

    }
}