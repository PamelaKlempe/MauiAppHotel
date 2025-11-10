using MauiAppHotel.Models;

namespace MauiAppHotel.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada()
        {
            InitializeComponent();
        }

        // 🔙 Botão VOLTAR
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // ✅ Botão CONFIRMAR RESERVA
        private async void Button_Confirmar_Clicked(object sender, EventArgs e)
        {
            // Cria o hóspede com base nos dados digitados
            Hospede novoHospede = new Hospede
            {
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                DataNascimento = dtNascimento.Date
            };

            // Validação dos dados
            if (!novoHospede.DadosValidos())
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos corretamente antes de confirmar.", "OK");
                return;
            }

            // Exibe confirmação
            string mensagem = $"Reserva confirmada para {novoHospede.Nome}!\n\n" +
                              $"Contato: {novoHospede.Telefone}\n" +
                              $"E-mail: {novoHospede.Email}\n" +
                              $"Idade: {novoHospede.Idade} anos.";

            await DisplayAlert("Sucesso", mensagem, "OK");
        }
    }
}