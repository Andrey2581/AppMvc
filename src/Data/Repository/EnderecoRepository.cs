using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        //acesso do banco via repositorio - persistir na base de dados
        public EnderecoRepository(MeuDbContext context) : base(context) { }
        public async Task<Endereco> ObterEnderecoPessoa(Guid pessoaId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.PessoaId == pessoaId);
                                                      //Obtive um endereço atraves de uma pessoaId
        }
    }
}
