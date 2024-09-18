using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhongTro.Models;

public partial class Tkpm1Context : DbContext
{
    public Tkpm1Context()
    {
    }

    public Tkpm1Context(DbContextOptions<Tkpm1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<ChuTro> ChuTros { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<LoaiTk> LoaiTks { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongTro> PhongTros { get; set; }

    public virtual DbSet<QuaTrinhDangBai> QuaTrinhDangBais { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TKPM1;User ID=sa;Password=123456;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => new { e.MaChuTro, e.MaPhongTro }).HasName("PK__BaiDang__DD59C9347FBE6853");

            entity.ToTable("BaiDang");

            entity.HasIndex(e => e.MaBaiDang, "UQ__BaiDang__BF5D50C440647981").IsUnique();

            entity.Property(e => e.MaChuTro).HasMaxLength(10);
            entity.Property(e => e.MaPhongTro).HasMaxLength(10);
            entity.Property(e => e.MaBaiDang).HasMaxLength(10);
            entity.Property(e => e.TieuDe).HasColumnType("text");

            entity.HasOne(d => d.MaChuTroNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.MaChuTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiDang__MaChuTr__4AB81AF0");

            entity.HasOne(d => d.MaPhongTroNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.MaPhongTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiDang__MaPhong__4BAC3F29");
        });

        modelBuilder.Entity<ChuTro>(entity =>
        {
            entity.HasKey(e => e.MaChuTro).HasName("PK__ChuTro__D1B7162AED423C2D");

            entity.ToTable("ChuTro");

            entity.Property(e => e.MaChuTro).HasMaxLength(10);
            entity.Property(e => e.Cccd)
                .HasMaxLength(10)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(20);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.ChuTros)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__ChuTro__Email__3C69FB99");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGia__AA9515BFE74AB6A9");

            entity.Property(e => e.MaDanhGia).HasMaxLength(10);
            entity.Property(e => e.MaBaiDang).HasMaxLength(10);
            entity.Property(e => e.MaKhachHang).HasMaxLength(10);
            entity.Property(e => e.NoiDung).HasColumnType("text");

            entity.HasOne(d => d.MaBaiDangNavigation).WithMany(p => p.DanhGia)
                .HasPrincipalKey(p => p.MaBaiDang)
                .HasForeignKey(d => d.MaBaiDang)
                .HasConstraintName("FK__DanhGia__MaBaiDa__52593CB8");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DanhGia__MaKhach__534D60F1");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E515D3657C");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(10);
            entity.Property(e => e.Cccd)
                .HasMaxLength(10)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(20);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__KhachHang__Email__4222D4EF");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoaiPhong).HasName("PK__LoaiPhon__230212178FEA9D71");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MaLoaiPhong).HasMaxLength(10);
            entity.Property(e => e.TenLoai).HasMaxLength(10);
        });

        modelBuilder.Entity<LoaiTk>(entity =>
        {
            entity.HasKey(e => e.MaLoaiTk).HasName("PK__LoaiTK__1224F2548C6FE498");

            entity.ToTable("LoaiTK");

            entity.Property(e => e.MaLoaiTk)
                .ValueGeneratedNever()
                .HasColumnName("MaLoaiTK");
            entity.Property(e => e.TenLoaiTk)
                .HasMaxLength(30)
                .HasColumnName("TenLoaiTK");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47837F6CB2");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.Cccd)
                .HasMaxLength(10)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(20);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__NhanVien__Email__3F466844");
        });

        modelBuilder.Entity<PhongTro>(entity =>
        {
            entity.HasKey(e => e.MaPhongTro).HasName("PK__PhongTro__CEEDF1E1CDCFC662");

            entity.ToTable("PhongTro");

            entity.Property(e => e.MaPhongTro).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.MaLoaiPhong).HasMaxLength(10);
            entity.Property(e => e.Phuong).HasMaxLength(20);
            entity.Property(e => e.Quan).HasMaxLength(20);
            entity.Property(e => e.Slnguoi).HasColumnName("SLNguoi");
            entity.Property(e => e.TienIch).HasColumnType("text");

            entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.PhongTros)
                .HasForeignKey(d => d.MaLoaiPhong)
                .HasConstraintName("FK__PhongTro__MaLoai__46E78A0C");
        });

        modelBuilder.Entity<QuaTrinhDangBai>(entity =>
        {
            entity.HasKey(e => e.MaQuaTrinhDangBai).HasName("PK__QuaTrinh__061EC20A86B4C57B");

            entity.ToTable("QuaTrinhDangBai");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaBaiDang).HasMaxLength(10);
            entity.Property(e => e.NgayThayDoi).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.TrangThai).HasMaxLength(10);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.QuaTrinhDangBais)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__QuaTrinhD__Email__4E88ABD4");

            entity.HasOne(d => d.MaBaiDangNavigation).WithMany(p => p.QuaTrinhDangBais)
                .HasPrincipalKey(p => p.MaBaiDang)
                .HasForeignKey(d => d.MaBaiDang)
                .HasConstraintName("FK__QuaTrinhD__MaBai__4F7CD00D");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__TaiKhoan__A9D105356951E23D");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaLoaiTk).HasColumnName("MaLoaiTK");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLoaiTkNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaLoaiTk)
                .HasConstraintName("FK__TaiKhoan__MaLoai__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
