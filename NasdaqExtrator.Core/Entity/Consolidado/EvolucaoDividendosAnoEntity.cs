namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class EvolucaoDividendosAnoEntity
    {
        public EvolucaoDividendosAnoEntity(int ano, decimal valorMedioDividendo)
        {
            Ano = ano;
            ValorMedioDividendo = valorMedioDividendo;
        }

        public int Ano { get; set; }
        public decimal ValorMedioDividendo { get; set; }
    }
}
