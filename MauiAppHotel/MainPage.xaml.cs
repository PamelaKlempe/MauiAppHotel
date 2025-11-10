using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel
    {
        public partial class MainPage : ContentPage
        {
            int count = 0;

            public MainPage()
            {
                InitializeComponent();
            }

            // Abre a tela Sobre (Views.Sobre)
            private async void OnSobreClicked(object sender, EventArgs e)
            {
                // Certifique-se de que a página Views.Sobre exista e o namespace esteja correto.
                await Navigation.PushAsync(new Views.Sobre());
            }


            // Exemplo simples de contador para o botão "Click me"
            private void OnCounterClicked(object sender, EventArgs e)
            {
                count++;
                CounterBtn.Text = $"Você clicou {count} {(count == 1 ? "vez" : "vezes")}";
            }
        }
    }
