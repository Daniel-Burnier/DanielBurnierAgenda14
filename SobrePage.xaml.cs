namespace AppHotel;

public partial class SobrePage : ContentPage
{
    public SobrePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked_Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}