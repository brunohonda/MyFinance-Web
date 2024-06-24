using MyFinance_Web.Domain;
using MyFinance_Web.Models;

namespace MyFinance_Web.Service
{
    public interface ITransacaoService
    {
        Task<List<Transacao>> List();
        Task<Transacao?> Get(int id);
        Task<int> Add(Transacao model);
        Task<int> Update(Transacao model);
        Task<int> Delete(int id);
        bool Exists(int id);
    }
}
