namespace MyFinance_Web.Domain
{
    public class PlanoConta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public PlanoContaTipo Tipo { get; set; }
    }
}
