using Microsoft.AspNetCore.Mvc;
using Pedidos.Contrato.Modelos.Dto;
using Pedidos.Infraestrutura.Negocios;
using Pedidos.Contrato.Modelos.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<IEnumerable<PedidoViewModel>> Get()
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
        public async Task<ActionResult<string>> Post(string nome)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var chave = await _pedidoBll.Adicionar(nome);
                    return Ok($"PedidoId: {chave}");
                }
                throw new ArgumentException();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
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
                    return Ok("Pedido atualizado.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro atualizando o pedido: {ex.Message}");
            }            
        }
    }
}
