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
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        //acesso do banco via repositorio - persistir na base de dados
        public PessoaRepository(MeuDbContext context): base(context) { }

        //retornei a pessoa com seu endereco
        public async Task<Pessoa> ObterPessoaEndereco(Guid id)
        {
            return await Db.Pessoas.AsNoTracking().
                Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
