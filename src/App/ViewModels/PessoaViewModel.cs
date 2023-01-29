using Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace App.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Nome { get; set; }

        //Pois não quero que ele seja criado como campo pra na hora do scaffold desconsidera essa coluna
        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [ScaffoldColumn(false)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        public string Documento { get; set; }

        [DisplayName("Tipo")]
        //trato como um int pois não preciso do enum como Objeto de tranporte
        public int TipoPessoa { get; set; }


        //Relacionamento com o Endereco 1:1
        public EnderecoViewModel Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} e Obrigatorio")]
        [StringLength(13, ErrorMessage = "O campo {0} precisa ser entre {2} e {1} caractere", MinimumLength = 2)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

    }
}
