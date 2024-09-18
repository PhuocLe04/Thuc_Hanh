using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class DanhGium
{
    public string MaDanhGia { get; set; } = null!;

    public string? MaBaiDang { get; set; }

    public string? MaKhachHang { get; set; }

    public int? DiemDanhGia { get; set; }

    public string? NoiDung { get; set; }

    public virtual BaiDang? MaBaiDangNavigation { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
