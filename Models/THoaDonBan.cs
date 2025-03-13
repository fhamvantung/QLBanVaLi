using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Table("tHoaDonBan")]
public partial class THoaDonBan
{
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    public string MaHoaDon { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? NgayHoaDon { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? MaKhachHang { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? MaNhanVien { get; set; }

    [Column("TongTienHD", TypeName = "money")]
    public decimal? TongTienHd { get; set; }

    [Column("GiamGiaHD")]
    public double? GiamGiaHd { get; set; }

    public byte? PhuongThucThanhToan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MaSoThue { get; set; }

    [StringLength(250)]
    public string? ThongTinThue { get; set; }

    [StringLength(100)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaKhachHang")]
    [InverseProperty("THoaDonBans")]
    public virtual TKhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("THoaDonBans")]
    public virtual TNhanVien? MaNhanVienNavigation { get; set; }

    [InverseProperty("MaHoaDonNavigation")]
    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; } = new List<TChiTietHdb>();
}
