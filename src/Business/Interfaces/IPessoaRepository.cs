using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        //Vou receber alem da pessoa vou receber o endereco dela.
        Task<Pessoa> ObterPessoaEndereco(Guid id);

    }
}
