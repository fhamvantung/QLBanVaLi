using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Table("tNhanVien")]
public partial class TNhanVien
{
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    public string MaNhanVien { get; set; } = null!;

    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(100)]
    public string? TenNhanVien { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai1 { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai2 { get; set; }

    [StringLength(150)]
    public string? DiaChi { get; set; }

    [StringLength(100)]
    public string? ChucVu { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AnhDaiDien { get; set; }

    [StringLength(100)]
    public string? GhiChu { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<THoaDonBan> THoaDonBans { get; set; } = new List<THoaDonBan>();

    [ForeignKey("Username")]
    [InverseProperty("TNhanViens")]
    public virtual TUser? UsernameNavigation { get; set; }
}
