using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels;
using WebApp.Models.Authentication;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    QLBanVaLiContext db = new QLBanVaLiContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authentication]

    public IActionResult Index(int? page)
    {
        int pageSize = 8;  // Số lượng sản phẩm trên mỗi trang
        int pageNumber = (page == null || page < 1) ? 1 : page.Value; // Đảm bảo page >= 1

        var lstsanpham = db.TDanhMucSps
                            .AsNoTracking()
                            .OrderBy(x => x.TenSp);

        int totalProducts = lstsanpham.Count(); // Tổng số sản phẩm
        int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize); // Tính tổng số trang

        var pagedProducts = lstsanpham
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

        // Truyền thông tin phân trang vào View
        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;

        return View(pagedProducts);
    }


    // public IActionResult SanPhamTheoLoai(string maloai)
    // {
    //     List<TDanhMucSp> lstsanpham = db.TDanhMucSps.Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp).ToList();

    //     return View(lstsanpham);
    // }

    public IActionResult SanPhamTheoLoai(string maloai, int? page)
    {
        int pageSize = 8;
        // int pageNumber = page.GetValueOrDefault(1); // Nếu page là null, mặc định là 1
        // pageNumber = pageNumber < 1 ? 1 : pageNumber;
        int pageNumber = (page == null || page < 1) ? 1 : page.Value;
        var query = db.TDanhMucSps
                      .AsNoTracking()
                      .Where(x => x.MaLoai == maloai)
                      .OrderBy(x => x.TenSp);

        int totalProducts = query.Count();
        int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

        var pagedProducts = query
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

        // Truyền thông tin phân trang vào View
        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.MaLoai = maloai;
        return View(pagedProducts);
    }

    public IActionResult ChiTietSanPham(string maSp)
    {
        var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        ViewBag.anhSanPham = anhSanPham;
        return View(sanPham);
    }

    public IActionResult ProductDetail(string maSp)
    {
        var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        var homeProductDetailViewModel = new HomeProductDetailViewModel { danhMucSp = sanPham, anhSps = anhSanPham };
        return View(homeProductDetailViewModel);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
