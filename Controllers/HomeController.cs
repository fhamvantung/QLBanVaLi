using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    QLBanVaLiContext db = new QLBanVaLiContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

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
