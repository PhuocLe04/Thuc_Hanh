using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class LoaiPhong
{
    public string MaLoaiPhong { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<PhongTro> PhongTros { get; set; } = new List<PhongTro>();
}
