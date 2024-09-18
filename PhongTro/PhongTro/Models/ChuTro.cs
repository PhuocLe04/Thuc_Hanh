using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class ChuTro
{
    public string MaChuTro { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual TaiKhoan? EmailNavigation { get; set; }
}
