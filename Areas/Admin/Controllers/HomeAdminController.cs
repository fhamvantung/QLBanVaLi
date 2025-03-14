using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using System.Diagnostics;

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

    }
}