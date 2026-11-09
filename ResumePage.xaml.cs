namespace AppHotel;

public partial class ResumePage : ContentPage
{
    public ResumePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked_Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}