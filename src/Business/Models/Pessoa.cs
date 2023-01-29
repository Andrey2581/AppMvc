using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Pessoa : Entity
    {

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Documento { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
        //Relacionamento com o Endereco 1:1
        public Endereco Endereco { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; }

    }
}
