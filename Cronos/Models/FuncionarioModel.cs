using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Cronos.Models
{
    public class FuncionarioModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do funcionário")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do funcionário")]
        [EmailAddress(ErrorMessage = "O email informado não é valido!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite o Pis do funcionário")]
        public string? Pis { get; set; }

        [Required(ErrorMessage = "Digite a referencia do funcionário")]
        public string? Referencia { get; set; }

        [Required(ErrorMessage = "Digite o telefone do funcionário")]
        [Phone(ErrorMessage = "O telefone informado não é valido!")]
        public string? Telefone { get; set; } 
    }
}
