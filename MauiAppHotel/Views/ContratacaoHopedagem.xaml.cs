using MauiAppHotel.Models;

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

		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			Hospedagem h = new Hospedagem
			{
				QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				QntAdultos = Convert.ToInt32(stp_adultos.Value),
				QntCriancas = Convert.ToInt32(stp_criancas.Value),
				DataCheckin = dtpck_checkin.Date,
				DataCheckout = dtpck_checkin.Date,
			};



			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = h
			});

		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
	}

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

		DateTime data_selecionada_checkin = elemento.Date;

		dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
		dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}
