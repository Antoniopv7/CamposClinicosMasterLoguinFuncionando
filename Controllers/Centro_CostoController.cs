using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class CentroCostoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroCostoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CentroCosto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centro_Costos.ToListAsync());
        }

        // POST: CentroCosto/Index (Creación de un nuevo Centro de Costos)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id_Centro_Costo,Nombre,PresupuestoAsignado,Responsable,Id_Presupuesto")] Centro_Costo centroCosto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroCosto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(await _context.Centro_Costos.ToListAsync());
        }

        // GET: CentroCosto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroCosto = await _context.Centro_Costos
                .FirstOrDefaultAsync(m => m.Id_Centro_Costo == id);
            if (centroCosto == null)
            {
                return NotFound();
            }

            return View(centroCosto);
        }

        // GET: CentroCosto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroCosto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Centro_Costo,Nombre,PresupuestoAsignado,Responsable,Id_Presupuesto")] Centro_Costo centroCosto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroCosto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroCosto);
        }

        // GET: CentroCosto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroCosto = await _context.Centro_Costos.FindAsync(id);
            if (centroCosto == null)
            {
                return NotFound();
            }
            return View(centroCosto);
        }

        // POST: CentroCosto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Centro_Costo,Nombre,PresupuestoAsignado,Responsable,Id_Presupuesto")] Centro_Costo centroCosto)
        {
            if (id != centroCosto.Id_Centro_Costo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroCosto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroCostoExists(centroCosto.Id_Centro_Costo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(centroCosto);
        }

        private bool CentroCostoExists(int id)
        {
            return _context.Centro_Costos.Any(e => e.Id_Centro_Costo == id);
        }
    }
}

