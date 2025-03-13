using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public partial class QLBanVaLiContext : DbContext
{
    public QLBanVaLiContext()
    {
    }

    public QLBanVaLiContext(DbContextOptions<QLBanVaLiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THangSx> THangSxes { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiDt> TLoaiDts { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IG8HG6C\\SQLEXPRESS;Initial Catalog=QLBanVaLi;User ID=sa;Password=Kocanmk0;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity.Property(e => e.MaChiTietSp).IsFixedLength();
            entity.Property(e => e.TenFileAnh).IsFixedLength();

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TAnhChiTietSps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.Property(e => e.MaSp).IsFixedLength();
            entity.Property(e => e.TenFileAnh).IsFixedLength();

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tDanhMucSP");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.Property(e => e.MaChatLieu).IsFixedLength();
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.Property(e => e.MaHoaDon).IsFixedLength();
            entity.Property(e => e.MaChiTietSp).IsFixedLength();

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tChiTietSanPham");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.Property(e => e.MaChiTietSp).IsFixedLength();
            entity.Property(e => e.AnhDaiDien).IsFixedLength();
            entity.Property(e => e.MaKichThuoc).IsFixedLength();
            entity.Property(e => e.MaMauSac).IsFixedLength();
            entity.Property(e => e.MaSp).IsFixedLength();
            entity.Property(e => e.Video).IsFixedLength();

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams).HasConstraintName("FK_tChiTietSanPham_tKichThuoc");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams).HasConstraintName("FK_tChiTietSanPham_tMauSac");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams).HasConstraintName("FK_tChiTietSanPham_tDanhMucSP");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.Property(e => e.MaSp).IsFixedLength();
            entity.Property(e => e.AnhDaiDien).IsFixedLength();
            entity.Property(e => e.MaChatLieu).IsFixedLength();
            entity.Property(e => e.MaDacTinh).IsFixedLength();
            entity.Property(e => e.MaDt).IsFixedLength();
            entity.Property(e => e.MaHangSx).IsFixedLength();
            entity.Property(e => e.MaLoai).IsFixedLength();
            entity.Property(e => e.MaNuocSx).IsFixedLength();
            entity.Property(e => e.Website).IsFixedLength();

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TDanhMucSps).HasConstraintName("FK_tDanhMucSP_tChatLieu");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.TDanhMucSps).HasConstraintName("FK_tDanhMucSP_tLoaiDT");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.TDanhMucSps).HasConstraintName("FK_tDanhMucSP_tHangSX");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps).HasConstraintName("FK_tDanhMucSP_tLoaiSP");

            entity.HasOne(d => d.MaNuocSxNavigation).WithMany(p => p.TDanhMucSps).HasConstraintName("FK_tDanhMucSP_tQuocGia");
        });

        modelBuilder.Entity<THangSx>(entity =>
        {
            entity.Property(e => e.MaHangSx).IsFixedLength();
            entity.Property(e => e.MaNuocThuongHieu).IsFixedLength();
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.Property(e => e.MaHoaDon).IsFixedLength();
            entity.Property(e => e.MaKhachHang).IsFixedLength();
            entity.Property(e => e.MaNhanVien).IsFixedLength();
            entity.Property(e => e.MaSoThue).IsFixedLength();

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans).HasConstraintName("FK_tHoaDonBan_tKhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans).HasConstraintName("FK_tHoaDonBan_tNhanVien");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.Property(e => e.MaKhanhHang).IsFixedLength();
            entity.Property(e => e.AnhDaiDien).IsFixedLength();
            entity.Property(e => e.SoDienThoai).IsFixedLength();
            entity.Property(e => e.Username).IsFixedLength();

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs).HasConstraintName("FK_tKhachHang_tUser");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.Property(e => e.MaKichThuoc).IsFixedLength();
            entity.Property(e => e.KichThuoc).IsFixedLength();
        });

        modelBuilder.Entity<TLoaiDt>(entity =>
        {
            entity.Property(e => e.MaDt).IsFixedLength();
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.Property(e => e.MaLoai).IsFixedLength();
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.Property(e => e.MaMauSac).IsFixedLength();
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.Property(e => e.MaNhanVien).IsFixedLength();
            entity.Property(e => e.AnhDaiDien).IsFixedLength();
            entity.Property(e => e.SoDienThoai1).IsFixedLength();
            entity.Property(e => e.SoDienThoai2).IsFixedLength();
            entity.Property(e => e.Username).IsFixedLength();

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens).HasConstraintName("FK_tNhanVien_tUser");
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.Property(e => e.MaNuoc).IsFixedLength();
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.Property(e => e.Username).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
