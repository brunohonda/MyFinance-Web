using Microsoft.EntityFrameworkCore;
using MyFinance_Web.Domain;
using MyFinance_Web.Infrastructure;

namespace MyFinance_Web.Service
{
    public class PlanoContaService : IPlanoContaService
    {
        private MyFinanceDbContext _context;
        private ILogger<PlanoContaService> _logger;

        public PlanoContaService(
            MyFinanceDbContext context,
            ILogger<PlanoContaService> logger
        ) {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Add(PlanoConta model)
        {
            _context.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var planoConta = await _context.PlanoConta.FindAsync(id);
            if (planoConta != null)
            {
                _context.PlanoConta.Remove(planoConta);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<PlanoConta?> Get(int id)
        {
            return await _context.PlanoConta
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<PlanoConta>> List()
        {
            return await _context.PlanoConta.ToListAsync();
        }

        public async Task<int> Update(PlanoConta model)
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.PlanoConta.Any(e => e.Id == id);
        }
    }
}
