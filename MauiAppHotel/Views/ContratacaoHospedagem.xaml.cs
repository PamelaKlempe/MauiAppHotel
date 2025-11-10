using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Referência ao App para acessar lista de quartos
        PropriedadesApp = (App)Application.Current;

        // Configuração do Picker de suítes
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        // Configuração do DatePicker de check-in
        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        // Configuração do DatePicker de check-out
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    // Botão "Avançar" para enviar os dados para a próxima tela
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria objeto Hospedagem com os dados selecionados
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            // Navega para tela de confirmação, passando o BindingContext
            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Atualiza o mínimo e máximo do check-out quando muda o check-in
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime dataSelecionadaCheckIn = elemento.Date;

        dtpck_checkout.MinimumDate = dataSelecionadaCheckIn.AddDays(1);
        dtpck_checkout.MaximumDate = dataSelecionadaCheckIn.AddMonths(6);
    }

    // Botão "Sobre" para abrir a tela com informações do desenvolvedor
    private async void Button_Sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private async void Button_Contato_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Contato());
    }
}