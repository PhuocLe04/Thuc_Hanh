using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class TaiKhoan
{
    public string Email { get; set; } = null!;

    public string? MatKhau { get; set; }

    public int? MaLoaiTk { get; set; }

    public virtual ICollection<ChuTro> ChuTros { get; set; } = new List<ChuTro>();

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual LoaiTk? MaLoaiTkNavigation { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<QuaTrinhDangBai> QuaTrinhDangBais { get; set; } = new List<QuaTrinhDangBai>();
}
