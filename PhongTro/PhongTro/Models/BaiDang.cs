using System;
using System.Collections.Generic;

namespace PhongTro.Models;

public partial class BaiDang
{
    public string MaBaiDang { get; set; } = null!;

    public string MaChuTro { get; set; } = null!;

    public string MaPhongTro { get; set; } = null!;

    public string? TieuDe { get; set; }

    public double? Gia { get; set; }

    public DateOnly? NgayDang { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ChuTro MaChuTroNavigation { get; set; } = null!;

    public virtual PhongTro MaPhongTroNavigation { get; set; } = null!;

    public virtual ICollection<QuaTrinhDangBai> QuaTrinhDangBais { get; set; } = new List<QuaTrinhDangBai>();
}
