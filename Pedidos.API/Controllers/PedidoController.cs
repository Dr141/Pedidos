using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.Modelos;
using Pedidos.Dominio.Modelos.Dto;
using Pedidos.Infraestrutura.Negocios;
using System.Text.Json.Serialization;
using System.Text.Json;
using Pedidos.Dominio.Modelos.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoBll _pedidoBll;
        public PedidoController(PedidoBll pedido)
        {
            _pedidoBll = pedido;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<IEnumerable<Pedido>> Get()
        {
            return await _pedidoBll.ObterTodosPedidos();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public async Task<PedidoViewModel> Get(int id)
        {
            return await _pedidoBll.ObterPedidoPorId(id);
        }

        // POST api/<PedidoController>
        [HttpPost("{nome}")]       
        public async Task<ActionResult<string>> post(string nome)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var chave = await _pedidoBll.Adicionar(nome);
                    return $"PedidoId: {chave}";
                }
                throw new ArgumentException();
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }            
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromForm] PedidoDto pedidoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _pedidoBll.AtualizarPedido(id, pedidoDto);
                    return "Pedido atualizado.";
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return $"Ocorreu erro atualizando o pedido: {ex.Message}";
            }            
        }
    }
}
