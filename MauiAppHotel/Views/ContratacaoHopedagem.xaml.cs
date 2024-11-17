namespace MauiAppHotel.Views;

public partial class ContratacaoHopedagem : ContentPage
{
	App PropriedadesApp;

	public ContratacaoHopedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.Lista_quartos;
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new HospedagemContratada());

		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
	}

    private void stp_adultos_Unfocused(object sender, FocusEventArgs e)
    {

    }
}
