using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFinance_Web.Domain;
using MyFinance_Web.Infrastructure;
using MyFinance_Web.Models;
using MyFinance_Web.Service;

namespace MyFinance_Web.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly MyFinanceDbContext _context;
        private readonly ITransacaoService _service;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(
            MyFinanceDbContext context,
            ITransacaoService service,
            IPlanoContaService planoContaService
        )
        {
            _context = context;
            _service = service;
            _planoContaService = planoContaService;
        }

        // GET: Transacao
        public async Task<IActionResult> Index()
        {
            return View(await _service.List());
        }

        // GET: Transacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _service.Get((int)id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacao/Create
        public async Task<IActionResult> Create()
        {
            var model = new TransacaoCreateModel();
            model.Data = DateTime.Now;
            model.planoContas = new SelectList(await _planoContaService.List(), "Id", "Descricao");
            return View(model);
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Historico,Data,Valor,PlanoContaId")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(transacao);
                return RedirectToAction(nameof(Index));
            }
            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _service.Get((int)id);
            if (transacao == null)
            {
                return NotFound();
            }

            TransacaoCreateModel model = new TransacaoCreateModel()
            {
                Id = transacao.Id,
                Data = transacao.Data,
                Historico = transacao.Historico,
                PlanoContaId = transacao.PlanoContaId,
                Valor = transacao.Valor,
                planoContas = new SelectList(await _planoContaService.List(), "Id", "Descricao")
            };

            return View(model);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Historico,Data,Valor,PlanoContaId")] Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(transacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(transacao.Id))
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
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _service.Get((int)id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }
    }
}
