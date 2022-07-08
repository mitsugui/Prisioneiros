public class ResultadoRodada
{
    public IReadOnlyList<int> Cartoes { get; }

    public IReadOnlySet<int> CartoesAbertos { get; }

    public int NumeroPrisioneiro { get; }

    public Resultado Resultado
    {
        get
        {
            return CartoesAbertos.Contains(NumeroPrisioneiro)
                ? Resultado.Ganhou
                : Resultado.Perdeu;
        }
    }

    public ResultadoRodada(int numeroPrisioneiro, IReadOnlyList<int> cartoes, IReadOnlySet<int> cartoesAbertos)
    {
        NumeroPrisioneiro = numeroPrisioneiro;
        Cartoes = cartoes;
        CartoesAbertos = cartoesAbertos;
    }
}