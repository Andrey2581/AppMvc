using App.ViewModels;
using AutoMapper;
using Business.Models;

namespace App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //De pessoa para pessoaviewmodel
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
