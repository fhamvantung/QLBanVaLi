using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Table("tUser")]
public partial class TUser
{
    [Key]
    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(256)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public byte? LoaiUser { get; set; }

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<TKhachHang> TKhachHangs { get; set; } = new List<TKhachHang>();

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<TNhanVien> TNhanViens { get; set; } = new List<TNhanVien>();
}
