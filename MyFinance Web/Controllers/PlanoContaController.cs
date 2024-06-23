using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFinance_Web.Domain;
using MyFinance_Web.Infrastructure;

namespace MyFinance_Web.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly MyFinanceDbContext _context;

        public PlanoContaController(MyFinanceDbContext context)
        {
            _context = context;
        }

        // GET: PlanoConta
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanoConta.ToListAsync());
        }

        // GET: PlanoContas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoConta = await _context.PlanoConta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planoConta == null)
            {
                return NotFound();
            }

            return View(planoConta);
        }

        // GET: PlanoContas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoContas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Tipo")] PlanoConta planoConta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoConta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoConta);
        }

        // GET: PlanoContas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoConta = await _context.PlanoConta.FindAsync(id);
            if (planoConta == null)
            {
                return NotFound();
            }
            return View(planoConta);
        }

        // POST: PlanoContas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Tipo")] PlanoConta planoConta)
        {
            if (id != planoConta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoConta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoContaExists(planoConta.Id))
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
            return View(planoConta);
        }

        // GET: PlanoContas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoConta = await _context.PlanoConta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planoConta == null)
            {
                return NotFound();
            }

            return View(planoConta);
        }

        // POST: PlanoContas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoConta = await _context.PlanoConta.FindAsync(id);
            if (planoConta != null)
            {
                _context.PlanoConta.Remove(planoConta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoContaExists(int id)
        {
            return _context.PlanoConta.Any(e => e.Id == id);
        }
    }
}
