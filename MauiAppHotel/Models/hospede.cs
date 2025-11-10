using System;

namespace MauiAppHotel.Models
{
    public class Hospede
    {
        // 🧍‍♀️ Propriedades básicas
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // 💡 Propriedade calculada: idade
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                int idade = hoje.Year - DataNascimento.Year;
                if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
                return idade;
            }
        }

        // 🔍 Método de validação
        public bool DadosValidos()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(Telefone)
                && Email.Contains("@")
                && DataNascimento < DateTime.Today;
        }
    }
}
