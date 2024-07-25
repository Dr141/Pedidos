using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.Modelos;
using Pedidos.Dominio.Modelos.Dto;
using Pedidos.Infraestrutura.Negocios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProtudoBll _produtoBll;
        public ProdutoController(ProtudoBll produto)
        {
            _produtoBll = produto;
        }

        // POST api/<ProdutoController>
        [HttpPost("{PedidoID}")]
        public async Task<string> Post(int PedidoID, [FromForm] ProdutoDto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = await _produtoBll.AdicionarProduto(PedidoID, produto);
                    return "Produto incluído com sucesso.";
                }
                throw new ArgumentException();
            }
            catch (Exception ex) 
            {
                return $"Ocorreu erro: {ex.Message}";
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                await _produtoBll.RemoverProduto(id);
                return "Produto removido com sucesso.";
            }
            catch (Exception ex) 
            {
                return $"Ocorreu erro: {ex.Message}";
            }
        }
    }
}
