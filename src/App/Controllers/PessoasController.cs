using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using Business.Interfaces;
using AutoMapper;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using App.Extensions;

namespace App.Controllers
{
    //trancamos o acesso - so pessoas autenticadas utilizam o acesso
    [Authorize]
    public class PessoasController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoasController(IPessoaRepository pessoaRepository,
                                 IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("Lista-de-Pessoas")]
        public async Task<IActionResult> Index()
        {
            //mapeando pessoaviewmodel
            //verifico na minha index qual meu retorno - no caso era um IEnumerable ou seja um lista de pessoaviewmodel
            return View(_mapper.Map<IEnumerable<PessoaViewModel>> (await _pessoaRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("Detalhes-de-Pessoa/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var pessoaViewModel = await ObterPessoaEndereco(id);
            if (pessoaViewModel == null)
            {
                return NotFound();
            }

            return View(pessoaViewModel);
        }

        [ClaimsAuthorize("Pessoa","Adicionar")]
        [Route("Criação-de-Pessoa")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Pessoa", "Adicionar")]
        [Route("Criação-de-Pessoa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return View(pessoaViewModel);
            //criando e mapenando pessoa e tenho a pessoaviewmodel
            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
            //no repositorio adiciono a pessoa quee passei para adicionar
            //trabalhando a persistencia no banco
            await _pessoaRepository.Adiionar(pessoa);

            return RedirectToAction(nameof(Index));
            //return RedirectToAction("index");
        }

        [ClaimsAuthorize("Pessoa", "Editar")]
        [Route("Edição-de-Pessoa/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var pessoaViewModel = await ObterPessoaEndereco(id);
            if (pessoaViewModel == null)
            {
                return NotFound();
            }
            return View(pessoaViewModel);
        }

        [ClaimsAuthorize("Pessoa", "Editar")]
        [Route("Edição-de-Pessoa/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PessoaViewModel pessoaViewModel)
        {
            if (id != pessoaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pessoaViewModel);
            //criando e mapenando pessoa e tenho a pessoaviewmodel
            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
            //no repositorio adiciono a pessoa e passei para atualizar
            //trabalhando a persistencia no banco
            await _pessoaRepository.Atualizar(pessoa);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Pessoa", "Excluir")]
        [Route("Exclusão-de-Pessoa/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pessoaViewModel = await ObterPessoaEndereco(id);
           
            if (pessoaViewModel == null)
            {
                return NotFound();
            }

            return View(pessoaViewModel);
        }

        [ClaimsAuthorize("Pessoa", "Excluir")]
        [Route("Exclusão-de-Pessoa/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoaViewModel = await ObterPessoaEndereco(id);

            if(pessoaViewModel == null) return NotFound();

            //trabalhando a persistencia no banco
            await _pessoaRepository.Remover(id);
            //fiz uma verificação pra ver se esse id existe ou não

            if (!ModelState.IsValid) return View(pessoaViewModel);

            return RedirectToAction(nameof(Index));
        }

        //criação de um metodo privado para resolução de toda hora que precisar disso "ObterPessoaEndereco" esse metodo resolve
        private async Task<PessoaViewModel> ObterPessoaEndereco(Guid id)
        {
            return _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPessoaEndereco(id));   
        }
    }
}
