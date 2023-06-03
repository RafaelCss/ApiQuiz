namespace ApiQuiz.Model.Resposta.Tabela;

public class TabelaViewModel
{

	public string Id { get; set; }
	public int Posicao { get; set; }
	public int Pontos { get; set; }
	public Time Time { get; set; }
	public UltimosJogos[] UltimosJogos { get; set; }
	public int Jogos { get; set; }
	public int Vitorias { get; set; }
	public int Empates { get; set; }
	public int Derrotas { get; set; }
	public int GolsPro { get; set; }
	public int GolsContra { get; set; }
	public int SaldoGols { get; set; }
	public int Aproveitamento { get; set; }
	public int VariacaoPosicao { get; set; }

}
public class Time
{
	public int TimeId { get; set; }
	public string NomePopular { get; set; }
	public string Sigla { get; set; }
	public string Escudo { get; set; }
}
public class UltimosJogos
{
	public string[] Resultados { get; set; }
}
