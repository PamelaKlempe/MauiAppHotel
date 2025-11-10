using Microsoft.Maui.Controls;
using System;

namespace MauiAppHotel.Views
{
    public partial class Contato : ContentPage
    {
        public Contato()
        {
            InitializeComponent();
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edtMensagem.Text))
            {
                await DisplayAlert("Aviso", "Por favor, escreva sua mensagem antes de enviar.", "OK");
                return;
            }

            await DisplayAlert("Sucesso", "Sua mensagem foi enviada com sucesso!", "OK");
            edtMensagem.Text = string.Empty; // limpa o campo
        }

        private async void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}