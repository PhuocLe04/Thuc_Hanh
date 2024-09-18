using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual TaiKhoan? EmailNavigation { get; set; }
}
