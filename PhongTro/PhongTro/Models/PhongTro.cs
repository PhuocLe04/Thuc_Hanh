using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class PhongTro
{
    public string MaPhongTro { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Phuong { get; set; }

    public string? Quan { get; set; }

    public double? DienTich { get; set; }

    public string? TienIch { get; set; }

    public int? Slnguoi { get; set; }

    public string? MaLoaiPhong { get; set; }

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual LoaiPhong? MaLoaiPhongNavigation { get; set; }
}
