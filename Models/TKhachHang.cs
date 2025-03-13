using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Table("tKhachHang")]
public partial class TKhachHang
{
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    public string MaKhanhHang { get; set; } = null!;

    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(100)]
    public string? TenKhachHang { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai { get; set; }

    [StringLength(150)]
    public string? DiaChi { get; set; }

    public byte? LoaiKhachHang { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AnhDaiDien { get; set; }

    [StringLength(100)]
    public string? GhiChu { get; set; }

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<THoaDonBan> THoaDonBans { get; set; } = new List<THoaDonBan>();

    [ForeignKey("Username")]
    [InverseProperty("TKhachHangs")]
    public virtual TUser? UsernameNavigation { get; set; }
}
