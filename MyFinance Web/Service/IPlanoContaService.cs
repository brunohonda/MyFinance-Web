using MyFinance_Web.Domain;

namespace MyFinance_Web.Service
{
    public interface IPlanoContaService
    {
        Task<List<PlanoConta>> List();
        Task<PlanoConta?> Get(int id);
        Task<int> Add(PlanoConta model);
        Task<int> Update(PlanoConta model);
        Task<int> Delete(int id);
        bool Exists(int id);
    }
}
