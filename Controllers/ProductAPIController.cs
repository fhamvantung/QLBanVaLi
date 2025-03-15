using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Models.Product;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly QLBanVaLiContext _db;

        public ProductAPIController(QLBanVaLiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in _db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }

        [HttpGet("{MaLoai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            var sanPham = (from p in _db.TDanhMucSps
                           where p.MaLoai == maLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }
    }
}
