using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {

        Task<Endereco> ObterEnderecoPessoa(Guid pessoaId);

    }
}
