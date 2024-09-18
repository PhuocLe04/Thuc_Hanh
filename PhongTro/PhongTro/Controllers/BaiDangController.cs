using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhongTro.Models;

namespace Phong_Tro.Controllers
{
    public class BaiDangController : Controller
    {
        private readonly Tkpm1Context _context;

        public BaiDangController(Tkpm1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var phongTros = _context.PhongTros.FirstOrDefault(sp => sp.MaPhongTro == id);
            if (phongTros == null)
            {
                return NotFound();
            }
            var anhPhongTroList = await _context.AnhPhongTros.Where(x => x.MaPhongTro == id).ToListAsync();
            var baidang = await _context.BaiDangs.FirstOrDefaultAsync(x => x.MaPhongTro == id);
            if (baidang == null)
            {
                return NotFound();
            }
            var chutro = await _context.ChuTros.FirstOrDefaultAsync(x => x.MaChuTro == baidang.MaChuTro);
            if (chutro == null)
            {
                return NotFound();
            }
            ViewBag.ChuTro = chutro;
            ViewBag.baidang = baidang;
            ViewBag.phongTro = phongTros;
            ViewBag.Anh = anhPhongTroList;
            return View();
        }
    }
}
