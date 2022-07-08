
// Teste da solução do vídeo https://www.youtube.com/watch?v=iSNsgj1OCLA&t=7s

Console.WriteLine("Algoritmo:");
Console.WriteLine("1. Aleatório");
Console.WriteLine("2. Loop");
var algoritmo = int.TryParse(Console.ReadLine(), out var opcao) && opcao == 2
    ? opcao
    : 1;

Console.WriteLine("Quantidade prisioneiros:");
var qtdPrisioneiros = int.TryParse(Console.ReadLine(), out var qtdPris) && qtdPris > 0
    ? qtdPris
    : 100;

var qtdColunas = Convert.ToInt32(
    Math.Floor(
        Math.Sqrt(qtdPrisioneiros)));
while(qtdPrisioneiros % qtdColunas != 0)
{
    qtdColunas++;
}

var qtdCartoesAbrir = qtdPrisioneiros >= 2 
    ? qtdPrisioneiros / 2 
    : 1;

Console.WriteLine("Quantidade rodadas:");
var qtdRodadas = int.TryParse(Console.ReadLine(), out var qtd) && qtd > 0
    ? qtd
    : 100000;

Console.WriteLine("Imprimir (s/n)?");
var key = Console.ReadLine() ?? "";
var imprimir = key.StartsWith("s", StringComparison.OrdinalIgnoreCase);

var random = new Random();

var qtdVitorias = 0;
for (int rodada = 0; rodada < qtdRodadas; rodada++)
{
    var cartoes = GerarValoresAleatoriosDistintos(qtdPrisioneiros, random)
        .ToList();

    var resultadoGeral = Resultado.Ganhou;

    for (int numPrisioneiro = 0; numPrisioneiro < qtdPrisioneiros; numPrisioneiro++)
    {
        var resultadoPrisioneiro = algoritmo == 1
            ? ExecutarRodadaPrisioneiroAleatorio(numPrisioneiro, cartoes, qtdCartoesAbrir, random)
            : ExecutarRodadaLoop(numPrisioneiro, cartoes, qtdCartoesAbrir);
        if (imprimir) ImprimirSala(resultadoPrisioneiro, qtdColunas);

        if (resultadoPrisioneiro.Resultado == Resultado.Perdeu)
        {
            resultadoGeral = Resultado.Perdeu;
            break;
        }
    }

    if (resultadoGeral == Resultado.Ganhou) qtdVitorias++;

    if (imprimir) Console.WriteLine("---------------------------");
}

Console.WriteLine("Vitorias: {0:p4}", qtdVitorias / (double)qtdRodadas);

Console.ReadLine();



static IEnumerable<int> GerarValoresAleatoriosDistintos(int quantidade, Random random)
{
    var valores = Enumerable
        .Range(0, quantidade)
        .ToList();

    for (int i = 0; i < quantidade; i++)
    {
        var indiceSorteado = random.Next(valores.Count);
        var valorSorteado = valores[indiceSorteado];
        valores.RemoveAt(indiceSorteado);

        yield return valorSorteado;
    }
}

static void ImprimirSala(ResultadoRodada resultado, int qtdColunas)
{
    for (int indice = 0; indice < resultado.Cartoes.Count; indice++)
    {
        if (indice % qtdColunas == 0) Console.WriteLine();

        var cartao = resultado.Cartoes[indice];
        Console.Write(resultado.CartoesAbertos.Contains(cartao)
            ? cartao == resultado.NumeroPrisioneiro
                ? $"{cartao:d2}* "
                : $"{cartao:d2}  "
            : "..  ");
    }
    Console.WriteLine();
    Console.WriteLine();
}

static ResultadoRodada ExecutarRodadaPrisioneiroAleatorio(int numeroPrisioneiro, IReadOnlyList<int> cartoes, int qtdCartoesAbrir, Random random)
{
    var indicesCartoesAbrir = new HashSet<int>(
        GerarValoresAleatoriosDistintos(cartoes.Count, random)
        .Take(qtdCartoesAbrir));

    var cartoesAbertos = new HashSet<int>();
    for (int i = 0; i < cartoes.Count; i++)
    {
        if (!indicesCartoesAbrir.Contains(i)) continue;

        var cartao = cartoes[i];
        cartoesAbertos.Add(cartao);
    }

    return new ResultadoRodada(numeroPrisioneiro, cartoes, cartoesAbertos);
}

static ResultadoRodada ExecutarRodadaLoop(int numeroPrisioneiro, IReadOnlyList<int> cartoes, int qtdCartoesAbrir)
{
    var cartoesAbertos = new HashSet<int>();

    var indiceAbrir = numeroPrisioneiro;
    for (int i = 0; i < qtdCartoesAbrir; i++)
    {
        var cartao = cartoes[indiceAbrir];
        cartoesAbertos.Add(cartao);
        indiceAbrir = cartao;
    }

    return new ResultadoRodada(numeroPrisioneiro, cartoes, cartoesAbertos);
}
