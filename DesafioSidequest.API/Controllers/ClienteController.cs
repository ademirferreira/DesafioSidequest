using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DesafioSidequest.API.ViewModels;
using DesafioSidequest.Business.Interfaces;
using DesafioSidequest.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSidequest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(
            IClienteRepository clienteRepository,
            IClienteService clienteService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet("obter-todos")]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            var cliente = _mapper
                .Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            return cliente;
        }

        [HttpGet("obter-por-id/{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
            if (cliente is null) return NotFound();
            return cliente;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));
            return CustomResponse(clienteViewModel);
        }

        [HttpPut("atualizar/{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(clienteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));
            return CustomResponse(clienteViewModel);
        }

        [HttpDelete("excluir/{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            await _clienteService.Remover(id);
            return CustomResponse();
        }
    }
}
