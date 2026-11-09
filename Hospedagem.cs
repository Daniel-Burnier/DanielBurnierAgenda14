namespace AppHotel.Models;

public class Hospedagem
{
    public Quarto QuartoSelecionado { get; set; }
    public int QntAdultos { get; set; }
    public int QntCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia => (DataCheckOut - DataCheckIn).Days;

    public double ValorTotal
    {
        get
        {
            if (QuartoSelecionado == null) return 0;
            double valorAdultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
            double valorCriancas = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;
            return (valorAdultos + valorCriancas) * Estadia;
        }
    }
}

public class Quarto
{
    public string Descricao { get; set; }
    public double ValorDiariaAdulto { get; set; }
    public double ValorDiariaCrianca { get; set; }
}