namespace MyFinance_Web.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public string? Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId{ get; set; }
        private PlanoConta PlanoConta { get; set; }
    }
}
