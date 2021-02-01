namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class StockEvolucaoAnoEntity
    {
        public StockEvolucaoAnoEntity(int ano, decimal porcentagem)
        {
            Ano = ano;
            Porcentagem = porcentagem;
        }

        public int Ano { get; set; }
        public decimal Porcentagem { get; set; }
    }
}
