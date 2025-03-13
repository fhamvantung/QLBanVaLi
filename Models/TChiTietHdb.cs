using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[PrimaryKey("MaHoaDon", "MaChiTietSp")]
[Table("tChiTietHDB")]
public partial class TChiTietHdb
{
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    public string MaHoaDon { get; set; } = null!;

    [Key]
    [Column("MaChiTietSP")]
    [StringLength(25)]
    [Unicode(false)]
    public string MaChiTietSp { get; set; } = null!;

    public int? SoLuongBan { get; set; }

    [Column(TypeName = "money")]
    public decimal? DonGiaBan { get; set; }

    public double? GiamGia { get; set; }

    [StringLength(100)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaChiTietSp")]
    [InverseProperty("TChiTietHdbs")]
    public virtual TChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;

    [ForeignKey("MaHoaDon")]
    [InverseProperty("TChiTietHdbs")]
    public virtual THoaDonBan MaHoaDonNavigation { get; set; } = null!;
}
