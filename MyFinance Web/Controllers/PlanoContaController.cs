using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFinance_Web.Domain;
using MyFinance_Web.Infrastructure;
using MyFinance_Web.Service;

namespace MyFinance_Web.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly MyFinanceDbContext _context;
        private IPlanoContaService _service;

        public PlanoContaController(IPlanoContaService service)
        {
            _service = service;
        }

        // GET: PlanoConta
        public async Task<IActionResult> Index()
        {
            return View(await _service.List());
        }

        // GET: PlanoContas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoConta = await _service.Get((int)id);
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
                await _service.Add(planoConta);
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

            var planoConta = await _service.Get((int)id);
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
                    await _service.Update(planoConta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(planoConta.Id))
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

            var planoConta = await _service.Get((int)id);
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
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
