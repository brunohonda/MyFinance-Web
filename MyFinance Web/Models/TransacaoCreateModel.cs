using Microsoft.AspNetCore.Mvc.Rendering;
using MyFinance_Web.Domain;

namespace MyFinance_Web.Models
{
    public class TransacaoCreateModel: Transacao
    {
        public IEnumerable<SelectListItem>? planoContas { get; set; }
    }
}
