namespace MauiAppHotel.Views;

public partial class ContratacaoHopedagem : ContentPage
{
	App PropriedadesApp;

	public ContratacaoHopedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.Lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkout.MinimumDate = DateTime.Now;
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
