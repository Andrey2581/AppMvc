using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Estado { get; set; }

        [HiddenInput]
        // Ef relation - Pessoa como prpopriedade de navegação
        public Guid PessoaId { get; set; }
    }
}
