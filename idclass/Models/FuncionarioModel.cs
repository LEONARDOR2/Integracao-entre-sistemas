using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace idclass.Models
{
    public class FuncionarioModel
    {
       
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do funcionário")]
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do funcionário")]
        [EmailAddress(ErrorMessage = "O email informado não é valido!")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite o Pis do funcionário")]
        [JsonPropertyName("pis")]
        public string? Pis { get; set; }

        [Required(ErrorMessage = "Digite a referencia do funcionário")]
        [JsonPropertyName("referencia")]
        public string? Referencia { get; set; }

        [Required(ErrorMessage = "Digite o telefone do funcionário")]
        [Phone(ErrorMessage = "O telefone informado não é valido!")]
        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }

       
    }
}
