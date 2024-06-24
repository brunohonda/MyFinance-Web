using Microsoft.EntityFrameworkCore;
using MyFinance_Web.Domain;
using MyFinance_Web.Infrastructure;

namespace MyFinance_Web.Service
{
    public class TransacaoService : ITransacaoService
    {
        private MyFinanceDbContext _context;
        private ILogger<TransacaoService> _logger;

        public TransacaoService(
            MyFinanceDbContext context,
            ILogger<TransacaoService> logger
        ) {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Add(Transacao model)
        {
            _context.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Transacao = await _context.Transacao.FindAsync(id);
            if (Transacao != null)
            {
                _context.Transacao.Remove(Transacao);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Transacao?> Get(int id)
        {
            return await _context.Transacao
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Transacao>> List()
        {
            return await _context.Transacao.ToListAsync();
        }

        public async Task<int> Update(Transacao model)
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Transacao.Any(e => e.Id == id);
        }
    }
}
