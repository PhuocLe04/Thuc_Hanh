using Microsoft.AspNetCore.Mvc;
using PhongTro.Models;
using System.Diagnostics;

namespace PhongTro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Tkpm1Context _context;

        public HomeController(Tkpm1Context context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var phongTroList = (from phongTro in _context.PhongTros
                                join loaiPhong in _context.LoaiPhongs on phongTro.MaLoaiPhong equals loaiPhong.MaLoaiPhong
                                join baiDang in _context.BaiDangs on phongTro.MaPhongTro equals baiDang.MaPhongTro into gj
                                from baiDang in gj.DefaultIfEmpty()
                                select new
                                {
                                    phongTro.MaPhongTro,
                                    LoaiPhong = loaiPhong.TenLoaiPhong,
                                    phongTro.DienTich,
                                    phongTro.SlnguoiToiDa,
                                    Gia = baiDang != null ? baiDang.GiaPhong : 0
                                }).ToList();
            var anhPhongTroList = (from anhPhongTro in _context.AnhPhongTros
                                   group anhPhongTro by anhPhongTro.MaPhongTro into g
                                   select g.OrderBy(x => x.MaAnh).FirstOrDefault()).ToList();

            ViewBag.PhongTroList = phongTroList;
            ViewBag.Anh = anhPhongTroList; // Add the top image URL to ViewBag
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
