using AppHotel.Models;

namespace AppHotel;

public partial class MainPage : ContentPage
{
    List<Quarto> lista_quartos = new List<Quarto>
    {
        new Quarto() { Descricao = "Suíte Luxo", ValorDiariaAdulto = 110.0, ValorDiariaCrianca = 55.0 },
        new Quarto() { Descricao = "Suíte Single", ValorDiariaAdulto = 60.0, ValorDiariaCrianca = 30.0 },
        new Quarto() { Descricao = "Suíte Econômica", ValorDiariaAdulto = 25.0, ValorDiariaCrianca = 12.5 }
    };

    public MainPage()
    {
        InitializeComponent();
        pck_quarto.ItemsSource = lista_quartos;

        // Atribuição inicial com verificação de nulos
        DateTime dataCheckinInicial = dtpck_checkin.Date ?? DateTime.Now;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

        dtpck_checkout.MinimumDate = dataCheckinInicial.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckinInicial.AddMonths(6);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = (DatePicker)sender;
        DateTime data_selecionada = elemento.Date ?? DateTime.Now;

        dtpck_checkout.MinimumDate = data_selecionada.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada.AddMonths(6);
    }

    private async void Button_Clicked_Avancar(object sender, EventArgs e)
    {
        try
        {
            var h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date ?? DateTime.Now,
                DataCheckOut = dtpck_checkout.Date ?? DateTime.Now.AddDays(1)
            };

            if (h.QuartoSelecionado == null)
            {
                await DisplayAlert("Erro", "Por favor, selecione um quarto.", "OK");
                return;
            }

            await Navigation.PushAsync(new ResumePage
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Button_Clicked_Sobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}